using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    public partial class FrmInventory : Form
    {
        private List<Models.Core.Inventory> _inventory = new List<Models.Core.Inventory>();
        private List<Category> _categories = new List<Category>();
        private LoadingSpinnerControl spinner;
        private SearchBoxControl searchBox;

        public FrmInventory()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(390, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(450, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);
        }

        private async void FrmInventory_Load(object sender, EventArgs e)
        {
            btnAdjust.Visible = SessionManager.IsAdmin;

            cmbFilterType.Items.Clear();
            cmbFilterType.Items.Add("All Types");
            cmbFilterType.Items.Add("Book");
            cmbFilterType.Items.Add("Stationery");
            cmbFilterType.Items.Add("Other");
            cmbFilterType.SelectedIndex = 0;

            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.Add("All");
            cmbFilterStatus.Items.Add("In Stock");
            cmbFilterStatus.Items.Add("Low Stock");
            cmbFilterStatus.Items.Add("Out of Stock");
            cmbFilterStatus.SelectedIndex = 0;

            await LoadCategories();
            await LoadInventory();
        }

        private async System.Threading.Tasks.Task LoadCategories()
        {
            try
            {
                _categories = await ApiHelper.GetAsync<List<Category>>("categories")
                              ?? new List<Category>();

                cmbFilterCategory.Items.Clear();
                cmbFilterCategory.Items.Add("All Categories");
                foreach (var c in _categories)
                    cmbFilterCategory.Items.Add(c.CategoryName);

                cmbFilterCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadInventory()
        {
            try
            {
                spinner.Start();
                _inventory = await ApiHelper.GetAsync<List<Models.Core.Inventory>>("inventory")
                             ?? new List<Models.Core.Inventory>();
                BindGrid(_inventory);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading inventory: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        private void BindGrid(List<Models.Core.Inventory> list)
        {
            dgvInventory.Rows.Clear();
            foreach (var inv in list)
            {
                string status = GetStockStatus(inv.QuantityInStock, inv.MinimumStockLevel);
                dgvInventory.Rows.Add(
                    inv.ProductID,
                    inv.ProductName,
                    inv.CategoryName,
                    "",
                    inv.QuantityInStock,
                    inv.QuantityBorrowed,
                    inv.AvailableQuantity,
                    inv.MinimumStockLevel,
                    status
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private string GetStockStatus(int inStock, int minStock)
        {
            if (inStock == 0) return "Out of Stock";
            if (inStock <= minStock) return "Low Stock";
            return "In Stock";
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                BindGrid(_inventory);
                return;
            }

            string search = text.ToLower();
            var filtered = new List<Models.Core.Inventory>();

            foreach (var inv in _inventory)
            {
                if (inv.ProductName.ToLower().Contains(search) ||
                   (inv.CategoryName != null && inv.CategoryName.ToLower().Contains(search)))
                {
                    filtered.Add(inv);
                }
            }

            BindGrid(filtered);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbFilterCategory.SelectedIndex > 0
                ? cmbFilterCategory.SelectedItem?.ToString() : "";

            string selectedStatus = cmbFilterStatus.SelectedIndex > 0
                ? cmbFilterStatus.SelectedItem?.ToString() : "";

            var filtered = new List<Models.Core.Inventory>();

            foreach (var inv in _inventory)
            {
                bool matchCategory = string.IsNullOrEmpty(selectedCategory)
                    || inv.CategoryName == selectedCategory;

                string status = GetStockStatus(inv.QuantityInStock, inv.MinimumStockLevel);
                bool matchStatus = string.IsNullOrEmpty(selectedStatus)
                    || status == selectedStatus;

                if (matchCategory && matchStatus)
                    filtered.Add(inv);
            }

            BindGrid(filtered);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbFilterCategory.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            searchBox.Clear();
            BindGrid(_inventory);
        }

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvInventory.Rows[e.RowIndex];
            string status = row.Cells["colStatus"].Value?.ToString();

            switch (status)
            {
                case "Out of Stock":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                    break;
                case "Low Stock":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 110, 0);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
                    break;
                default:
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 40, 60);
                    row.DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }

        private void btnAdjust_Click(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Please select a product first.");
                return;
            }

            var row = dgvInventory.SelectedRows[0];
            int productId = Convert.ToInt32(row.Cells["colProductID"].Value);
            string name = row.Cells["colProductName"].Value?.ToString();
            int stock = Convert.ToInt32(row.Cells["colInStock"].Value);

            using (var frm = new FrmStockAdjust(productId, name, stock))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    btnRefresh_Click(null, null);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbFilterCategory.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndex = 0;
            await LoadInventory();
        }
    }
}