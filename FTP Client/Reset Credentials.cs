using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTP_Client
{
    public partial class Reset_Credentials : Form
    {
        public Reset_Credentials()
        {
            InitializeComponent();
            adminPinField.PasswordChar = '*';
            passwordField.PasswordChar = '*';
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string encryptedPin = "";

            using (StreamReader reader = new StreamReader("encAdminPin.txt", true))
            {
                encryptedPin = reader.ReadLine();
            }

            AESEncDec aed = new AESEncDec();
            string decryptedPin = aed.Decrypt(encryptedPin, "ftpserver");

            if (adminPinField.Text == decryptedPin & usernameField.Text != passwordField.Text)
            {
                File.Delete("encUsernamePassword.txt");
                File.Create("encUsernamePassword.txt").Close();

                using (StreamWriter writer = new StreamWriter("encUsernamePassword.txt", true))
                {
                    string encryptedUsername = aed.Encrypt(usernameField.Text, "ftpserverusername");
                    string encryptedPassword = aed.Encrypt(passwordField.Text, "ftpserverpassword");
                    writer.WriteLine(encryptedUsername);
                    writer.WriteLine(encryptedPassword);
                }

                MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } else if (adminPinField.Text != decryptedPin)
            {
                // TODO Add a data erasal feature if the admin pin is entered incorrectly too many times.
                if (MessageBox.Show("The admin pin is incorrect.", "Incorrect Admin Pin", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    this.Close();
                }
            } else if (usernameField.Text == passwordField.Text)
            {
                if (MessageBox.Show("The username cannot be the same as the password.", "Invalid Username/Password", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                {
                    this.Close();
                }
            } else
            {
                // TODO Add web service to report errors.
                MessageBox.Show("An unexpected error occured! Please contact the developer of this program! This operation will now break to prevent further errors.", "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void showAdminPin_MouseDown(object sender, MouseEventArgs e)
        {
            adminPinField.PasswordChar = '\0';
        }

        private void showAdminPin_MouseUp(object sender, MouseEventArgs e)
        {
            adminPinField.PasswordChar = '*';
        }

        private void showPassword_MouseDown(object sender, MouseEventArgs e)
        {
            passwordField.PasswordChar = '\0';
        }

        private void showPassword_MouseUp(object sender, MouseEventArgs e)
        {
            passwordField.PasswordChar = '*';
        }
    }
}
