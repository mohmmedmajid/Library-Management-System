using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.HR;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.HR
{
    public partial class FrmSalaryComponents : Form
    {
        private List<SalaryComponent> _components = new List<SalaryComponent>();

        public FrmSalaryComponents()
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

            dgvComponents.CellFormatting += DgvComponents_CellFormatting;
        }

        private void DgvComponents_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int editCol = dgvComponents.Columns["colEdit"].Index;
            int delCol = dgvComponents.Columns["colDelete"].Index;

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

        private async void FrmSalaryComponents_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvComponents.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvComponents.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadComponents();
        }

        private async System.Threading.Tasks.Task LoadComponents()
        {
            try
            {
                spinner.Start();
                _components = await ApiHelper.GetAsync<List<SalaryComponent>>("salarycomponents")
                              ?? new List<SalaryComponent>();
                BindGrid(_components);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading salary components: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<SalaryComponent> list)
        {
            dgvComponents.Rows.Clear();
            foreach (var c in list)
            {
                dgvComponents.Rows.Add(
                    c.ComponentID,
                    c.ComponentCode,
                    c.ComponentName,
                    c.ComponentNameAr,
                    c.ComponentType,
                    c.IsFixed ? "Fixed" : "Variable",
                    c.IsTaxable ? "Yes" : "No",
                    c.DefaultAmount.ToString("N2"),
                    c.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );

                int row = dgvComponents.Rows.Count - 1;
                if (c.ComponentType == "Addition")
                    dgvComponents.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                else if (c.ComponentType == "Deduction")
                    dgvComponents.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(200, 50, 50);
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvComponents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvComponents.Rows[e.RowIndex].Cells["colID"].Value);
            var comp = _components.Find(x => x.ComponentID == id);
            if (comp == null) return;

            if (e.ColumnIndex == dgvComponents.Columns["colEdit"].Index)
                OpenEditDialog(comp);
            else if (e.ColumnIndex == dgvComponents.Columns["colDelete"].Index)
                DeleteComponent(comp);
        }

        private void OpenEditDialog(SalaryComponent comp = null)
        {
            bool isNew = comp == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Salary Component" : "✏️ Edit Salary Component",
                Size = new Size(480, 580),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(480, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = isNew ? "➕ Add Salary Component" : "✏️ Edit Salary Component", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(450, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int lx = 20; int fx = 20; int fw = 430;

            Action<string> addLabel = (txt) =>
            {
                dlg.Controls.Add(new Label { Text = txt, Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 25;
            };

            addLabel("Component Code *");
            var txtCode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : comp.ComponentCode, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtCode); y += 45;

            addLabel("Component Name *");
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : comp.ComponentName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 45;

            addLabel("Arabic Name");
            var txtNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : comp.ComponentNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtNameAr); y += 45;

            addLabel("Component Type *");
            var cmbType = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbType.Items.AddRange(new object[] { "Addition", "Deduction" });
            cmbType.SelectedIndex = (!isNew && comp.ComponentType == "Deduction") ? 1 : 0;
            dlg.Controls.Add(cmbType); y += 45;

            addLabel("Default Amount");
            var txtAmount = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "0" : comp.DefaultAmount.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtAmount); y += 45;

            addLabel("Description");
            var txtDesc = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : comp.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDesc); y += 65;

            var chkFixed = new CheckBox { Text = "Fixed Amount", Location = new Point(fx, y), Size = new Size(200, 28), Checked = isNew || comp.IsFixed, Font = new Font("Segoe UI", 10f), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkFixed);

            var chkTaxable = new CheckBox { Text = "Taxable", Location = new Point(fx + 215, y), Size = new Size(200, 28), Checked = isNew || comp.IsTaxable, Font = new Font("Segoe UI", 10f), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkTaxable); y += 38;

            var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = isNew || comp.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkActive); y += 42;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(205, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 220, y), Size = new Size(205, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text)) { MessageHelper.ShowWarning("Please enter component code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageHelper.ShowWarning("Please enter component name."); return; }
                if (!decimal.TryParse(txtAmount.Text, out _)) { MessageHelper.ShowWarning("Please enter a valid amount."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateSalaryComponentDTO
                        {
                            ComponentCode = txtCode.Text.Trim(),
                            ComponentName = txtName.Text.Trim(),
                            ComponentNameAr = txtNameAr.Text.Trim(),
                            ComponentType = cmbType.SelectedItem.ToString(),
                            IsFixed = chkFixed.Checked,
                            IsTaxable = chkTaxable.Checked,
                            DefaultAmount = decimal.Parse(txtAmount.Text),
                            Description = txtDesc.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<SalaryComponent>("salarycomponents", dto) != null)
                        { MessageHelper.ShowSuccess("Salary component added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateSalaryComponentDTO
                        {
                            ComponentID = comp.ComponentID,
                            ComponentCode = txtCode.Text.Trim(),
                            ComponentName = txtName.Text.Trim(),
                            ComponentNameAr = txtNameAr.Text.Trim(),
                            ComponentType = cmbType.SelectedItem.ToString(),
                            IsFixed = chkFixed.Checked,
                            IsTaxable = chkTaxable.Checked,
                            DefaultAmount = decimal.Parse(txtAmount.Text),
                            Description = txtDesc.Text.Trim(),
                            IsActive = chkActive.Checked
                        };
                        if (await ApiHelper.PutAsync<SalaryComponent>("salarycomponents/" + comp.ComponentID, dto) != null)
                        { MessageHelper.ShowSuccess("Salary component updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 110;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadComponents();
        }

        private async void DeleteComponent(SalaryComponent comp)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{comp.ComponentName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("salarycomponents/" + comp.ComponentID);
                MessageHelper.ShowSuccess("Salary component deleted successfully.");
                await LoadComponents();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            ApplyFilters();
        }

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string search = searchBox.SearchText.ToLower();
            string type = cmbFilterType.SelectedItem?.ToString() ?? "All";

            var filtered = new List<SalaryComponent>();
            foreach (var c in _components)
            {
                bool matchSearch = string.IsNullOrEmpty(search) ||
                    c.ComponentCode.ToLower().Contains(search) ||
                    c.ComponentName.ToLower().Contains(search) ||
                    (c.ComponentNameAr != null && c.ComponentNameAr.ToLower().Contains(search));

                bool matchType = type == "All" || c.ComponentType == type;

                if (matchSearch && matchType)
                    filtered.Add(c);
            }
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbFilterType.SelectedIndex = 0;
            await LoadComponents();
        }
    }
}