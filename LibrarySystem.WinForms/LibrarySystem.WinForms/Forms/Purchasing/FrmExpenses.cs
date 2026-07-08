using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmExpenses : Form
    {
        private List<Expense> _allExpenses = new List<Expense>();
        private int _selectedExpenseId = 0;
        private bool _suppressDateEvents = false;

        public FrmExpenses()
        {
            InitializeComponent();
        }

        private async void FrmExpenses_Load(object sender, EventArgs e)
        {
            _suppressDateEvents = true;
            dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpTo.Value = DateTime.Today;
            _suppressDateEvents = false;

            await LoadExpensesAsync();
        }

        // منع From من تجاوز To
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (_suppressDateEvents) return;

            if (dtpFrom.Value.Date > dtpTo.Value.Date)
            {
                _suppressDateEvents = true;
                dtpTo.Value = dtpFrom.Value.Date;
                _suppressDateEvents = false;
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (_suppressDateEvents) return;

            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                _suppressDateEvents = true;
                dtpFrom.Value = dtpTo.Value.Date;
                _suppressDateEvents = false;
            }
        }

        private async Task LoadExpensesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string start = dtpFrom.Value.ToString("yyyy-MM-dd");
                string end = dtpTo.Value.ToString("yyyy-MM-dd");
                string status = cmbFilter.SelectedIndex == 1 ? "Paid"
                              : cmbFilter.SelectedIndex == 2 ? "Pending" : "";

                string url = $"Expenses?startDate={start}&endDate={end}";
                if (!string.IsNullOrEmpty(status))
                    url += $"&status={status}";

                _allExpenses = await ApiHelper.GetAsync<List<Expense>>(url) ?? new List<Expense>();

                ApplySearchFilter();
                UpdateStats();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading expenses: " + ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ApplySearchFilter()
        {
            string search = txtSearch.Text.Trim().ToLower();

            var filtered = string.IsNullOrEmpty(search)
                ? _allExpenses
                : _allExpenses.Where(e =>
                    e.CategoryName.ToLower().Contains(search) ||
                    e.SupplierName.ToLower().Contains(search) ||
                    e.ReferenceNumber.ToLower().Contains(search) ||
                    e.ReceiptNumber.ToLower().Contains(search) ||
                    e.Description.ToLower().Contains(search)).ToList();

            dgvExpenses.DataSource = null;
            dgvExpenses.DataSource = filtered;

            foreach (DataGridViewRow row in dgvExpenses.Rows)
            {
                if (row.DataBoundItem is Expense exp)
                {
                    if (exp.Status == "Paid")
                        row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                    else if (exp.Status == "Pending")
                        row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(192, 57, 43);
                }
            }

            lblCount.Text = $"Total: {filtered.Count} expenses";
            ResetSelection();
        }

        private void UpdateStats()
        {
            decimal totalAmount = _allExpenses.Sum(e => e.Amount);
            decimal paidAmount = _allExpenses.Where(e => e.Status == "Paid").Sum(e => e.Amount);
            decimal pendingAmount = _allExpenses.Where(e => e.Status == "Pending").Sum(e => e.Amount);

            lblStatTotal.Text = $"Total Expenses: {totalAmount:N2}";
            lblStatPaid.Text = $"Paid: {paidAmount:N2}";
            lblStatPending.Text = $"Pending: {pendingAmount:N2}";
        }

        private void ResetSelection()
        {
            _selectedExpenseId = 0;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvExpenses.Rows[e.RowIndex].DataBoundItem is Expense exp)
            {
                _selectedExpenseId = exp.ExpenseID;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void dgvExpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEdit_Click(sender, e);
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmExpenseDialog())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadExpensesAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedExpenseId == 0) { MessageHelper.ShowWarning("Please select an expense first."); return; }
            var exp = _allExpenses.FirstOrDefault(x => x.ExpenseID == _selectedExpenseId);
            if (exp == null) return;

            using (var frm = new FrmExpenseDialog(exp))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadExpensesAsync();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedExpenseId == 0) { MessageHelper.ShowWarning("Please select an expense first."); return; }
            if (!MessageHelper.ShowConfirm("Are you sure you want to delete this expense?")) return;

            try
            {
                bool ok = await ApiHelper.DeleteAsync($"Expenses/{_selectedExpenseId}");
                if (ok) { MessageHelper.ShowSuccess("Expense deleted successfully."); await LoadExpensesAsync(); }
                else { MessageHelper.ShowError("Failed to delete expense."); }
            }
            catch (Exception ex) { MessageHelper.ShowError(ex.Message); }
        }

        private async void btnRefresh_Click(object sender, EventArgs e) => await LoadExpensesAsync();
        private async void btnSearchDate_Click(object sender, EventArgs e) => await LoadExpensesAsync();
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplySearchFilter();
        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => await LoadExpensesAsync();
    }
}