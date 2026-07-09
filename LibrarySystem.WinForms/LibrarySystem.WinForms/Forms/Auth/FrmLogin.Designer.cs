using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Auth
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.chkShowPassword = new CheckBox();
            this.pnlMain = new Panel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text = "Library System - Login";
            this.Size = new Size(420, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 10f);
            this.Load += new EventHandler(this.FrmLogin_Load);

            // pnlMain
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.Location = new Point(30, 30);
            this.pnlMain.Size = new Size(340, 400);

            // lblTitle
            this.lblTitle.Text = "Library System";
            this.lblTitle.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(30, 100, 180);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(20, 30);
            this.lblTitle.Size = new Size(300, 50);

            // lblUsername
            this.lblUsername.Text = "Username";
            this.lblUsername.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblUsername.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblUsername.Location = new Point(20, 110);
            this.lblUsername.Size = new Size(300, 25);

            // txtUsername
            this.txtUsername.Location = new Point(20, 138);
            this.txtUsername.Size = new Size(300, 35);
            this.txtUsername.Font = new Font("Segoe UI", 11f);
            this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
            this.txtUsername.KeyDown += new KeyEventHandler(this.txtUsername_KeyDown);

            // lblPassword
            this.lblPassword.Text = "Password";
            this.lblPassword.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblPassword.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblPassword.Location = new Point(20, 195);
            this.lblPassword.Size = new Size(300, 25);

            // txtPassword
            this.txtPassword.Location = new Point(20, 223);
            this.txtPassword.Size = new Size(300, 35);
            this.txtPassword.Font = new Font("Segoe UI", 11f);
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new KeyEventHandler(this.txtPassword_KeyDown);

            // chkShowPassword
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.Location = new Point(20, 268);
            this.chkShowPassword.Size = new Size(150, 25);
            this.chkShowPassword.ForeColor = Color.FromArgb(100, 100, 100);
            this.chkShowPassword.CheckedChanged += new EventHandler(this.chkShowPassword_CheckedChanged);

            // btnLogin
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new Point(20, 315);
            this.btnLogin.Size = new Size(300, 45);
            this.btnLogin.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            this.btnLogin.BackColor = Color.FromArgb(30, 100, 180);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // pnlMain Controls
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblUsername);
            this.pnlMain.Controls.Add(this.txtUsername);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.chkShowPassword);
            this.pnlMain.Controls.Add(this.btnLogin);

            // Form Controls
            this.Controls.Add(this.pnlMain);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private CheckBox chkShowPassword;
        private Panel pnlMain;
    }
}