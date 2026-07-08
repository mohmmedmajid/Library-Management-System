using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmCustomers : Form
    {
        private List<Customer> _customers = new List<Customer>();

        public FrmCustomers()
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

            dgvCustomers.CellFormatting += DgvCustomers_CellFormatting;
        }

        private void DgvCustomers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvCustomers.Columns["colEdit"].Index;
            int delCol = dgvCustomers.Columns["colDelete"].Index;
            int transCol = dgvCustomers.Columns["colTransactions"].Index;
            int debtCol = dgvCustomers.Columns["colTotalDebt"].Index;
            int statusCol = dgvCustomers.Columns["colStatus"].Index;

            if (e.ColumnIndex == transCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(100, 60, 160);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(80, 40, 140);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == editCol)
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
            else if (e.ColumnIndex == debtCol && e.RowIndex >= 0)
            {

                var val = dgvCustomers.Rows[e.RowIndex].Cells["colTotalDebt"].Value?.ToString() ?? "0.00";
                if (decimal.TryParse(val, out decimal debt) && debt > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
            }
        }

        private async void FrmCustomers_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin || SessionManager.IsCashier;
            dgvCustomers.Columns["colEdit"].Visible = SessionManager.IsAdmin || SessionManager.IsCashier;
            dgvCustomers.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadCustomers();
        }

        private async System.Threading.Tasks.Task LoadCustomers()
        {
            try
            {
                spinner.Start();
                _customers = await ApiHelper.GetAsync<List<Customer>>("customers")
                             ?? new List<Customer>();
                BindGrid(_customers);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading customers: " + ex.Message); }
            finally { spinner.Stop(); }
        }


        private void BindGrid(List<Customer> list)
        {
            dgvCustomers.Rows.Clear();
            foreach (var c in list)
            {
                dgvCustomers.Rows.Add(
                    c.CustomerID,
                    c.CustomerName,
                    c.Phone,
                    c.Email,
                    c.TotalPurchases.ToString("F2"),
                    c.TotalBorrowings,
                    c.TotalDebt.ToString("F2"),
                    c.TotalLateFees.ToString("F2"),
                    c.IsActive ? "✓ Active" : "✗ Inactive",
                    "📋 Transactions",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["colCustomerID"].Value);
            var customer = _customers.Find(c => c.CustomerID == id);
            if (customer == null) return;

            if (e.ColumnIndex == dgvCustomers.Columns["colTransactions"].Index)
            { OpenTransactions(customer); return; }

            if (e.ColumnIndex == dgvCustomers.Columns["colEdit"].Index &&
                (SessionManager.IsAdmin || SessionManager.IsCashier))
            { OpenEditDialog(customer); return; }

            if (e.ColumnIndex == dgvCustomers.Columns["colDelete"].Index && SessionManager.IsAdmin)
                DeleteCustomer(customer);
        }

        private void OpenTransactions(Customer customer)
        {
            var frm = new FrmCustomerTransactions(customer.CustomerID, customer.CustomerName);
            frm.ShowDialog(this);
        }

        private void OpenEditDialog(Customer customer = null)
        {
            bool isNew = customer == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Customer" : "✏️ Edit Customer",
                Size = new Size(480, 480),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(480, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label
            {
                Text = isNew ? "➕ Add Customer" : "✏️ Edit Customer",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(450, 28)
            });
            dlg.Controls.Add(pnlHeader);

            int y = 68; int lx = 20; int fx = 20; int fw = 430;

            dlg.Controls.Add(new Label { Text = "Customer Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = customer?.CustomerName ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 44;

            dlg.Controls.Add(new Label { Text = "Phone", Location = new Point(lx, y), Size = new Size(200, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Email", Location = new Point(235, y), Size = new Size(215, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtPhone = new TextBox { Location = new Point(fx, y), Size = new Size(200, 30), Text = customer?.Phone ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtPhone);
            var txtEmail = new TextBox { Location = new Point(235, y), Size = new Size(215, 30), Text = customer?.Email ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtEmail); y += 44;

            dlg.Controls.Add(new Label { Text = "Address", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtAddress = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 55), Text = customer?.Address ?? "", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtAddress); y += 68;

            CheckBox chkActive = null;
            if (!isNew)
            {
                chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 28), Checked = customer.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
                dlg.Controls.Add(chkActive); y += 40;
            }

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(205, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 220, y), Size = new Size(205, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.Size = new Size(480, y + 100);

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter customer name."); return; }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidationHelper.IsValidEmail(txtEmail.Text))
                { MessageHelper.ShowWarning("Please enter a valid email address."); return; }

                if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !ValidationHelper.IsValidPhone(txtPhone.Text))
                { MessageHelper.ShowWarning("Please enter a valid phone number."); return; }

                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";

                    if (isNew)
                    {
                        var dto = new CreateCustomerDTO
                        {
                            CustomerName = txtName.Text.Trim(),
                            Phone = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            CreatedBy = SessionManager.UserId
                        };
                        if (await ApiHelper.PostAsync<Customer>("customers", dto) != null)
                        { MessageHelper.ShowSuccess("Customer added successfully!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateCustomerDTO
                        {
                            CustomerID = customer.CustomerID,
                            CustomerName = txtName.Text.Trim(),
                            Phone = txtPhone.Text.Trim(),
                            Email = txtEmail.Text.Trim(),
                            Address = txtAddress.Text.Trim(),
                            IsActive = chkActive?.Checked ?? true
                        };
                        if (await ApiHelper.PutAsync<Customer>("customers/" + customer.CustomerID, dto) != null)
                        { MessageHelper.ShowSuccess("Customer updated successfully!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex)
                { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadCustomers();
        }


        private async void DeleteCustomer(Customer customer)
        {
            if (customer.TotalDebt > 0)
            { MessageHelper.ShowWarning($"Cannot delete \"{customer.CustomerName}\".\nCustomer has an outstanding debt of {customer.TotalDebt:F2}."); return; }

            if (!MessageHelper.ShowConfirm($"Delete \"{customer.CustomerName}\"?\nThis action cannot be undone.")) return;

            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("customers/" + customer.CustomerID);
                MessageHelper.ShowSuccess("Customer deleted successfully.");
                await LoadCustomers();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_customers); return; }
            string s = text.ToLower();
            var filtered = new List<Customer>();
            foreach (var c in _customers)
                if (c.CustomerName.ToLower().Contains(s) ||
                   (!string.IsNullOrEmpty(c.Phone) && c.Phone.ToLower().Contains(s)) ||
                   (!string.IsNullOrEmpty(c.Email) && c.Email.ToLower().Contains(s)))
                    filtered.Add(c);
            BindGrid(filtered);
        }

        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadCustomers();
        }
    }
}