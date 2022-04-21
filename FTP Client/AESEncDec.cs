using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Client
{
    class AESEncDec
    {
        private readonly int _saltSize = 32;
        private static string globalInputPath = "";
        private static string globalOutputPath = "";

        public string Encrypt(string plainText, string key)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException("plainText");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, _saltSize))
            {
                byte[] saltBytes = keyDerivationFunction.Salt;
                byte[] keyBytes = keyDerivationFunction.GetBytes(32);
                byte[] ivBytes = keyDerivationFunction.GetBytes(16);

                using (var aesManaged = new AesManaged())
                {
                    aesManaged.KeySize = 256;

                    using (var encryptor = aesManaged.CreateEncryptor(keyBytes, ivBytes))
                    {
                        MemoryStream memoryStream = null;
                        CryptoStream cryptoStream = null;

                        return WriteMemoryStream(plainText, ref saltBytes, encryptor, ref memoryStream, ref cryptoStream);
                    }
                }
            }
        }

        public string Decrypt(string ciphertext, string key)
        {
            if (string.IsNullOrEmpty(ciphertext))
            {
                throw new ArgumentNullException("ciphertext");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            var allTheBytes = Convert.FromBase64String(ciphertext);
            var saltBytes = allTheBytes.Take(_saltSize).ToArray();
            var ciphertextBytes = allTheBytes.Skip(_saltSize).Take(allTheBytes.Length - _saltSize).ToArray();

            using (var keyDerivationFunction = new Rfc2898DeriveBytes(key, saltBytes))
            {
                var keyBytes = keyDerivationFunction.GetBytes(32);
                var ivBytes = keyDerivationFunction.GetBytes(16);

                return DecryptWithAES(ciphertextBytes, keyBytes, ivBytes);
            }
        }

        private string WriteMemoryStream(string plainText, ref byte[] saltBytes, ICryptoTransform encryptor, ref MemoryStream memoryStream, ref CryptoStream cryptoStream)
        {
            try
            {
                memoryStream = new MemoryStream();

                try
                {
                    cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                }
                finally
                {
                    if (cryptoStream != null)
                    {
                        cryptoStream.Dispose();
                    }
                }

                var cipherTextBytes = memoryStream.ToArray();
                Array.Resize(ref saltBytes, saltBytes.Length + cipherTextBytes.Length);
                Array.Copy(cipherTextBytes, 0, saltBytes, _saltSize, cipherTextBytes.Length);

                return Convert.ToBase64String(saltBytes);
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        private static string DecryptWithAES(byte[] ciphertextBytes, byte[] keyBytes, byte[] ivBytes)
        {
            using (var aesManaged = new AesManaged())
            {
                using (var decryptor = aesManaged.CreateDecryptor(keyBytes, ivBytes))
                {
                    MemoryStream memoryStream = null;
                    CryptoStream cryptoStream = null;
                    StreamReader streamReader = null;

                    try
                    {
                        memoryStream = new MemoryStream(ciphertextBytes);
                        cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                        streamReader = new StreamReader(cryptoStream);

                        return streamReader.ReadToEnd();
                    }
                    finally
                    {
                        if (memoryStream != null)
                        {
                            memoryStream.Dispose();
                            memoryStream = null;
                        }
                    }
                }
            }
        }

        private const string Salt = "d5fg4df5sg4ds5fg45sdfg4";
        private const int SizeOfBuffer = 1024 * 8;

        internal static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        internal static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }

        public void EncryptFile(string inputPath, string outputPath, string password)
        {
            globalInputPath = inputPath;
            globalOutputPath = outputPath;

            var output = new FileStream(globalOutputPath, FileMode.OpenOrCreate, FileAccess.Write);

            // Essentially, if you want to use RijndaelManaged as AES you need to make sure that:
            // 1.The block size is set to 128 bits
            // 2.You are not using CFB mode, or if you are the feedback size is also 128 bits

            var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
            var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(Salt));

            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            using (var encryptedStream = new CryptoStream(output, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
            {
                output.Close();
                var input = new FileStream(globalInputPath, FileMode.Open, FileAccess.Read);
                CopyStream(input, encryptedStream);
                input.Close();
            }
        }

        public void DecryptFile(string inputPath, string outputPath, string password)
        {
            globalInputPath = inputPath;
            globalOutputPath = outputPath;

            var output = new FileStream(globalOutputPath, FileMode.OpenOrCreate, FileAccess.Write);

            // Essentially, if you want to use RijndaelManaged as AES you need to make sure that:
            // 1.The block size is set to 128 bits
            // 2.You are not using CFB mode, or if you are the feedback size is also 128 bits
            var algorithm = new RijndaelManaged { KeySize = 256, BlockSize = 128 };
            var key = new Rfc2898DeriveBytes(password, Encoding.ASCII.GetBytes(Salt));

            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            try
            {
                using (var decryptedStream = new CryptoStream(output, algorithm.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    output.Close();
                    var input = new FileStream(globalInputPath, FileMode.Open, FileAccess.Read);
                    CopyStream(input, decryptedStream);
                    input.Close();
                }
            }
            catch (CryptographicException)
            {
                throw new InvalidDataException("Please supply a correct password");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void CopyStream(Stream input, Stream output)
        {
            input.Close();
            using (output)
            using (input)
            {
                byte[] buffer = new byte[SizeOfBuffer];
                int read;

                var inputStream = new FileStream(globalInputPath, FileMode.Open, FileAccess.Read);
                while ((read = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    input.Close();
                    var outputStream = new FileStream(globalOutputPath, FileMode.OpenOrCreate, FileAccess.Write);
                    outputStream.Write(buffer, 0, read);
                    outputStream.Close();
                    inputStream.Close();
                }
            }
            input.Close();
            output.Close();
        }
    }
}