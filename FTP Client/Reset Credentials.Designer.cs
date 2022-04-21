namespace FTP_Client
{
    partial class Reset_Credentials
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reset_Credentials));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameField = new System.Windows.Forms.TextBox();
            this.passwordField = new System.Windows.Forms.TextBox();
            this.adminPinField = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.showAdminPin = new System.Windows.Forms.Button();
            this.showPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reset Credentials";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Admin Pin:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 63);
            this.label3.TabIndex = 4;
            this.label3.Text = "New Username:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 35);
            this.label4.TabIndex = 5;
            this.label4.Text = "New Password:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernameField
            // 
            this.usernameField.Location = new System.Drawing.Point(191, 135);
            this.usernameField.Multiline = true;
            this.usernameField.Name = "usernameField";
            this.usernameField.Size = new System.Drawing.Size(161, 20);
            this.usernameField.TabIndex = 1;
            this.usernameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordField
            // 
            this.passwordField.Location = new System.Drawing.Point(191, 184);
            this.passwordField.Multiline = true;
            this.passwordField.Name = "passwordField";
            this.passwordField.Size = new System.Drawing.Size(161, 20);
            this.passwordField.TabIndex = 2;
            this.passwordField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // adminPinField
            // 
            this.adminPinField.Location = new System.Drawing.Point(191, 67);
            this.adminPinField.Multiline = true;
            this.adminPinField.Name = "adminPinField";
            this.adminPinField.Size = new System.Drawing.Size(161, 20);
            this.adminPinField.TabIndex = 0;
            this.adminPinField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(17, 217);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(365, 52);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Reset";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // showAdminPin
            // 
            this.showAdminPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAdminPin.Location = new System.Drawing.Point(358, 67);
            this.showAdminPin.Name = "showAdminPin";
            this.showAdminPin.Size = new System.Drawing.Size(24, 20);
            this.showAdminPin.TabIndex = 6;
            this.showAdminPin.Text = "~";
            this.showAdminPin.UseVisualStyleBackColor = true;
            this.showAdminPin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showAdminPin_MouseDown);
            this.showAdminPin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showAdminPin_MouseUp);
            // 
            // showPassword
            // 
            this.showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword.Location = new System.Drawing.Point(358, 184);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(24, 20);
            this.showPassword.TabIndex = 7;
            this.showPassword.Text = "~";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassword_MouseDown);
            this.showPassword.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassword_MouseUp);
            // 
            // Reset_Credentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 281);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.showAdminPin);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.adminPinField);
            this.Controls.Add(this.passwordField);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reset_Credentials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reset Credentials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox usernameField;
        private System.Windows.Forms.TextBox passwordField;
        private System.Windows.Forms.TextBox adminPinField;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button showAdminPin;
        private System.Windows.Forms.Button showPassword;
    }
}