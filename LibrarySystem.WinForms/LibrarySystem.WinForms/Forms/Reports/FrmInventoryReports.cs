using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryModel = LibrarySystem.WinForms.Models.Core.Inventory;
using Category = LibrarySystem.WinForms.Models.Core.Category;

namespace LibrarySystem.WinForms.Forms.Reports
{
    public partial class FrmInventoryReports : Form
    {
        private List<InventoryModel> _inventory = new List<InventoryModel>();
        private List<Category> _categories = new List<Category>();

        public FrmInventoryReports()
        {
            InitializeComponent();
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(40, 40);
            pnlTop.Controls.Add(spinner);
        }

        private async void FrmInventoryReports_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadReportAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                _categories = await ApiHelper.GetAsync<List<Category>>("Categories");
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");
                foreach (var c in _categories)
                    cmbCategory.Items.Add(c.CategoryName);
                cmbCategory.SelectedIndex = 0;
            }
            catch { }
        }

        private async Task LoadReportAsync()
        {
            try
            {
                spinner.Start();
                lblStatus.Text = "Loading...";

                if (cmbStockStatus.SelectedIndex == 2)
                    _inventory = await ApiHelper.GetAsync<List<InventoryModel>>("Inventory/low-stock");
                else
                    _inventory = await ApiHelper.GetAsync<List<InventoryModel>>("Inventory");

                List<InventoryModel> filtered = _inventory;

                if (cmbCategory.SelectedIndex > 0)
                {
                    var catName = cmbCategory.SelectedItem.ToString();
                    filtered = filtered.Where(i => i.CategoryName == catName).ToList();
                }

                if (cmbStockStatus.SelectedIndex == 1)
                    filtered = filtered.Where(i => i.AvailableQuantity > 0).ToList();
                else if (cmbStockStatus.SelectedIndex == 3)
                    filtered = filtered.Where(i => i.AvailableQuantity <= 0).ToList();

                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var q = txtSearch.Text.ToLower();
                    filtered = filtered.Where(i =>
                        (i.ProductName != null && i.ProductName.ToLower().Contains(q)) ||
                        (i.ProductNameAr != null && i.ProductNameAr.ToLower().Contains(q))
                    ).ToList();
                }

                BindGrid(filtered);
                UpdateSummary(filtered);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Failed to load report: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                lblStatus.Text = "";
            }
        }

        private void BindGrid(List<InventoryModel> data)
        {
            dgvReport.Rows.Clear();
            foreach (var inv in data)
            {
                dgvReport.Rows.Add(
                    inv.InventoryID,
                    inv.ProductID,
                    inv.ProductName,
                    inv.CategoryName,
                    inv.QuantityInStock,
                    inv.QuantityBorrowed,
                    inv.AvailableQuantity,
                    inv.MinimumStockLevel,
                    inv.AvailableQuantity <= inv.MinimumStockLevel ? "Low Stock" : "OK",
                    inv.LastUpdatedDate.ToString("yyyy-MM-dd")
                );
            }
            lblCount.Text = "Records: " + data.Count;
        }

        private void UpdateSummary(List<InventoryModel> data)
        {
            int totalStock = data.Sum(i => i.QuantityInStock);
            int totalBorrowed = data.Sum(i => i.QuantityBorrowed);
            int totalAvailable = data.Sum(i => i.AvailableQuantity);
            int lowStockCount = data.Count(i => i.AvailableQuantity <= i.MinimumStockLevel);
            int outOfStockCount = data.Count(i => i.AvailableQuantity <= 0);

            lblTotalProducts.Text = data.Count.ToString();
            lblTotalStock.Text = totalStock.ToString("N0");
            lblTotalBorrowed.Text = totalBorrowed.ToString("N0");
            lblTotalAvailable.Text = totalAvailable.ToString("N0");
            lblLowStock.Text = lowStockCount.ToString();
            lblOutOfStock.Text = outOfStockCount.ToString();
        }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var sb = new System.Text.StringBuilder();
                sb.AppendLine("Product,Category,In Stock,Borrowed,Available,Min Level,Status,Last Updated");
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    var row = dgvReport.Rows[i];
                    sb.AppendLine(
                        row.Cells["colProduct"].Value + "," +
                        row.Cells["colCategory"].Value + "," +
                        row.Cells["colInStock"].Value + "," +
                        row.Cells["colBorrowed"].Value + "," +
                        row.Cells["colAvailable"].Value + "," +
                        row.Cells["colMinLevel"].Value + "," +
                        row.Cells["colStockStatus"].Value + "," +
                        row.Cells["colLastUpdated"].Value
                    );
                }

                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "CSV files (*.csv)|*.csv";
                    dlg.FileName = "InventoryReport_" + DateTime.Now.ToString("yyyyMMdd");
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllText(dlg.FileName, sb.ToString(), System.Text.Encoding.UTF8);
                        MessageHelper.ShowSuccess("Exported successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Export failed: " + ex.Message);
            }
        }

        private async void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        private void DgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = dgvReport.Columns["colStockStatus"];
            if (col != null && e.ColumnIndex == col.Index && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Low Stock")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                }
            }
        }
    }
}