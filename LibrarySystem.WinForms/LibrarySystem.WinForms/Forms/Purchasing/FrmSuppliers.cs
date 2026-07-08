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
    public partial class FrmSuppliers : Form
    {
        private List<Supplier> _allSuppliers = new List<Supplier>();
        private int _selectedSupplierID = 0;

        public FrmSuppliers()
        {
            InitializeComponent();
        }


        private async void FrmSuppliers_Load(object sender, EventArgs e)
        {
            await LoadStatisticsAsync();
            await LoadSuppliersAsync();
        }


        private async Task LoadSuppliersAsync()
        {
            try
            {
                SetLoading(true);

                bool? isActive = null;
                if (cmbFilter.SelectedIndex == 1) isActive = true;
                else if (cmbFilter.SelectedIndex == 2) isActive = false;

                string endpoint = "Suppliers";
                if (isActive.HasValue)
                    endpoint += "?isActive=" + isActive.Value.ToString().ToLower();

                _allSuppliers = await ApiHelper.GetAsync<List<Supplier>>(endpoint);

                if (_allSuppliers == null)
                    _allSuppliers = new List<Supplier>();

                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load suppliers.\n" + ex.Message);
            }
            finally
            {
                SetLoading(false);
            }
        }

        private async Task LoadStatisticsAsync()
        {
            try
            {
                var stats = await ApiHelper.GetAsync<SupplierStatistics>("Suppliers/statistics");
                if (stats != null)
                {
                    lblStatSuppliers.Text = "👥 Total Suppliers: " + stats.SupplierCount;
                    lblStatPurchases.Text = "💰 Total Purchases: " + stats.TotalPurchases.ToString("N2");
                    lblStatDebt.Text = "⚠️ Total Debt: " + stats.TotalDebt.ToString("N2");
                }
            }
            catch
            {
            }
        }

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim().ToLower();

            var filtered = _allSuppliers;

            if (!string.IsNullOrEmpty(search))
            {
                filtered = filtered.FindAll(s =>
                    (s.SupplierName ?? "").ToLower().Contains(search) ||
                    (s.ContactPerson ?? "").ToLower().Contains(search) ||
                    (s.Phone ?? "").ToLower().Contains(search) ||
                    (s.Email ?? "").ToLower().Contains(search));
            }

            PopulateGrid(filtered);
        }

        private void PopulateGrid(List<Supplier> suppliers)
        {
            if (dgvSuppliers.Columns.Count == 0)
            {
                dgvSuppliers.Columns.AddRange(new DataGridViewColumn[] {
            colID, colName, colContact, colPhone, colEmail,
            colTotalPurchases, colTotalDebt, colCreditLimit,
            colPaymentTerms, colStatus
        });
            }

            dgvSuppliers.Rows.Clear();
            _selectedSupplierID = 0;
            SetButtonsState(false);

            foreach (var s in suppliers)
            {
                int rowIndex = dgvSuppliers.Rows.Add(
                    s.SupplierID,
                    s.SupplierName,
                    s.ContactPerson,
                    s.Phone,
                    s.Email,
                    s.TotalPurchases.ToString("N2"),
                    s.TotalDebt.ToString("N2"),
                    s.CreditLimit.ToString("N2"),
                    s.PaymentTerms,
                    s.IsActive ? "Active" : "Inactive"
                );

                var row = dgvSuppliers.Rows[rowIndex];

                if (s.TotalDebt > 0)
                    row.Cells["colTotalDebt"].Style.ForeColor = Color.FromArgb(192, 57, 43);

                if (s.IsActive)
                {
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(39, 174, 96);
                    row.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else
                {
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(150, 150, 150);
                }
            }

            lblCount.Text = "Total: " + suppliers.Count + " supplier(s)";
        }


        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSuppliers.Rows[e.RowIndex];
            _selectedSupplierID = Convert.ToInt32(row.Cells["colID"].Value);
            SetButtonsState(true);
        }

        private async void dgvSuppliers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            await OpenEditFormAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmSupplierDetail(0);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadStatisticsAsync();
                await LoadSuppliersAsync();
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            await OpenEditFormAsync();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DeleteSupplierAsync();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbFilter.SelectedIndex = 0;
            await LoadStatisticsAsync();
            await LoadSuppliersAsync();
        }

 
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadSuppliersAsync();
        }

        private async Task OpenEditFormAsync()
        {
            if (_selectedSupplierID <= 0) return;

            var frm = new FrmSupplierDetail(_selectedSupplierID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await LoadStatisticsAsync();
                await LoadSuppliersAsync();
            }
        }

        private async Task DeleteSupplierAsync()
        {
            if (_selectedSupplierID <= 0) return;

            var supplier = _allSuppliers.Find(s => s.SupplierID == _selectedSupplierID);
            if (supplier == null) return;

            bool confirm = MessageHelper.ShowConfirm(
                "Are you sure you want to delete supplier:\n\"" + supplier.SupplierName + "\"?");

            if (!confirm) return;

            try
            {
                SetLoading(true);
                bool result = await ApiHelper.DeleteAsync("Suppliers/" + _selectedSupplierID);

                if (result)
                {
                    MessageHelper.ShowSuccess("Supplier deleted successfully.");
                    await LoadStatisticsAsync();
                    await LoadSuppliersAsync();
                }
                else
                {
                    MessageHelper.ShowError("Failed to delete supplier.");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error deleting supplier.\n" + ex.Message);
            }
            finally
            {
                SetLoading(false);
            }
        }


        private void SetButtonsState(bool enabled)
        {
            btnAdd.Enabled = SessionManager.IsAdmin;
            btnEdit.Enabled = enabled && SessionManager.IsAdmin;
            btnDelete.Enabled = enabled && SessionManager.IsAdmin;
        }

        private void SetLoading(bool loading)
        {
            this.Cursor = loading ? Cursors.WaitCursor : Cursors.Default;
            btnAdd.Enabled = !loading && SessionManager.IsAdmin;
            btnRefresh.Enabled = !loading;
        }

        private class SupplierStatistics
        {
            public decimal TotalPurchases { get; set; }
            public decimal TotalDebt { get; set; }
            public int SupplierCount { get; set; }
        }
    }
}