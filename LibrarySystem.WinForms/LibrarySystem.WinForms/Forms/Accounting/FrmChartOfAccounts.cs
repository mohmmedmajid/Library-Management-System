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
    public partial class FrmChartOfAccounts : Form
    {
        private List<ChartOfAccount> _accounts = new List<ChartOfAccount>();
        private List<AccountType> _accountTypes = new List<AccountType>();

        public FrmChartOfAccounts()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(585, 18);
            spinner.Size = new Size(30, 30);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(625, 15);
            searchBox.Size = new Size(220, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);

            dgvAccounts.CellFormatting += DgvAccounts_CellFormatting;
        }

        private void DgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAccounts.Columns["colEdit"] == null || dgvAccounts.Columns["colDelete"] == null) return;

            int editCol = dgvAccounts.Columns["colEdit"].Index;
            int delCol = dgvAccounts.Columns["colDelete"].Index;

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

        private async void FrmChartOfAccounts_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvAccounts.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvAccounts.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadAccountTypes();
            await LoadAccounts();
        }

        private async System.Threading.Tasks.Task LoadAccountTypes()
        {
            try
            {
                _accountTypes = await ApiHelper.GetAsync<List<AccountType>>("accounttypes")
                                ?? new List<AccountType>();

                if (IsDisposed) return;

                cmbFilterType.Items.Clear();
                cmbFilterType.Items.Add("All Types");
                foreach (var t in _accountTypes)
                    cmbFilterType.Items.Add(t.TypeName);
                cmbFilterType.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadAccounts()
        {
            try
            {
                if (IsDisposed) return;
                spinner.Start();
                _accounts = await ApiHelper.GetAsync<List<ChartOfAccount>>("chartofaccounts")
                            ?? new List<ChartOfAccount>();
                if (IsDisposed) return;
                BindGrid(_accounts);
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                    MessageHelper.ShowError("Error loading accounts: " + ex.Message);
            }
            finally
            {
                if (!IsDisposed) spinner.Stop();
            }
        }

        private void BindGrid(List<ChartOfAccount> list)
        {
            if (IsDisposed || dgvAccounts.IsDisposed) return;
            if (dgvAccounts.Columns.Count == 0) return;

            dgvAccounts.Rows.Clear();
            foreach (var a in list)
            {
                dgvAccounts.Rows.Add(
                    a.AccountID,
                    a.AccountCode,
                    a.IndentedName != null && a.IndentedName.Length > 0 ? a.IndentedName : a.AccountName,
                    a.AccountNameAr,
                    a.TypeName,
                    a.NormalBalance,
                    a.Level,
                    a.IsParent ? "📁 Parent" : "📄 Leaf",
                    a.AllowPosting ? "✓" : "✗",
                    a.CurrentBalance.ToString("N2"),
                    a.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvAccounts.Rows[e.RowIndex].Cells["colID"].Value);
            var item = _accounts.Find(x => x.AccountID == id);
            if (item == null) return;

            if (e.ColumnIndex == dgvAccounts.Columns["colEdit"].Index)
                OpenEditDialog(item);
            else if (e.ColumnIndex == dgvAccounts.Columns["colDelete"].Index)
                DeleteAccount(item);
        }

        private void OpenEditDialog(ChartOfAccount acc = null)
        {
            bool isNew = acc == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Account" : "✏️ Edit Account",
                Size = new Size(500, 660),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(500, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add Account" : "✏️ Edit Account",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(460, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 70; int lx = 20; int fx = 20; int fw = 450;

            dlg.Controls.Add(new Label { Text = "Account Code *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtCode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : acc.AccountCode, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            if (!isNew) txtCode.ReadOnly = true;
            dlg.Controls.Add(txtCode); y += 45;

            dlg.Controls.Add(new Label { Text = "Account Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : acc.AccountName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 45;

            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : acc.AccountNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtNameAr); y += 45;

            dlg.Controls.Add(new Label { Text = "Account Type *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbType = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10f) };
            foreach (var t in _accountTypes) cmbType.Items.Add(t);
            cmbType.DisplayMember = "TypeName";
            cmbType.ValueMember = "AccountTypeID";
            if (!isNew) cmbType.SelectedValue = acc.AccountTypeID;
            else if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0;
            dlg.Controls.Add(cmbType); y += 45;

            dlg.Controls.Add(new Label { Text = "Parent Account", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbParent = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10f) };
            cmbParent.Items.Add(new ChartOfAccount { AccountID = 0, AccountName = "-- None (Root) --" });
            foreach (var a in _accounts)
                if (isNew || a.AccountID != acc.AccountID)
                    cmbParent.Items.Add(a);
            cmbParent.DisplayMember = "AccountName";
            cmbParent.ValueMember = "AccountID";
            if (!isNew && acc.ParentAccountID.HasValue && acc.ParentAccountID.Value > 0)
                cmbParent.SelectedValue = acc.ParentAccountID.Value;
            else
                cmbParent.SelectedIndex = 0;
            dlg.Controls.Add(cmbParent); y += 45;

            dlg.Controls.Add(new Label { Text = "Level", Location = new Point(lx, y), Size = new Size(100, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            var numLevel = new NumericUpDown { Location = new Point(fx, y + 22), Size = new Size(100, 30), Minimum = 1, Maximum = 10, Value = isNew ? 1 : at_least_one(acc.Level), Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(numLevel);

            var chkIsParent = new CheckBox { Text = "Is Parent Account", Location = new Point(fx + 120, y + 22), Size = new Size(200, 30), Checked = !isNew && acc.IsParent, Font = new Font("Segoe UI", 10f), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkIsParent);

            var chkAllowPosting = new CheckBox { Text = "Allow Posting", Location = new Point(fx + 330, y + 22), Size = new Size(150, 30), Checked = isNew || acc.AllowPosting, Font = new Font("Segoe UI", 10f), Cursor = Cursors.Hand, ForeColor = Color.FromArgb(40, 160, 100) };
            dlg.Controls.Add(chkAllowPosting);
            y += 55;

            if (isNew)
            {
                dlg.Controls.Add(new Label { Text = "Opening Balance", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 25;
                var txtOpening = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = "0.00", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Name = "txtOpening" };
                dlg.Controls.Add(txtOpening); y += 45;
                txtOpening.Leave += (s, ev) =>
                {
                    if (decimal.TryParse(txtOpening.Text, out decimal val)) txtOpening.Text = val.ToString("0.00");
                    else txtOpening.Text = "0.00";
                };
            }

            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDesc = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 55), Text = isNew ? "" : acc.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDesc); y += 68;

            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = acc.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive); y += 42;
            }

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(215, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 230, y), Size = new Size(215, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.ClientSize = new Size(490, y + 60);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                { MessageHelper.ShowWarning("Please enter account code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter account name."); return; }
                if (cmbType.SelectedItem == null)
                { MessageHelper.ShowWarning("Please select account type."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    int typeId = ((AccountType)cmbType.SelectedItem).AccountTypeID;
                    int parentId = cmbParent.SelectedIndex > 0 ? ((ChartOfAccount)cmbParent.SelectedItem).AccountID : 0;

                    if (isNew)
                    {
                        decimal ob = 0;
                        var obTxt = dlg.Controls["txtOpening"] as TextBox;
                        if (obTxt != null) decimal.TryParse(obTxt.Text, out ob);

                        var dto = new CreateChartOfAccountDTO
                        {
                            AccountCode = txtCode.Text.Trim(),
                            AccountName = txtName.Text.Trim(),
                            AccountNameAr = txtNameAr.Text.Trim(),
                            AccountTypeID = typeId,
                            ParentAccountID = parentId,
                            Level = (int)numLevel.Value,
                            IsParent = chkIsParent.Checked,
                            OpeningBalance = ob,
                            AllowPosting = chkAllowPosting.Checked,
                            Description = txtDesc.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<ChartOfAccount>("chartofaccounts", dto) != null)
                        { MessageHelper.ShowSuccess("Account added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateChartOfAccountDTO
                        {
                            AccountID = acc.AccountID,
                            AccountCode = txtCode.Text.Trim(),
                            AccountName = txtName.Text.Trim(),
                            AccountNameAr = txtNameAr.Text.Trim(),
                            AccountTypeID = typeId,
                            AllowPosting = chkAllowPosting.Checked,
                            Description = txtDesc.Text.Trim(),
                            IsActive = chkActive?.Checked ?? true
                        };
                        if (await ApiHelper.PutAsync<ChartOfAccount>("chartofaccounts/" + acc.AccountID, dto) != null)
                        { MessageHelper.ShowSuccess("Account updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
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
                _ = LoadAccounts();
        }

        private int at_least_one(int val) => val < 1 ? 1 : val;

        private async void DeleteAccount(ChartOfAccount acc)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{acc.AccountName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("chartofaccounts/" + acc.AccountID);
                MessageHelper.ShowSuccess("Account deleted successfully.");
                await LoadAccounts();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { if (!IsDisposed) spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            ApplyFilters(text, cmbFilterType.SelectedIndex);
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters(searchBox.Text, cmbFilterType.SelectedIndex);
        }

        private void ApplyFilters(string searchText, int typeIndex)
        {
            var filtered = new List<ChartOfAccount>();
            string s = searchText?.ToLower() ?? "";

            foreach (var a in _accounts)
            {
                bool matchSearch = string.IsNullOrEmpty(s) ||
                    a.AccountCode.ToLower().Contains(s) ||
                    a.AccountName.ToLower().Contains(s) ||
                    (a.AccountNameAr != null && a.AccountNameAr.ToLower().Contains(s));

                bool matchType = typeIndex <= 0 ||
                    (typeIndex - 1 < _accountTypes.Count && a.TypeName == _accountTypes[typeIndex - 1].TypeName);

                if (matchSearch && matchType)
                    filtered.Add(a);
            }
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbFilterType.SelectedIndex = 0;
            await LoadAccounts();
        }

        private void lblCount_Click(object sender, EventArgs e)
        {

        }
    }
}