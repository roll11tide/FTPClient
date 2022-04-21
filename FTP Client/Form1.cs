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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Login_Page lp = new Login_Page();
            lp.Show();
            this.Hide();
            if (!File.Exists("encAdminPin.txt"))
            {
                File.Create("encAdminPin.txt").Close();
            }

            if (!File.Exists("encUsernamePassword.txt"))
            {
                File.Create("encUsernamePassword.txt").Close();
            }

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Terminate main worker thread? Warning - this will close the whole application tree!", "Terminated Main Thread?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                e.Cancel = false;
            } else
            {
                e.Cancel = true;
            }
        }
    }
}