using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmDiscounts : Form
    {
        private List<Discount> _allDiscounts = new List<Discount>();
        private Discount _selectedDiscount = null;

        public FrmDiscounts()
        {
            InitializeComponent();
        }

        private async void FrmDiscounts_Load(object sender, EventArgs e)
        {
            await LoadDiscounts();
        }

        private async Task LoadDiscounts()
        {
            try
            {
                spinner.Start();
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;

                bool? isActive = cmbFilter.SelectedIndex == 1 ? true
                                : cmbFilter.SelectedIndex == 2 ? false
                                : (bool?)null;

                string endpoint = "Discounts?currentOnly=false";
                if (isActive.HasValue)
                    endpoint += "&isActive=" + isActive.Value.ToString().ToLower();

                var result = await ApiHelper.GetAsync<List<Discount>>(endpoint);
                if (result != null)
                {
                    _allDiscounts = result;
                    FilterAndDisplay();
                    UpdateStats();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading discounts: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                btnAdd.Enabled = true;
            }
        }

        private void FilterAndDisplay()
        {
            var filtered = _allDiscounts.AsEnumerable();

            string search = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(search))
                filtered = filtered.Where(d =>
                    d.DiscountName.ToLower().Contains(search) ||
                    d.DiscountType.ToLower().Contains(search) ||
                    d.ApplicableOn.ToLower().Contains(search));

            if (cmbFilter.SelectedIndex == 1)
                filtered = filtered.Where(d => d.IsActive);
            else if (cmbFilter.SelectedIndex == 2)
                filtered = filtered.Where(d => !d.IsActive);

            var list = filtered.ToList();
            dgvDiscounts.Rows.Clear();

            foreach (var d in list)
            {
                string valueDisplay = d.DiscountType == "Percentage"
                    ? $"{d.DiscountValue:N2}%"
                    : $"{d.DiscountValue:N2}";

                bool isExpired = d.EndDate < DateTime.Today;
                string statusText = !d.IsActive ? "Inactive" : isExpired ? "Expired" : "Active";

                int idx = dgvDiscounts.Rows.Add(
                    d.DiscountID,
                    d.DiscountName,
                    d.DiscountType == "Percentage" ? "Percentage" : "Fixed Amount",
                    valueDisplay,
                    d.MinimumPurchaseAmount.ToString("N2"),
                    (d.MaximumDiscountAmount ?? 0).ToString("N2"),
                    d.ApplicableOn,
                    d.StartDate.ToString("yyyy/MM/dd"),
                    d.EndDate.ToString("yyyy/MM/dd"),
                    d.UsageCount,
                    statusText
                );

                var row = dgvDiscounts.Rows[idx];
                row.Tag = d;

                if (!d.IsActive)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166);
                else if (isExpired)
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(192, 57, 43);
                else
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(39, 174, 96);
            }

            lblCount.Text = $"Total: {list.Count} discount(s)";
        }

        private void UpdateStats()
        {
            int total = _allDiscounts.Count;
            int active = _allDiscounts.Count(d => d.IsActive && d.EndDate >= DateTime.Today);
            int expired = _allDiscounts.Count(d => d.EndDate < DateTime.Today);

            lblStatTotal.Text = $"🏷️  Total Discounts: {total}";
            lblStatActive.Text = $"✅  Active: {active}";
            lblStatExpired.Text = $"⚠️  Expired: {expired}";
        }

        private void dgvDiscounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedDiscount = dgvDiscounts.Rows[e.RowIndex].Tag as Discount;
            btnEdit.Enabled = _selectedDiscount != null;
            btnDelete.Enabled = _selectedDiscount != null;
        }

        private void dgvDiscounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedDiscount = dgvDiscounts.Rows[e.RowIndex].Tag as Discount;
            if (_selectedDiscount != null) OpenEditDialog(_selectedDiscount);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmDiscountDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _ = LoadDiscounts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedDiscount == null) return;
            OpenEditDialog(_selectedDiscount);
        }

        private void OpenEditDialog(Discount d)
        {
            using (var dlg = new FrmDiscountDialog(d))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _ = LoadDiscounts();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedDiscount == null) return;

            if (!MessageHelper.ShowConfirm($"Delete discount '{_selectedDiscount.DiscountName}'?"))
                return;

            try
            {
                spinner.Start();
                bool success = await ApiHelper.DeleteAsync($"Discounts/{_selectedDiscount.DiscountID}");
                if (success)
                {
                    MessageHelper.ShowSuccess("Discount deleted successfully.");
                    _selectedDiscount = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    await LoadDiscounts();
                }
                else
                {
                    MessageHelper.ShowError("Failed to delete discount.");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDiscounts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndDisplay();
        }

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadDiscounts();
        }
    }
}