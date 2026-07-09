using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.DTOs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    public partial class FrmStockAdjust : Form
    {
        private int _productId;
        private int _currentStock;

        public FrmStockAdjust(int productId, string productName, int currentStock)
        {
            InitializeComponent();
            _productId = productId;
            _currentStock = currentStock;
            lblProductName.Text = productName;
            lblCurrentStock.Text = "Current Stock: " + currentStock;
        }

        private void FrmStockAdjust_Load(object sender, EventArgs e)
        {
            cmbAdjustType.Items.Clear();
            cmbAdjustType.Items.Add("Add");
            cmbAdjustType.Items.Add("Remove");
            cmbAdjustType.Items.Add("Set");
            cmbAdjustType.SelectedIndex = 0;
            nudQuantity.Value = 1;
            nudQuantity.Minimum = 1;
            nudQuantity.Maximum = 99999;
            UpdatePreview();
        }

        private void cmbAdjustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void nudQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            int qty = (int)nudQuantity.Value;
            int newStock = _currentStock;

            switch (cmbAdjustType.SelectedItem?.ToString())
            {
                case "Add":
                    newStock = _currentStock + qty;
                    break;
                case "Remove":
                    newStock = _currentStock - qty;
                    if (newStock < 0) newStock = 0;
                    break;
                case "Set":
                    newStock = qty;
                    break;
            }

            lblNewStock.Text = "New Stock: " + newStock;
            lblNewStock.ForeColor = newStock <= 0
                ? Color.FromArgb(200, 50, 50)
                : Color.FromArgb(40, 160, 100);
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.IsEmpty(txtReason.Text))
            {
                MessageHelper.ShowWarning("Please enter a reason for adjustment.");
                txtReason.Focus();
                return;
            }

            try
            {
                btnConfirm.Enabled = false;
                btnConfirm.Text = "Saving...";

                var dto = new UpdateStockDTO
                {
                    ProductID = _productId,
                    Quantity = (int)nudQuantity.Value,
                    MovementType = cmbAdjustType.SelectedItem?.ToString()
                };

                var result = await ApiHelper.PutAsync<object>("inventory/update-stock", dto);
                if (result != null)
                {
                    MessageHelper.ShowSuccess("Stock adjusted successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error adjusting stock: " + ex.Message);
            }
            finally
            {
                btnConfirm.Enabled = true;
                btnConfirm.Text = "Confirm";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}