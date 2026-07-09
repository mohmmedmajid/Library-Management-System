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
    public partial class FrmRoles : Form
    {
        private List<Role> _roles = new List<Role>();

        public FrmRoles()
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

            dgvRoles.CellFormatting += DgvRoles_CellFormatting;
        }

        // ─────────────────────────────────────────────
        //  CELL FORMATTING - Fix button colors
        // ─────────────────────────────────────────────
        private void DgvRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvRoles.Columns["colEdit"].Index;
            int delCol = dgvRoles.Columns["colDelete"].Index;

            if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
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
        private async void FrmRoles_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            await LoadRoles();
        }

        private async System.Threading.Tasks.Task LoadRoles()
        {
            try
            {
                spinner.Start();
                _roles = await ApiHelper.GetAsync<List<Role>>("roles")
                         ?? new List<Role>();
                BindGrid(_roles);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading roles: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        // ─────────────────────────────────────────────
        //  BIND GRID
        // ─────────────────────────────────────────────
        private void BindGrid(List<Role> list)
        {
            dgvRoles.Rows.Clear();
            foreach (var r in list)
            {
                dgvRoles.Rows.Add(
                    r.RoleID,
                    r.RoleName,
                    r.Description,
                    r.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        // ─────────────────────────────────────────────
        //  GRID CELL CLICK
        // ─────────────────────────────────────────────
        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int roleId = Convert.ToInt32(dgvRoles.Rows[e.RowIndex].Cells["colID"].Value);
            var role = _roles.Find(r => r.RoleID == roleId);
            if (role == null) return;

            if (e.ColumnIndex == dgvRoles.Columns["colEdit"].Index)
                OpenEditDialog(role);
            else if (e.ColumnIndex == dgvRoles.Columns["colDelete"].Index)
                DeleteRole(role);
        }

        // ─────────────────────────────────────────────
        //  OPEN EDIT DIALOG
        // ─────────────────────────────────────────────
        private void OpenEditDialog(Role role = null)
        {
            bool isNew = role == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add New Role" : "✏️ Edit Role",
                Size = new Size(440, 340),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            // ── Header ──
            var pnlHeader = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(440, 50),
                BackColor = Color.FromArgb(22, 32, 50)
            };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add New Role" : "✏️ Edit Role",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(400, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70;
            int lx = 20;
            int fx = 20;
            int fw = 390;

            // ── Role Name ──
            dlg.Controls.Add(new Label
            {
                Text = "Role Name *",
                Location = new Point(lx, y),
                Size = new Size(fw, 22),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });
            y += 25;
            var txtRoleName = new TextBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 30),
                Text = isNew ? "" : role.RoleName,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f)
            };
            dlg.Controls.Add(txtRoleName);
            y += 45;

            // ── Description ──
            dlg.Controls.Add(new Label
            {
                Text = "Description",
                Location = new Point(lx, y),
                Size = new Size(fw, 22),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60)
            });
            y += 25;
            var txtDescription = new TextBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 60),
                Text = isNew ? "" : role.Description,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10f),
                Multiline = true
            };
            dlg.Controls.Add(txtDescription);
            y += 75;

            // ── Buttons ──
            var btnSave = new Button
            {
                Text = "💾 Save",
                Location = new Point(fx, y),
                Size = new Size(185, 42),
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button
            {
                Text = "✕ Cancel",
                Location = new Point(fx + 200, y),
                Size = new Size(185, 42),
                BackColor = Color.FromArgb(160, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            // ── Save Logic ──
            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtRoleName.Text))
                { MessageHelper.ShowWarning("Please enter role name."); return; }

                try
                {
                    btnSave.Enabled = false;
                    btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateRoleDTO
                        {
                            RoleName = txtRoleName.Text.Trim(),
                            Description = txtDescription.Text.Trim()
                        };
                        if (await ApiHelper.PostAsync<Role>("roles", dto) != null)
                        { MessageHelper.ShowSuccess("Role added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateRoleDTO
                        {
                            RoleID = role.RoleID,
                            RoleName = txtRoleName.Text.Trim(),
                            Description = txtDescription.Text.Trim()
                        };
                        if (await ApiHelper.PutAsync<Role>("roles/" + role.RoleID, dto) != null)
                        { MessageHelper.ShowSuccess("Role updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
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
                _ = LoadRoles();
        }

        // ─────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────
        private async void DeleteRole(Role role)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{role.RoleName}\"?\nThis action cannot be undone."))
                return;

            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("roles/" + role.RoleID);
                MessageHelper.ShowSuccess("Role deleted successfully.");
                await LoadRoles();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────
        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_roles); return; }
            string s = text.ToLower();
            var filtered = new List<Role>();
            foreach (var r in _roles)
                if (r.RoleName.ToLower().Contains(s) ||
                   (r.Description != null && r.Description.ToLower().Contains(s)))
                    filtered.Add(r);
            BindGrid(filtered);
        }

        // ─────────────────────────────────────────────
        //  TOP BUTTONS
        // ─────────────────────────────────────────────
        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadRoles();
        }
    }
}