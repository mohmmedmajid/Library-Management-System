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
    public partial class FrmEmployees : Form
    {
        private List<Employee> _employees = new List<Employee>();
        private List<Department> _departments = new List<Department>();

        public FrmEmployees()
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

            dgvEmployees.CellFormatting += DgvEmployees_CellFormatting;
        }

        private void DgvEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int editCol = dgvEmployees.Columns["colEdit"].Index;
            int delCol = dgvEmployees.Columns["colDelete"].Index;

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

        private async void FrmEmployees_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvEmployees.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvEmployees.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadDepartments();
            await LoadEmployees();
        }

        private async System.Threading.Tasks.Task LoadDepartments()
        {
            try
            {
                _departments = await ApiHelper.GetAsync<List<Department>>("departments") ?? new List<Department>();
                cmbFilterDept.Items.Clear();
                cmbFilterDept.Items.Add(new ComboItem(0, "All Departments"));
                foreach (var d in _departments)
                    cmbFilterDept.Items.Add(new ComboItem(d.DepartmentID, d.DepartmentName));
                cmbFilterDept.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadEmployees()
        {
            try
            {
                spinner.Start();
                _employees = await ApiHelper.GetAsync<List<Employee>>("employees") ?? new List<Employee>();
                BindGrid(_employees);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading employees: " + ex.Message);
            }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<Employee> list)
        {
            if (dgvEmployees.Columns.Count == 0)
                InitializeComponent();

            dgvEmployees.Rows.Clear();
            foreach (var emp in list)
            {
                dgvEmployees.Rows.Add(
                    emp.EmployeeID,
                    emp.EmployeeCode,
                    emp.FullName,
                    emp.FullNameAr,
                    emp.DepartmentName,
                    emp.JobTitle,
                    emp.Phone,
                    emp.BasicSalary.ToString("N2"),
                    emp.IsActive ? "✓ Active" : "✗ Inactive",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["colID"].Value);
            var emp = _employees.Find(x => x.EmployeeID == id);
            if (emp == null) return;

            if (e.ColumnIndex == dgvEmployees.Columns["colEdit"].Index)
                OpenEditDialog(emp);
            else if (e.ColumnIndex == dgvEmployees.Columns["colDelete"].Index)
                DeleteEmployee(emp);
        }

        private void OpenEditDialog(Employee emp = null)
        {
            bool isNew = emp == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Employee" : "✏️ Edit Employee",
                Size = new Size(520, 750),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f),
                AutoScroll = true
            };

            var pnlHead = new Panel { Location = new Point(0, 0), Size = new Size(520, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHead.Controls.Add(new Label { Text = isNew ? "➕ Add Employee" : "✏️ Edit Employee", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(480, 28) });
            dlg.Controls.Add(pnlHead);

            int y = 70; int lx = 20; int fx = 20; int fw = 470;

            Action<string> addLabel = (txt) =>
            {
                dlg.Controls.Add(new Label { Text = txt, Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                y += 25;
            };

            // Employee Code
            addLabel("Employee Code *");
            var txtCode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.EmployeeCode, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtCode); y += 45;

            // Full Name
            addLabel("Full Name *");
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.FullName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 45;

            // Arabic Name
            addLabel("Arabic Name");
            var txtNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.FullNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes };
            dlg.Controls.Add(txtNameAr); y += 45;

            // National ID
            addLabel("National ID *");
            var txtNatID = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.NationalID, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtNatID); y += 45;

            // Gender
            addLabel("Gender *");
            var cmbGender = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.SelectedIndex = (!isNew && emp.Gender == "Female") ? 1 : 0;
            dlg.Controls.Add(cmbGender); y += 45;

            // Birth Date
            addLabel("Birth Date *");
            var dtpBirth = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), Format = DateTimePickerFormat.Short };
            dtpBirth.Value = isNew ? DateTime.Now.AddYears(-25) : (emp.BirthDate ?? DateTime.Now.AddYears(-25));
            dlg.Controls.Add(dtpBirth); y += 45;

            // Phone
            addLabel("Phone");
            var txtPhone = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.Phone, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtPhone); y += 45;

            // Email
            addLabel("Email");
            var txtEmail = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.Email, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtEmail); y += 45;

            // Department
            addLabel("Department *");
            var cmbDept = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbDept.Items.Add(new ComboItem(0, "-- Select --"));
            foreach (var d in _departments)
                cmbDept.Items.Add(new ComboItem(d.DepartmentID, d.DepartmentName));
            cmbDept.DisplayMember = "Display";
            cmbDept.ValueMember = "Id";
            cmbDept.SelectedIndex = 0;
            if (!isNew)
                foreach (ComboItem ci in cmbDept.Items)
                    if (ci.Id == emp.DepartmentID) { cmbDept.SelectedItem = ci; break; }
            dlg.Controls.Add(cmbDept); y += 45;

            // Job Title
            addLabel("Job Title *");
            var txtJob = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.JobTitle, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtJob); y += 45;

            // Hire Date
            addLabel("Hire Date *");
            var dtpHire = new DateTimePicker { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), Format = DateTimePickerFormat.Short };
            dtpHire.Value = isNew ? DateTime.Now : (emp.HireDate ?? DateTime.Now);
            dlg.Controls.Add(dtpHire); y += 45;

            // Basic Salary
            addLabel("Basic Salary *");
            var txtSalary = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.BasicSalary.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtSalary); y += 45;

            // Bank Name
            addLabel("Bank Name");
            var txtBank = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.BankName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtBank); y += 45;

            // Bank Account
            addLabel("Bank Account Number");
            var txtBankAcc = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : emp.BankAccountNumber, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtBankAcc); y += 45;

            // Address
            addLabel("Address");
            var txtAddress = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 50), Text = isNew ? "" : emp.Address, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtAddress); y += 65;

            // Status (edit only)
            ComboBox cmbStatus = null;
            if (!isNew)
            {
                addLabel("Status");
                cmbStatus = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), Font = new Font("Segoe UI", 10f), DropDownStyle = ComboBoxStyle.DropDownList };
                cmbStatus.Items.AddRange(new object[] { "Active", "Inactive", "Terminated", "OnLeave" });
                cmbStatus.SelectedItem = emp.Status ?? "Active";
                if (cmbStatus.SelectedIndex < 0) cmbStatus.SelectedIndex = 0;
                dlg.Controls.Add(cmbStatus); y += 45;
            }

            // Active
            var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 30), Checked = isNew || emp.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkActive); y += 42;

            // Buttons
            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(225, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 240, y), Size = new Size(225, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCode.Text)) { MessageHelper.ShowWarning("Please enter employee code."); return; }
                if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageHelper.ShowWarning("Please enter full name."); return; }
                if (string.IsNullOrWhiteSpace(txtNatID.Text)) { MessageHelper.ShowWarning("Please enter national ID."); return; }
                if ((cmbDept.SelectedItem as ComboItem)?.Id == 0) { MessageHelper.ShowWarning("Please select a department."); return; }
                if (string.IsNullOrWhiteSpace(txtJob.Text)) { MessageHelper.ShowWarning("Please enter job title."); return; }
                if (string.IsNullOrWhiteSpace(txtSalary.Text) || !decimal.TryParse(txtSalary.Text, out _)) { MessageHelper.ShowWarning("Please enter a valid salary."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    int deptId = (cmbDept.SelectedItem as ComboItem)?.Id ?? 0;

                    if (isNew)
                    {
                        var dto = new CreateEmployeeDTO
                        {
                            EmployeeCode = txtCode.Text.Trim(),
                            FullName = txtName.Text.Trim(),
                            FullNameAr = txtNameAr.Text.Trim(),
                            NationalID = txtNatID.Text.Trim(),
                            Gender = cmbGender.SelectedItem.ToString(),
                            BirthDate = dtpBirth.Value,
                            Phone = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            DepartmentID = deptId,
                            JobTitle = txtJob.Text.Trim(),
                            HireDate = dtpHire.Value,
                            BasicSalary = decimal.Parse(txtSalary.Text),
                            BankName = txtBank.Text.Trim(),
                            BankAccountNumber = txtBankAcc.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<Employee>("employees", dto) != null)
                        { MessageHelper.ShowSuccess("Employee added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateEmployeeDTO
                        {
                            EmployeeID = emp.EmployeeID,
                            EmployeeCode = txtCode.Text.Trim(),
                            FullName = txtName.Text.Trim(),
                            FullNameAr = txtNameAr.Text.Trim(),
                            NationalID = txtNatID.Text.Trim(),
                            Gender = cmbGender.SelectedItem.ToString(),
                            BirthDate = dtpBirth.Value,
                            Phone = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            DepartmentID = deptId,
                            JobTitle = txtJob.Text.Trim(),
                            BasicSalary = decimal.Parse(txtSalary.Text),
                            BankName = txtBank.Text.Trim(),
                            BankAccountNumber = txtBankAcc.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            Status = cmbStatus != null ? cmbStatus.SelectedItem.ToString() : emp.Status,
                            IsActive = chkActive.Checked
                        };
                        if (await ApiHelper.PutAsync<Employee>("employees/" + emp.EmployeeID, dto) != null)
                        { MessageHelper.ShowSuccess("Employee updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            dlg.Height = y + 120;
            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadEmployees();
        }

        private async void DeleteEmployee(Employee emp)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{emp.FullName}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("employees/" + emp.EmployeeID);
                MessageHelper.ShowSuccess("Employee deleted successfully.");
                await LoadEmployees();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            ApplyFilters();
        }

        private void cmbFilterDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string search = searchBox.SearchText.ToLower();
            int deptId = (cmbFilterDept.SelectedItem as ComboItem)?.Id ?? 0;
            string status = cmbFilterStatus.SelectedItem?.ToString() ?? "All";

            var filtered = new List<Employee>();
            foreach (var emp in _employees)
            {
                bool matchSearch = string.IsNullOrEmpty(search) ||
                    emp.EmployeeCode.ToLower().Contains(search) ||
                    emp.FullName.ToLower().Contains(search) ||
                    (emp.FullNameAr != null && emp.FullNameAr.ToLower().Contains(search)) ||
                    (emp.JobTitle != null && emp.JobTitle.ToLower().Contains(search)) ||
                    (emp.Phone != null && emp.Phone.ToLower().Contains(search));

                bool matchDept = deptId == 0 || emp.DepartmentID == deptId;

                bool matchStatus = status == "All" ||
                    (status == "Active" && emp.IsActive) ||
                    (status == "Inactive" && !emp.IsActive);

                if (matchSearch && matchDept && matchStatus)
                    filtered.Add(emp);
            }
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbFilterDept.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            await LoadEmployees();
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