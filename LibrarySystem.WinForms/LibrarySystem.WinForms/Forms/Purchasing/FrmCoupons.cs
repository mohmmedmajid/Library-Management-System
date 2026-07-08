using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmCoupons : Form
    {
        private List<Coupon> _allCoupons = new List<Coupon>();
        private Coupon _selectedCoupon = null;

        public FrmCoupons()
        {
            InitializeComponent();
        }

        private async void FrmCoupons_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            await LoadCoupons();
        }

        private async Task LoadCoupons()
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

                string endpoint = "Coupons?currentOnly=false";
                if (isActive.HasValue)
                    endpoint += "&isActive=" + isActive.Value.ToString().ToLower();

                var result = await ApiHelper.GetAsync<List<Coupon>>(endpoint);
                if (result != null)
                {
                    _allCoupons = result;
                    FilterAndDisplay();
                    UpdateStats();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading coupons: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                btnAdd.Enabled = true;
            }
        }

        private void FilterAndDisplay()
        {
            var filtered = _allCoupons.AsEnumerable();

            string search = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(search))
                filtered = filtered.Where(c =>
                    c.CouponCode.ToLower().Contains(search) ||
                    c.CouponName.ToLower().Contains(search) ||
                    c.DiscountType.ToLower().Contains(search));

            if (cmbFilter.SelectedIndex == 1)
                filtered = filtered.Where(c => c.IsActive);
            else if (cmbFilter.SelectedIndex == 2)
                filtered = filtered.Where(c => !c.IsActive);

            var list = filtered.ToList();
            dgvCoupons.Rows.Clear();

            foreach (var c in list)
            {
                string valueDisplay = c.DiscountType == "Percentage"
                    ? string.Format("{0:N2}%", c.DiscountValue)
                    : string.Format("{0:N2} JD", c.DiscountValue);

                bool isExpired = c.EndDate < DateTime.Today;
                string statusText = !c.IsActive ? "Inactive" : isExpired ? "Expired" : "Active";
                string visibilityText = c.IsPublic ? "Public" : "Private";

                int idx = dgvCoupons.Rows.Add(
                    c.CouponID,
                    c.CouponCode,
                    c.CouponName,
                    c.DiscountType == "Percentage" ? "Percentage" : "Fixed Amount",
                    valueDisplay,
                    c.MinimumPurchaseAmount.ToString("N2"),
                    c.ApplicableOn,
                    c.StartDate.ToString("yyyy/MM/dd"),
                    c.EndDate.ToString("yyyy/MM/dd"),
                    c.UsageCount,
                    visibilityText,
                    statusText
                );

                var row = dgvCoupons.Rows[idx];
                row.Tag = c;

                if (!c.IsActive)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166);
                else if (isExpired)
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(192, 57, 43);
                else
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(39, 174, 96);
            }

            lblCount.Text = string.Format("Total: {0} coupon(s)", list.Count);
        }

        private void UpdateStats()
        {
            int total = _allCoupons.Count;
            int active = _allCoupons.Count(c => c.IsActive && c.EndDate >= DateTime.Today);
            int expired = _allCoupons.Count(c => c.EndDate < DateTime.Today);
            int publicCount = _allCoupons.Count(c => c.IsPublic && c.IsActive);

            lblStatTotal.Text = string.Format("🎟️  Total: {0}", total);
            lblStatActive.Text = string.Format("✅  Active: {0}", active);
            lblStatExpired.Text = string.Format("⚠️  Expired: {0}", expired);
            lblStatPublic.Text = string.Format("🌐  Public: {0}", publicCount);
        }

        private void dgvCoupons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedCoupon = dgvCoupons.Rows[e.RowIndex].Tag as Coupon;
            btnEdit.Enabled = _selectedCoupon != null;
            btnDelete.Enabled = _selectedCoupon != null;
        }

        private void dgvCoupons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedCoupon = dgvCoupons.Rows[e.RowIndex].Tag as Coupon;
            if (_selectedCoupon != null) OpenEditDialog(_selectedCoupon);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmCouponDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _ = LoadCoupons();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedCoupon == null) return;
            OpenEditDialog(_selectedCoupon);
        }

        private void OpenEditDialog(Coupon c)
        {
            using (var dlg = new FrmCouponDialog(c))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _ = LoadCoupons();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCoupon == null) return;

            if (!MessageHelper.ShowConfirm(string.Format("Delete coupon '{0}'?", _selectedCoupon.CouponCode)))
                return;

            try
            {
                spinner.Start();
                bool success = await ApiHelper.DeleteAsync(string.Format("Coupons/{0}", _selectedCoupon.CouponID));
                if (success)
                {
                    MessageHelper.ShowSuccess("Coupon deleted successfully.");
                    _selectedCoupon = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    await LoadCoupons();
                }
                else
                {
                    MessageHelper.ShowError("Failed to delete coupon.");
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
            await LoadCoupons();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndDisplay();
        }

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadCoupons();
        }
    }
}