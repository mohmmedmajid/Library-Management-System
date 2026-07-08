using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmPromotionalOfferDialog : Form
    {
        private readonly PromotionalOffer _editingOffer;
        private bool IsEditMode => _editingOffer != null;

        private List<Product> _products = new List<Product>();
        private List<Category> _categories = new List<Category>();

        public FrmPromotionalOfferDialog()
        {
            InitializeComponent();
            _editingOffer = null;
        }

        public FrmPromotionalOfferDialog(PromotionalOffer offer) : this()
        {
            _editingOffer = offer;
        }

        private async void FrmPromotionalOfferDialog_Load(object sender, EventArgs e)
        {
            cmbOfferType.Items.AddRange(new object[] { "BuyXGetY", "BuyXGetDiscount", "BundleDiscount" });
            cmbApplicableOn.Items.AddRange(new object[] { "Product", "Category" });

            await LoadLookupsAsync();

            if (IsEditMode)
            {
                lblTitle.Text = "Edit Promotional Offer";
                chkIsActive.Visible = true;
                PopulateFromOffer(_editingOffer);

                cmbApplicableOn.Enabled = false;
                cmbCategory.Enabled = false;
                cmbBuyProduct.Enabled = false;
                cmbGetProduct.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Add Promotional Offer";
                chkIsActive.Visible = false;
                cmbOfferType.SelectedIndex = 0;
                cmbApplicableOn.SelectedIndex = 0;
                dtpStartDate.Value = DateTime.Today;
                dtpEndDate.Value = DateTime.Today.AddDays(30);
                numPriority.Value = 0;
                numBuyQuantity.Value = 1;
                numGetQuantity.Value = 1;
            }

            TogglePanelsByOfferType();
            ToggleCategoryByApplicableOn();
        }

        private async Task LoadLookupsAsync()
        {
            try
            {
                spinner.Start();

                var allProducts = await ApiHelper.GetAsync<List<Product>>("Products");
                _products = allProducts.Where(p => p.IsActive).ToList();
                _categories = await ApiHelper.GetAsync<List<Category>>("Categories");

                cmbBuyProduct.DataSource = _products.ToList();
                cmbBuyProduct.DisplayMember = "ProductName";
                cmbBuyProduct.ValueMember = "ProductID";

                cmbGetProduct.DataSource = _products.ToList();
                cmbGetProduct.DisplayMember = "ProductName";
                cmbGetProduct.ValueMember = "ProductID";

                cmbCategory.DataSource = _categories.ToList();
                cmbCategory.DisplayMember = "CategoryName";
                cmbCategory.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading products/categories: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        private void PopulateFromOffer(PromotionalOffer o)
        {
            txtOfferName.Text = o.OfferName;
            txtOfferNameAr.Text = o.OfferNameAr;
            cmbOfferType.SelectedItem = o.OfferType;
            numBuyQuantity.Value = (o.BuyQuantity ?? 0) > 0 ? o.BuyQuantity.Value : 1;
            numGetQuantity.Value = (o.GetQuantity ?? 0) > 0 ? o.GetQuantity.Value : 1;
            numDiscountPercent.Value = o.DiscountPercent ?? 0;
            numBundlePrice.Value = o.BundlePrice ?? 0;
            dtpStartDate.Value = o.StartDate;
            dtpEndDate.Value = o.EndDate;
            chkIsActive.Checked = o.IsActive;

            var buyProduct = _products.FirstOrDefault(p => p.ProductName == o.BuyProductName);
            if (buyProduct != null) cmbBuyProduct.SelectedValue = buyProduct.ProductID;

            var getProduct = _products.FirstOrDefault(p => p.ProductName == o.GetProductName);
            if (getProduct != null) cmbGetProduct.SelectedValue = getProduct.ProductID;
        }

        private void cmbOfferType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TogglePanelsByOfferType();
        }

        private void TogglePanelsByOfferType()
        {
            string type = cmbOfferType.SelectedItem as string;

            pnlBOGO.Visible = type == "BuyXGetY";
            pnlBundle.Visible = type == "BundleDiscount";
            pnlPercentage.Visible = type == "BuyXGetDiscount";
        }

        private void cmbApplicableOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleCategoryByApplicableOn();
        }

        private void ToggleCategoryByApplicableOn()
        {
            string applicable = cmbApplicableOn.SelectedItem as string;
            lblCategory.Visible = applicable == "Category";
            cmbCategory.Visible = applicable == "Category";
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtOfferName.Text))
            {
                MessageHelper.ShowWarning("Please enter the offer name.");
                txtOfferName.Focus();
                return false;
            }

            if (cmbOfferType.SelectedItem == null)
            {
                MessageHelper.ShowWarning("Please select the offer type.");
                return false;
            }

            string type = cmbOfferType.SelectedItem.ToString();

            if (type == "BuyXGetY")
            {
                if (numBuyQuantity.Value <= 0 || numGetQuantity.Value <= 0)
                {
                    MessageHelper.ShowWarning("Buy/Get quantities must be greater than zero.");
                    return false;
                }

                if (!IsEditMode && (cmbBuyProduct.SelectedValue == null || cmbGetProduct.SelectedValue == null))
                {
                    MessageHelper.ShowWarning("Please select the Buy and Get products.");
                    return false;
                }
            }
            else if (type == "BundleDiscount")
            {
                if (numBundlePrice.Value <= 0)
                {
                    MessageHelper.ShowWarning("Bundle price must be greater than zero.");
                    return false;
                }
            }
            else if (type == "BuyXGetDiscount")
            {
                if (numDiscountPercent.Value <= 0 || numDiscountPercent.Value > 100)
                {
                    MessageHelper.ShowWarning("Discount percent must be between 1 and 100.");
                    return false;
                }
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageHelper.ShowWarning("End date cannot be earlier than start date.");
                return false;
            }

            if (!IsEditMode && cmbApplicableOn.SelectedItem != null && cmbApplicableOn.SelectedItem.ToString() == "Category" && cmbCategory.SelectedValue == null)
            {
                MessageHelper.ShowWarning("Please select a category.");
                return false;
            }

            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                spinner.Start();
                btnSave.Enabled = false;
                btnCancel.Enabled = false;

                if (IsEditMode)
                {
                    var dto = new UpdatePromotionalOfferDTO
                    {
                        OfferID = _editingOffer.OfferID,
                        OfferName = txtOfferName.Text.Trim(),
                        OfferNameAr = txtOfferNameAr.Text.Trim(),
                        OfferType = cmbOfferType.SelectedItem.ToString(),
                        BuyQuantity = (int)numBuyQuantity.Value,
                        GetQuantity = (int)numGetQuantity.Value,
                        DiscountPercent = numDiscountPercent.Value,
                        BundlePrice = numBundlePrice.Value,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        Priority = (int)numPriority.Value,
                        Description = txtDescription.Text.Trim(),
                        IsActive = chkIsActive.Checked
                    };

                    await ApiHelper.PutAsync<bool>($"PromotionalOffers/{_editingOffer.OfferID}", dto);
                    MessageHelper.ShowSuccess("Promotional offer updated successfully.");
                }
                else
                {
                    var dto = new CreatePromotionalOfferDTO
                    {
                        OfferName = txtOfferName.Text.Trim(),
                        OfferNameAr = txtOfferNameAr.Text.Trim(),
                        OfferType = cmbOfferType.SelectedItem.ToString(),
                        BuyQuantity = (int)numBuyQuantity.Value,
                        GetQuantity = (int)numGetQuantity.Value,
                        BuyProductID = cmbBuyProduct.SelectedValue != null ? (int)cmbBuyProduct.SelectedValue : 0,
                        GetProductID = cmbGetProduct.SelectedValue != null ? (int)cmbGetProduct.SelectedValue : 0,
                        DiscountPercent = numDiscountPercent.Value,
                        BundlePrice = numBundlePrice.Value,
                        ApplicableOn = cmbApplicableOn.SelectedItem.ToString(),
                        CategoryID = cmbCategory.SelectedValue != null ? (int)cmbCategory.SelectedValue : 0,
                        StartDate = dtpStartDate.Value,
                        EndDate = dtpEndDate.Value,
                        Priority = (int)numPriority.Value,
                        Description = txtDescription.Text.Trim(),
                        CreatedBy = SessionManager.UserId
                    };

                    await ApiHelper.PostAsync<PromotionalOffer>("PromotionalOffers", dto);
                    MessageHelper.ShowSuccess("Promotional offer added successfully.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error saving promotional offer: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}