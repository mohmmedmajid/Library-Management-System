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
    public partial class FrmPromotionalOffers : Form
    {
        private List<PromotionalOffer> _allOffers = new List<PromotionalOffer>();
        private PromotionalOffer _selectedOffer = null;

        public FrmPromotionalOffers()
        {
            InitializeComponent();
        }

        private async void FrmPromotionalOffers_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
            await LoadOffers();
        }

        private async Task LoadOffers()
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

                string endpoint = "PromotionalOffers?currentOnly=false";
                if (isActive.HasValue)
                    endpoint += "&isActive=" + isActive.Value.ToString().ToLower();

                var result = await ApiHelper.GetAsync<List<PromotionalOffer>>(endpoint);
                if (result != null)
                {
                    _allOffers = result;
                    FilterAndDisplay();
                    UpdateStats();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading promotional offers: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                btnAdd.Enabled = true;
            }
        }

        private void FilterAndDisplay()
        {
            var filtered = _allOffers.AsEnumerable();

            string search = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(search))
                filtered = filtered.Where(o =>
                    o.OfferName.ToLower().Contains(search) ||
                    o.OfferNameAr.ToLower().Contains(search) ||
                    o.OfferType.ToLower().Contains(search) ||
                    o.BuyProductName.ToLower().Contains(search) ||
                    o.GetProductName.ToLower().Contains(search));

            if (cmbFilter.SelectedIndex == 1)
                filtered = filtered.Where(o => o.IsActive);
            else if (cmbFilter.SelectedIndex == 2)
                filtered = filtered.Where(o => !o.IsActive);

            var list = filtered.ToList();
            dgvOffers.Rows.Clear();

            foreach (var o in list)
            {
                string valueDisplay;
                if (o.OfferType == "BOGO")
                    valueDisplay = string.Format("Buy {0} Get {1}", o.BuyQuantity ?? 0, o.GetQuantity ?? 0);
                else if (o.OfferType == "Bundle")
                    valueDisplay = string.Format("{0:N2} JD", o.BundlePrice ?? 0);
                else
                    valueDisplay = string.Format("{0:N2}%", o.DiscountPercent ?? 0);

                bool isExpired = o.EndDate < DateTime.Today;
                string statusText = !o.IsActive ? "Inactive" : isExpired ? "Expired" : "Active";

                int idx = dgvOffers.Rows.Add(
                    o.OfferID,
                    o.OfferName,
                    o.OfferType,
                    valueDisplay,
                    o.BuyProductName,
                    o.GetProductName,
                    o.StartDate.ToString("yyyy/MM/dd"),
                    o.EndDate.ToString("yyyy/MM/dd"),
                    statusText
                );

                var row = dgvOffers.Rows[idx];
                row.Tag = o;

                if (!o.IsActive)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166);
                else if (isExpired)
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(192, 57, 43);
                else
                    row.Cells["colStatus"].Style.ForeColor = Color.FromArgb(39, 174, 96);
            }

            lblCount.Text = string.Format("Total: {0} offer(s)", list.Count);
        }

        private void UpdateStats()
        {
            int total = _allOffers.Count;
            int active = _allOffers.Count(o => o.IsActive && o.EndDate >= DateTime.Today);
            int expired = _allOffers.Count(o => o.EndDate < DateTime.Today);
            int expiringSoon = _allOffers.Count(o => o.IsActive && o.EndDate >= DateTime.Today && o.EndDate <= DateTime.Today.AddDays(7));

            lblStatTotal.Text = string.Format("🎁  Total: {0}", total);
            lblStatActive.Text = string.Format("✅  Active: {0}", active);
            lblStatExpired.Text = string.Format("⚠️  Expired: {0}", expired);
            lblStatExpiringSoon.Text = string.Format("⏳  Expiring Soon: {0}", expiringSoon);
        }

        private void dgvOffers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedOffer = dgvOffers.Rows[e.RowIndex].Tag as PromotionalOffer;
            btnEdit.Enabled = _selectedOffer != null;
            btnDelete.Enabled = _selectedOffer != null;
        }

        private void dgvOffers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _selectedOffer = dgvOffers.Rows[e.RowIndex].Tag as PromotionalOffer;
            if (_selectedOffer != null) OpenEditDialog(_selectedOffer);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmPromotionalOfferDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _ = LoadOffers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selectedOffer == null) return;
            OpenEditDialog(_selectedOffer);
        }

        private void OpenEditDialog(PromotionalOffer o)
        {
            using (var dlg = new FrmPromotionalOfferDialog(o))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _ = LoadOffers();
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedOffer == null) return;

            if (!MessageHelper.ShowConfirm(string.Format("Delete offer '{0}'?", _selectedOffer.OfferName)))
                return;

            try
            {
                spinner.Start();
                bool success = await ApiHelper.DeleteAsync(string.Format("PromotionalOffers/{0}", _selectedOffer.OfferID));
                if (success)
                {
                    MessageHelper.ShowSuccess("Promotional offer deleted successfully.");
                    _selectedOffer = null;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    await LoadOffers();
                }
                else
                {
                    MessageHelper.ShowError("Failed to delete promotional offer.");
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
            await LoadOffers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterAndDisplay();
        }

        private async void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadOffers();
        }
    }
}