using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Accounting
{
    public partial class FrmAccountTypes : Form
    {
        private List<AccountType> _accountTypes = new List<AccountType>();

        public FrmAccountTypes()
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

            dgvAccountTypes.CellFormatting += DgvAccountTypes_CellFormatting;
        }

        private void DgvAccountTypes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int editCol = dgvAccountTypes.Columns["colEdit"].Index;
            int delCol = dgvAccountTypes.Columns["colDelete"].Index;

            if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == delCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmAccountTypes_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvAccountTypes.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvAccountTypes.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadAccountTypes();
        }

        private async System.Threading.Tasks.Task LoadAccountTypes()
        {
            try
            {
                spinner.Start();
                _accountTypes = await ApiHelper.GetAsync<List<AccountType>>("accounttypes")
                                ?? new List<AccountType>();
                BindGrid(_accountTypes);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading account types: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<AccountType> list)
        {
            dgvAccountTypes.Rows.Clear();
            foreach (var a in list)
            {
                dgvAccountTypes.Rows.Add(
                    a.AccountTypeID,
                    a.TypeName,
                    a.TypeNameAr,
                    a.NormalBalance,
                    a.DisplayOrder,
                    a.Description,
                    a.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvAccountTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvAccountTypes.Rows[e.RowIndex].Cells["colID"].Value);
            var item = _accountTypes.Find(x => x.AccountTypeID == id);
            if (item == null) return;

            if (e.ColumnIndex == dgvAccountTypes.Columns["colEdit"].Index)
                OpenEditDialog(item);
            else if (e.ColumnIndex == dgvAccountTypes.Columns["colDelete"].Index)
                DeleteAccountType(item);
        }

        private void OpenEditDialog(AccountType at = null)
        {
            bool isNew = at == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Account Type" : "✏️ Edit Account Type",
                Size = new Size(460, 560),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(460, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add Account Type" : "✏️ Edit Account Type",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(420, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 410;

            dlg.Controls.Add(new Label { Text = "Type Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtTypeName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : at.TypeName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtTypeName); y += 45;

            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtTypeNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : at.TypeNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtTypeNameAr); y += 45;

            dlg.Controls.Add(new Label { Text = "Normal Balance *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbNormalBalance = new ComboBox
            {
                Location = new Point(fx, y),
                Size = new Size(fw, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10f)
            };
            cmbNormalBalance.Items.AddRange(new object[] { "Debit", "Credit" });
            if (!isNew) cmbNormalBalance.SelectedItem = at.NormalBalance;
            else cmbNormalBalance.SelectedIndex = 0;
            dlg.Controls.Add(cmbNormalBalance); y += 45;

            dlg.Controls.Add(new Label { Text = "Display Order", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var numDisplayOrder = new NumericUpDown { Location = new Point(fx, y), Size = new Size(fw, 30), Minimum = 0, Maximum = 9999, Value = isNew ? 0 : at.DisplayOrder, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(numDisplayOrder); y += 45;

            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDescription = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 60), Text = isNew ? "" : at.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDescription); y += 75;

            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = at.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive); y += 42;
            }

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(195, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 210, y), Size = new Size(195, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.ClientSize = new Size(460, y + 60);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtTypeName.Text))
                { MessageHelper.ShowWarning("Please enter type name."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var dto = new CreateAccountTypeDTO
                        {
                            TypeName = txtTypeName.Text.Trim(),
                            TypeNameAr = txtTypeNameAr.Text.Trim(),
                            NormalBalance = cmbNormalBalance.SelectedItem?.ToString() ?? "Debit",
                            DisplayOrder = (int)numDisplayOrder.Value,
                            Description = txtDescription.Text.Trim()
                        };
                        if (await ApiHelper.PostAsync<AccountType>("accounttypes", dto) != null)
                        { MessageHelper.ShowSuccess("Account type added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateAccountTypeDTO
                        {
                            AccountTypeID = at.AccountTypeID,
                            TypeName = txtTypeName.Text.Trim(),
                            TypeNameAr = txtTypeNameAr.Text.Trim(),
                            NormalBalance = cmbNormalBalance.SelectedItem?.ToString() ?? at.NormalBalance,
                            DisplayOrder = (int)numDisplayOrder.Value,
                            Description = txtDescription.Text.Trim(),
                            IsActive = chkActive?.Checked ?? true
                        };
                        if (await ApiHelper.PutAsync<AccountType>("accounttypes/" + at.AccountTypeID, dto) != null)
                        { MessageHelper.ShowSuccess("Account type updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
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
                _ = LoadAccountTypes();
        }

        private async void DeleteAccountType(AccountType at)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{at.TypeName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("accounttypes/" + at.AccountTypeID);
                MessageHelper.ShowSuccess("Account type deleted successfully.");
                await LoadAccountTypes();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_accountTypes); return; }
            string s = text.ToLower();
            var filtered = new List<AccountType>();
            foreach (var a in _accountTypes)
                if (a.TypeName.ToLower().Contains(s) ||
                   (a.TypeNameAr != null && a.TypeNameAr.ToLower().Contains(s)) ||
                   (a.NormalBalance != null && a.NormalBalance.ToLower().Contains(s)) ||
                   (a.Description != null && a.Description.ToLower().Contains(s)))
                    filtered.Add(a);
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadAccountTypes();
        }
    }
}