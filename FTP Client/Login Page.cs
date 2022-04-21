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
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
            passwordField.PasswordChar = Convert.ToChar("*");
        }

        private void Login_Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verifyLogin();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            verifyLogin();
        }

        private void verifyLogin()
        {
            AESEncDec aed = new AESEncDec();

            string decUsername = "";
            string decPassword = "";
            using (StreamReader reader = new StreamReader("encUsernamePassword.txt", true))
            {
                decUsername = aed.Decrypt(reader.ReadLine(), "ftpserverusername");
                decPassword = aed.Decrypt(reader.ReadLine(), "ftpserverpassword");
            }

            if (usernameField.Text == decUsername & passwordField.Text == decPassword)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                this.Close();
            } else
            {
                MessageBox.Show("Credentials are bad.", "Bad Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Reset_Credentials rc = new Reset_Credentials();
            rc.Show();
        }

        private void Login_Page_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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