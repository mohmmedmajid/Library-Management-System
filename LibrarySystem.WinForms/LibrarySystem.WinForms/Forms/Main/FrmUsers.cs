using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Main
{
    public partial class FrmUsers : Form
    {
        private List<User> _users = new List<User>();
        private List<Role> _roles = new List<Role>();

        public FrmUsers()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(510, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);

            dgvUsers.CellFormatting += DgvUsers_CellFormatting;
        }

        // ─────────────────────────────────────────────
        //  CELL FORMATTING
        // ─────────────────────────────────────────────
        private void DgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvUsers.Columns["colEdit"].Index;
            int pwdCol = dgvUsers.Columns["colPassword"].Index;
            int unlockCol = dgvUsers.Columns["colUnlock"].Index;
            int delCol = dgvUsers.Columns["colDelete"].Index;

            string val = dgvUsers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            if (string.IsNullOrEmpty(val))
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(220, 230, 241);
                return;
            }

            if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == pwdCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(100, 60, 160);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(80, 40, 140);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == unlockCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(180, 110, 0);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(150, 90, 0);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == delCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(170, 30, 30);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        // ─────────────────────────────────────────────
        //  LOAD
        // ─────────────────────────────────────────────
        private async void FrmUsers_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            await LoadRoles();
            await LoadUsers();
        }

        private async System.Threading.Tasks.Task LoadRoles()
        {
            try
            {
                _roles = await ApiHelper.GetAsync<List<Role>>("roles")
                         ?? new List<Role>();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadUsers()
        {
            try
            {
                spinner.Start();
                _users = await ApiHelper.GetAsync<List<User>>("users")
                         ?? new List<User>();
                BindGrid(_users);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading users: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        // ─────────────────────────────────────────────
        //  BIND GRID
        // ─────────────────────────────────────────────
        private void BindGrid(List<User> list)
        {
            dgvUsers.Rows.Clear();
            foreach (var u in list)
            {
                bool isOtherAdmin = u.RoleName == "Admin" && u.UserID != SessionManager.UserId;

                dgvUsers.Rows.Add(
                    u.UserID,
                    u.Username,
                    u.FullName,
                    u.Email,
                    u.RoleName,
                    u.IsActive ? "✓ Active" : "✗ Inactive",
                    u.IsLocked ? "🔒 Locked" : "🔓 Open",
                    isOtherAdmin ? "" : "✏️ Edit",
                    isOtherAdmin ? "" : "🔑 Pwd",
                    isOtherAdmin ? "" : "🔓 Unlock",
                    isOtherAdmin ? "" : "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        // ─────────────────────────────────────────────
        //  GRID CELL CLICK
        // ─────────────────────────────────────────────
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string val = dgvUsers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
            if (string.IsNullOrEmpty(val)) return;

            int id = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colID"].Value);
            var user = _users.Find(u => u.UserID == id);
            if (user == null) return;

            if (e.ColumnIndex == dgvUsers.Columns["colEdit"].Index)
                OpenEditDialog(user);
            else if (e.ColumnIndex == dgvUsers.Columns["colPassword"].Index)
                OpenChangePasswordDialog(user);
            else if (e.ColumnIndex == dgvUsers.Columns["colUnlock"].Index)
                UnlockUser(user);
            else if (e.ColumnIndex == dgvUsers.Columns["colDelete"].Index)
                DeleteUser(user);
        }

        // ─────────────────────────────────────────────
        //  OPEN EDIT DIALOG
        // ─────────────────────────────────────────────
        private void OpenEditDialog(User user = null)
        {
            bool isNew = user == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add User" : "✏️ Edit User",
                Size = new Size(480, isNew ? 520 : 490),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(480, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = isNew ? "➕ Add User" : "✏️ Edit User", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(440, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 68; int lx = 20; int fx = 20; int fw = 430;

            dlg.Controls.Add(new Label { Text = "Username *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var txtUsername = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : user.Username, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtUsername);
            y += 44;

            dlg.Controls.Add(new Label { Text = "Full Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var txtFullName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : user.FullName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtFullName);
            y += 44;

            dlg.Controls.Add(new Label { Text = "Email", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var txtEmail = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : user.Email, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtEmail);
            y += 44;

            TextBox txtPassword = null;
            if (isNew)
            {
                dlg.Controls.Add(new Label { Text = "Password *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 24;
                txtPassword = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), UseSystemPasswordChar = true };
                dlg.Controls.Add(txtPassword);
                y += 44;
            }

            dlg.Controls.Add(new Label { Text = "Role *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var cmbRole = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
            cmbRole.Items.Add(new ComboItem { ID = 0, Name = "-- Select Role --" });
            foreach (var r in _roles)
                cmbRole.Items.Add(new ComboItem { ID = r.RoleID, Name = r.RoleName });
            cmbRole.DisplayMember = "Name";
            cmbRole.ValueMember = "ID";
            cmbRole.SelectedIndex = 0;
            if (!isNew)
                foreach (ComboItem ci in cmbRole.Items)
                    if (ci.ID == user.RoleID) { cmbRole.SelectedItem = ci; break; }
            dlg.Controls.Add(cmbRole);
            y += 44;

            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 28), Checked = user.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive);
                y += 40;
            }

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(205, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 225, y), Size = new Size(205, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                { MessageHelper.ShowWarning("Please enter username."); return; }
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                { MessageHelper.ShowWarning("Please enter full name."); return; }
                if (isNew && string.IsNullOrWhiteSpace(txtPassword?.Text))
                { MessageHelper.ShowWarning("Please enter password."); return; }

                var selRole = cmbRole.SelectedItem as ComboItem;
                if (selRole == null || selRole.ID == 0)
                { MessageHelper.ShowWarning("Please select a role."); return; }

                try
                {
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateUserDTO
                        {
                            Username = txtUsername.Text.Trim(),
                            FullName = txtFullName.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Password = txtPassword.Text.Trim(),
                            RoleID = selRole.ID,
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<User>("users", dto) != null)
                        { MessageHelper.ShowSuccess("User added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateUserDTO
                        {
                            UserID = user.UserID,
                            Username = txtUsername.Text.Trim(),
                            FullName = txtFullName.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            RoleID = selRole.ID,
                            IsActive = chkActive?.Checked ?? true
                        };
                        if (await ApiHelper.PutAsync<User>("users/" + user.UserID, dto) != null)
                        { MessageHelper.ShowSuccess("User updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error: " + ex.Message);
                    btnSave.Enabled = true;
                    btnSave.Text = "💾 Save";
                }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadUsers();
        }

        // ─────────────────────────────────────────────
        //  CHANGE PASSWORD DIALOG
        // ─────────────────────────────────────────────
        private void OpenChangePasswordDialog(User user)
        {
            var dlg = new Form
            {
                Text = "🔑 Change Password",
                Size = new Size(400, 310),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(400, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = $"🔑 {user.Username} - Change Password", Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(370, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 68; int fx = 20; int fw = 355;

            dlg.Controls.Add(new Label { Text = "Current Password *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var txtCurrent = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), UseSystemPasswordChar = true };
            dlg.Controls.Add(txtCurrent);
            y += 44;

            dlg.Controls.Add(new Label { Text = "New Password *", Location = new Point(fx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var txtNew = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), UseSystemPasswordChar = true };
            dlg.Controls.Add(txtNew);
            y += 44;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(170, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 190, y), Size = new Size(170, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCurrent.Text))
                { MessageHelper.ShowWarning("Please enter current password."); return; }
                if (string.IsNullOrWhiteSpace(txtNew.Text))
                { MessageHelper.ShowWarning("Please enter new password."); return; }

                try
                {
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";

                    var dto = new ChangePasswordDTO
                    {
                        UserID = user.UserID,
                        CurrentPassword = txtCurrent.Text.Trim(),
                        NewPassword = txtNew.Text.Trim()
                    };
                    await ApiHelper.PostAsync<object>("users/change-password", dto);
                    MessageHelper.ShowSuccess("Password changed successfully!");
                    dlg.Close();
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error: " + ex.Message);
                    btnSave.Enabled = true;
                    btnSave.Text = "💾 Save";
                }
            };

            dlg.ShowDialog(this);
        }

        // ─────────────────────────────────────────────
        //  UNLOCK USER
        // ─────────────────────────────────────────────
        private async void UnlockUser(User user)
        {
            if (!user.IsLocked)
            { MessageHelper.ShowWarning("This account is not locked."); return; }

            if (!MessageHelper.ShowConfirm($"Unlock account \"{user.Username}\"?"))
                return;

            try
            {
                spinner.Start();
                await ApiHelper.PostAsync<object>($"users/{user.UserID}/unlock", null);
                MessageHelper.ShowSuccess("Account unlocked successfully.");
                await LoadUsers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────
        private async void DeleteUser(User user)
        {
            if (user.UserID == SessionManager.UserId)
            { MessageHelper.ShowWarning("Cannot delete your own account."); return; }

            if (!MessageHelper.ShowConfirm($"Delete \"{user.Username}\"?\nThis action cannot be undone."))
                return;

            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("users/" + user.UserID);
                MessageHelper.ShowSuccess("User deleted successfully.");
                await LoadUsers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────
        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_users); return; }
            string s = text.ToLower();
            var filtered = new List<User>();
            foreach (var u in _users)
                if (u.Username.ToLower().Contains(s) ||
                    u.FullName.ToLower().Contains(s) ||
                    u.Email.ToLower().Contains(s) ||
                   (u.RoleName != null && u.RoleName.ToLower().Contains(s)))
                    filtered.Add(u);
            BindGrid(filtered);
        }

        // ─────────────────────────────────────────────
        //  TOP BUTTONS
        // ─────────────────────────────────────────────
        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadUsers();
        }

        // ─────────────────────────────────────────────
        //  INNER CLASS
        // ─────────────────────────────────────────────
        private class ComboItem
        {
            public int ID { get; set; }
            public string Name { get; set; } = "";
            public override string ToString() => Name;
        }
    }
}