using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Auth;
using LibrarySystem.WinForms.Models.DTOs;
using System;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Auth
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.IsEmpty(txtUsername.Text))
            {
                MessageHelper.ShowWarning("Please enter username.");
                txtUsername.Focus();
                return;
            }

            if (ValidationHelper.IsEmpty(txtPassword.Text))
            {
                MessageHelper.ShowWarning("Please enter password.");
                txtPassword.Focus();
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Logging in...";

                var dto = new LoginDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                };

                var response = await ApiHelper.PostAsync<LoginResponse>(
                    "users/login", dto);

                if (response != null && response.IsActive)
                {
                    SessionManager.Login(
                        response.UserID,
                        response.Username,
                        response.FullName,
                        response.RoleName,
                        ""
                    );

                    var frmMain = new Main.FrmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageHelper.ShowError("Invalid username or password.");
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Connection error: " + ex.Message);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}