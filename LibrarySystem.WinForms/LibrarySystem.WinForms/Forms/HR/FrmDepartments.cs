using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Accounting;
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
    public partial class FrmDepartments : Form
    {
        private List<Department> _departments = new List<Department>();
        private List<CostCenter> _costCenters = new List<CostCenter>();
        private List<Employee> _managers = new List<Employee>();

        public FrmDepartments()
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

            dgvDepartments.CellFormatting += DgvDepartments_CellFormatting;
        }


        private void DgvDepartments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvDepartments.Columns["colEdit"].Index;
            int delCol = dgvDepartments.Columns["colDelete"].Index;

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


        private async void FrmDepartments_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvDepartments.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvDepartments.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadLookups();
            await LoadDepartments();
        }

        private async System.Threading.Tasks.Task LoadLookups()
        {
            try
            {
                _costCenters = await ApiHelper.GetAsync<List<CostCenter>>("costcenters") ?? new List<CostCenter>();
                _managers = await ApiHelper.GetAsync<List<Employee>>("employees") ?? new List<Employee>();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadDepartments()
        {
            try
            {
                spinner.Start();
                var data = await ApiHelper.GetAsync<List<Department>>("departments")
                               ?? new List<Department>();
                if (dgvDepartments.IsDisposed) return;
                _departments = data;
                BindGrid(_departments);
            }
            catch (Exception ex)
            {
                if (!dgvDepartments.IsDisposed)
                    MessageHelper.ShowError("Error loading departments: " + ex.Message);
            }
            finally { if (!IsDisposed) spinner.Stop(); }
        }


        private void BindGrid(List<Department> list)
        {
            if (dgvDepartments.IsDisposed || dgvDepartments.Columns.Count == 0) return;

            dgvDepartments.Rows.Clear();
            foreach (var d in list)
            {
                dgvDepartments.Rows.Add(
                    d.DepartmentID,
                    d.DepartmentCode,
                    d.DepartmentName,
                    d.DepartmentNameAr,
                    d.ManagerName,
                    d.CostCenterName,
                    d.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvDepartments.Rows[e.RowIndex].Cells["colID"].Value);
            var dep = _departments.Find(x => x.DepartmentID == id);
            if (dep == null) return;

            if (e.ColumnIndex == dgvDepartments.Columns["colEdit"].Index)
                OpenEditDialog(dep);
            else if (e.ColumnIndex == dgvDepartments.Columns["colDelete"].Index)
                DeleteDepartment(dep);
        }

        private void OpenEditDialog(Department dep = null)
        {
            bool isNew = dep == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Department" : "✏️ Edit Department",
                Size = new Size(460, 560),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(460, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = isNew ? "➕ Add Department" : "✏️ Edit Department", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(420, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int lx = 20; int fx = 20; int fw = 410;

            dlg.Controls.Add(new Label { Text = "Department Code *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtCode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : dep.DepartmentCode, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtCode); y += 45;

            dlg.Controls.Add(new Label { Text = "Department Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : dep.DepartmentName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 45;

            dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : dep.DepartmentNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtNameAr); y += 45;

            dlg.Controls.Add(new Label { Text = "Manager", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbManager = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbManager.Items.Add(new ComboItem(0, "-- None --"));
            foreach (var m in _managers)
                cmbManager.Items.Add(new ComboItem(m.EmployeeID, m.FullName));
            cmbManager.DisplayMember = "Display";
            cmbManager.ValueMember = "Id";
            cmbManager.SelectedIndex = 0;
            if (!isNew)
                foreach (ComboItem ci in cmbManager.Items)
                    if (ci.Id == dep.ManagerID) { cmbManager.SelectedItem = ci; break; }
            dlg.Controls.Add(cmbManager); y += 45;

            dlg.Controls.Add(new Label { Text = "Cost Center", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var cmbCC = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCC.Items.Add(new ComboItem(0, "-- None --"));
            foreach (var cc in _costCenters)
                cmbCC.Items.Add(new ComboItem(cc.CostCenterID, cc.CostCenterName));
            cmbCC.ValueMember = "Id";
            cmbCC.DisplayMember = "Display";
            cmbCC.SelectedIndex = 0;
            if (!isNew)
                foreach (ComboItem ci in cmbCC.Items)
                    if (ci.Id == dep.CostCenterID) { cmbCC.SelectedItem = ci; break; }
            dlg.Controls.Add(cmbCC); y += 45;

            dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 25;
            var txtDesc = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : dep.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtDesc); y += 65;

            var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = isNew || dep.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkActive); y += 42;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(195, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 210, y), Size = new Size(195, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text))
                { MessageHelper.ShowWarning("Please enter department code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter department name."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    int managerId = (cmbManager.SelectedItem as ComboItem)?.Id ?? 0;
                    int ccId = (cmbCC.SelectedItem as ComboItem)?.Id ?? 0;

                    if (isNew)
                    {
                        var dto = new CreateDepartmentDTO
                        {
                            DepartmentCode = txtCode.Text.Trim(),
                            DepartmentName = txtName.Text.Trim(),
                            DepartmentNameAr = txtNameAr.Text.Trim(),
                            ManagerID = managerId,
                            CostCenterID = ccId,
                            Description = txtDesc.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<Department>("departments", dto) != null)
                        { MessageHelper.ShowSuccess("Department added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateDepartmentDTO
                        {
                            DepartmentID = dep.DepartmentID,
                            DepartmentCode = txtCode.Text.Trim(),
                            DepartmentName = txtName.Text.Trim(),
                            DepartmentNameAr = txtNameAr.Text.Trim(),
                            ManagerID = managerId,
                            CostCenterID = ccId,
                            Description = txtDesc.Text.Trim(),
                            IsActive = chkActive.Checked
                        };
                        if (await ApiHelper.PutAsync<Department>("departments/" + dep.DepartmentID, dto) != null)
                        { MessageHelper.ShowSuccess("Department updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 110;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadDepartments();
        }


        private async void DeleteDepartment(Department dep)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{dep.DepartmentName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("departments/" + dep.DepartmentID);
                MessageHelper.ShowSuccess("Department deleted successfully.");
                await LoadDepartments();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }


        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_departments); return; }
            string s = text.ToLower();
            var filtered = new List<Department>();
            foreach (var d in _departments)
                if (d.DepartmentCode.ToLower().Contains(s) ||
                    d.DepartmentName.ToLower().Contains(s) ||
                   (d.DepartmentNameAr != null && d.DepartmentNameAr.ToLower().Contains(s)) ||
                   (d.ManagerName != null && d.ManagerName.ToLower().Contains(s)) ||
                   (d.CostCenterName != null && d.CostCenterName.ToLower().Contains(s)))
                    filtered.Add(d);
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadDepartments();
        }


        private class ComboItem
        {
            public int Id { get; }
            public string Display { get; }
            public ComboItem(int id, string display) { Id = id; Display = display; }
            public override string ToString() => Display;
        }
    }
}