using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    public partial class FrmProducts : Form
    {
        private List<Product> _products = new List<Product>();
        private List<Category> _categories = new List<Category>();

        public FrmProducts()
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

            dgvProducts.CellFormatting += DgvProducts_CellFormatting;
        }


        private void DgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int bookDetCol = dgvProducts.Columns["colBookDetails"].Index;
            int barcodesCol = dgvProducts.Columns["colBarcodes"].Index;
            int editCol = dgvProducts.Columns["colEdit"].Index;
            int delCol = dgvProducts.Columns["colDelete"].Index;

            if (e.ColumnIndex == barcodesCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(100, 60, 160);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(100, 60, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == bookDetCol)
            {
                string productType = dgvProducts.Rows[e.RowIndex].Cells["colProductType"].Value?.ToString() ?? "";
                if (productType == "Book")
                {
                    e.CellStyle.BackColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(40, 160, 100);
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    Color bg = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(245, 247, 250);
                    e.CellStyle.BackColor = bg;
                    e.CellStyle.ForeColor = bg;
                    e.CellStyle.SelectionBackColor = Color.FromArgb(210, 220, 235);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(210, 220, 235);
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
            else if (e.ColumnIndex == editCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == delCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

    
        private async void FrmProducts_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvProducts.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvProducts.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadCategories();
            await LoadProducts();
        }

        private async System.Threading.Tasks.Task LoadCategories()
        {
            try
            {
                _categories = await ApiHelper.GetAsync<List<Category>>("categories")
                              ?? new List<Category>();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadProducts()
        {
            try
            {
                spinner.Start();
                _products = await ApiHelper.GetAsync<List<Product>>("products")
                            ?? new List<Product>();
                BindGrid(_products);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading products: " + ex.Message); }
            finally { spinner.Stop(); }
        }


        private void BindGrid(List<Product> list)
        {
            dgvProducts.Rows.Clear();
            foreach (var p in list)
            {
                dgvProducts.Rows.Add(
                    p.ProductID,
                    p.Barcode,
                    p.ProductName,
                    p.CategoryName,
                    p.ProductType,
                    p.UnitPrice.ToString("F2"),
                    p.QuantityInStock,
                    p.IsActive ? "✓ Active" : "✗ Inactive",
                    p.ProductType == "Book" ? "📚 Details" : "",
                    "🔲 Barcodes",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }


        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvProducts.Rows[e.RowIndex].Cells["colProductID"].Value);
            var product = _products.Find(p => p.ProductID == id);
            if (product == null) return;

            if (e.ColumnIndex == dgvProducts.Columns["colBarcodes"].Index)
            { OpenBarcodes(product); return; }

            if (e.ColumnIndex == dgvProducts.Columns["colBookDetails"].Index && product.ProductType == "Book")
            { OpenBookDetails(product); return; }

            if (!SessionManager.IsAdmin) return;

            if (e.ColumnIndex == dgvProducts.Columns["colEdit"].Index)
                OpenEditDialog(product);
            else if (e.ColumnIndex == dgvProducts.Columns["colDelete"].Index)
                DeleteProduct(product);
        }


        private void OpenBarcodes(Product product)
        {
            var frm = new FrmBarcodes(product.ProductID, product.ProductName);
            frm.ShowDialog(this);
        }

        private void OpenBookDetails(Product product)
        {
            var frm = new FrmBooks();
            frm.ShowDialog(this);
        }

 
        private void OpenEditDialog(Product product = null)
        {
            bool isNew = product == null;

            if (isNew)
            {
                var dlg = new Form { Text = "➕ Add Product", Size = new Size(500, 710), StartPosition = FormStartPosition.CenterParent, BackColor = Color.White, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false, Font = new Font("Segoe UI", 10f) };
                var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(500, 50), BackColor = Color.FromArgb(22, 32, 50) };
                pnlHeader.Controls.Add(new Label { Text = "➕ Add Product", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(460, 28) });
                dlg.Controls.Add(pnlHeader);
                var pnlNote = new Panel { Location = new Point(10, 58), Size = new Size(475, 36), BackColor = Color.FromArgb(255, 243, 205) };
                pnlNote.Controls.Add(new Label { Text = "📚 To add a Book, please use the Books section instead.", Font = new Font("Segoe UI", 9f), ForeColor = Color.FromArgb(120, 80, 0), Location = new Point(8, 9), Size = new Size(460, 20) });
                dlg.Controls.Add(pnlNote);
                int y = 105; int lx = 20; int fx = 20; int fw = 450;
                dlg.Controls.Add(new Label { Text = "Barcode", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtBarcode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtBarcode); y += 44;
                dlg.Controls.Add(new Label { Text = "Product Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtProductName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtProductName); y += 44;
                dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtProductNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes }; dlg.Controls.Add(txtProductNameAr); y += 44;
                dlg.Controls.Add(new Label { Text = "Category *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var cmbCategory = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
                cmbCategory.Items.Add(new ComboItem { ID = 0, Name = "-- Select Category --" });
                foreach (var c in _categories) cmbCategory.Items.Add(new ComboItem { ID = c.CategoryID, Name = c.CategoryName });
                cmbCategory.DisplayMember = "Name"; cmbCategory.ValueMember = "ID"; cmbCategory.SelectedIndex = 0; dlg.Controls.Add(cmbCategory); y += 44;
                dlg.Controls.Add(new Label { Text = "Type", Location = new Point(lx, y), Size = new Size(140, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                dlg.Controls.Add(new Label { Text = "Unit Price *", Location = new Point(175, y), Size = new Size(120, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                dlg.Controls.Add(new Label { Text = "Cost Price", Location = new Point(310, y), Size = new Size(160, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var cmbProductType = new ComboBox { Location = new Point(fx, y), Size = new Size(145, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
                cmbProductType.Items.Add(new ComboBoxItem { Text = "Stationery", Value = "Stationery" });
                cmbProductType.Items.Add(new ComboBoxItem { Text = "Other", Value = "Other" });
                cmbProductType.DisplayMember = "Text"; cmbProductType.ValueMember = "Value"; cmbProductType.SelectedIndex = 0; dlg.Controls.Add(cmbProductType);
                var txtUnitPrice = new TextBox { Location = new Point(175, y), Size = new Size(120, 30), Text = "0.00", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtUnitPrice);
                var txtCostPrice = new TextBox { Location = new Point(310, y), Size = new Size(160, 30), Text = "0.00", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtCostPrice); y += 44;
                dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtDescription = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 55), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true }; dlg.Controls.Add(txtDescription); y += 68;
                dlg.Controls.Add(new Label { Text = "Quantity In Stock", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtQuantityInStock = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = "0", BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtQuantityInStock); y += 44;
                var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(215, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
                btnSave.FlatAppearance.BorderSize = 0; dlg.Controls.Add(btnSave);
                var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 230, y), Size = new Size(215, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
                btnCancel.FlatAppearance.BorderSize = 0; btnCancel.Click += (s, ev) => dlg.Close(); dlg.Controls.Add(btnCancel);
                btnSave.Click += async (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(txtProductName.Text)) { MessageHelper.ShowWarning("Please enter product name."); return; }
                    if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice)) { MessageHelper.ShowWarning("Please enter a valid price."); return; }
                    var selCat = cmbCategory.SelectedItem as ComboItem;
                    if (selCat == null || selCat.ID == 0) { MessageHelper.ShowWarning("Please select a category."); return; }
                    decimal.TryParse(txtCostPrice.Text, out decimal costPrice);
                    if (!int.TryParse(txtQuantityInStock.Text, out int quantityInStock)) { MessageHelper.ShowWarning("Please enter a valid quantity."); return; }
                    var selectedType = (cmbProductType.SelectedItem as ComboBoxItem)?.Value ?? "Other";
                    try
                    {
                        btnSave.Enabled = false; btnSave.Text = "Saving...";
                        var dto = new CreateProductDTO { ProductName = txtProductName.Text.Trim(), ProductNameAr = txtProductNameAr.Text.Trim(), CategoryID = selCat.ID, Barcode = txtBarcode.Text.Trim(), UnitPrice = unitPrice, CostPrice = costPrice, Description = txtDescription.Text.Trim(), ProductType = selectedType, QuantityInStock = quantityInStock, CreatedBy = SessionManager.UserId };
                        if (await ApiHelper.PostAsync<Product>("products", dto) != null)
                        { MessageHelper.ShowSuccess("Product added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
                };
                if (dlg.ShowDialog(this) == DialogResult.OK) _ = LoadProducts();
            }
            else
            {
                var dlg = new Form { Text = "✏️ Edit Product", Size = new Size(500, 700), StartPosition = FormStartPosition.CenterParent, BackColor = Color.White, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false, Font = new Font("Segoe UI", 10f) };
                var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(500, 50), BackColor = Color.FromArgb(22, 32, 50) };
                pnlHeader.Controls.Add(new Label { Text = "✏️ Edit Product", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(460, 28) });
                dlg.Controls.Add(pnlHeader);
                int y = 68; int lx = 20; int fx = 20; int fw = 450;
                dlg.Controls.Add(new Label { Text = "Barcode", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtBarcode = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = product.Barcode, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtBarcode); y += 44;
                dlg.Controls.Add(new Label { Text = "Product Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtProductName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = product.ProductName, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtProductName); y += 44;
                dlg.Controls.Add(new Label { Text = "Arabic Name", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtProductNameAr = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = product.ProductNameAr, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), RightToLeft = RightToLeft.Yes }; dlg.Controls.Add(txtProductNameAr); y += 44;
                dlg.Controls.Add(new Label { Text = "Category *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var cmbCategory = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
                cmbCategory.Items.Add(new ComboItem { ID = 0, Name = "-- Select Category --" });
                foreach (var c in _categories) cmbCategory.Items.Add(new ComboItem { ID = c.CategoryID, Name = c.CategoryName });
                cmbCategory.DisplayMember = "Name"; cmbCategory.ValueMember = "ID"; cmbCategory.SelectedIndex = 0;
                foreach (ComboItem ci in cmbCategory.Items) if (ci.ID == product.CategoryID) { cmbCategory.SelectedItem = ci; break; }
                dlg.Controls.Add(cmbCategory); y += 44;
                dlg.Controls.Add(new Label { Text = "Type", Location = new Point(lx, y), Size = new Size(140, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                dlg.Controls.Add(new Label { Text = "Unit Price *", Location = new Point(175, y), Size = new Size(120, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
                dlg.Controls.Add(new Label { Text = "Cost Price", Location = new Point(310, y), Size = new Size(160, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var cmbProductType = new ComboBox { Location = new Point(fx, y), Size = new Size(145, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
                cmbProductType.Items.Add(new ComboBoxItem { Text = "Book", Value = "Book" });
                cmbProductType.Items.Add(new ComboBoxItem { Text = "Stationery", Value = "Stationery" });
                cmbProductType.Items.Add(new ComboBoxItem { Text = "Other", Value = "Other" });
                cmbProductType.DisplayMember = "Text"; cmbProductType.ValueMember = "Value"; cmbProductType.SelectedIndex = 0;
                foreach (ComboBoxItem ci in cmbProductType.Items) if (ci.Value == product.ProductType) { cmbProductType.SelectedItem = ci; break; }
                dlg.Controls.Add(cmbProductType);
                var txtUnitPrice = new TextBox { Location = new Point(175, y), Size = new Size(120, 30), Text = product.UnitPrice.ToString("F2"), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtUnitPrice);
                var txtCostPrice = new TextBox { Location = new Point(310, y), Size = new Size(160, 30), Text = product.CostPrice.ToString("F2"), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtCostPrice); y += 44;
                dlg.Controls.Add(new Label { Text = "Description", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtDescription = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 55), Text = product.Description, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true }; dlg.Controls.Add(txtDescription); y += 68;
                dlg.Controls.Add(new Label { Text = "Quantity In Stock", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
                var txtQuantityInStock = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = product.QuantityInStock.ToString(), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) }; dlg.Controls.Add(txtQuantityInStock); y += 44;
                var chkActive = new CheckBox { Text = "✓ Active", Location = new Point(fx, y), Size = new Size(fw, 28), Checked = product.IsActive, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand }; dlg.Controls.Add(chkActive); y += 40;
                var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(215, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
                btnSave.FlatAppearance.BorderSize = 0; dlg.Controls.Add(btnSave);
                var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 230, y), Size = new Size(215, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
                btnCancel.FlatAppearance.BorderSize = 0; btnCancel.Click += (s, ev) => dlg.Close(); dlg.Controls.Add(btnCancel);
                btnSave.Click += async (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(txtProductName.Text)) { MessageHelper.ShowWarning("Please enter product name."); return; }
                    if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice)) { MessageHelper.ShowWarning("Please enter a valid price."); return; }
                    var selCat = cmbCategory.SelectedItem as ComboItem;
                    if (selCat == null || selCat.ID == 0) { MessageHelper.ShowWarning("Please select a category."); return; }
                    decimal.TryParse(txtCostPrice.Text, out decimal costPrice);
                    if (!int.TryParse(txtQuantityInStock.Text, out int quantityInStock)) { MessageHelper.ShowWarning("Please enter a valid quantity."); return; }
                    var selectedType = (cmbProductType.SelectedItem as ComboBoxItem)?.Value ?? "Other";
                    try
                    {
                        btnSave.Enabled = false; btnSave.Text = "Saving...";
                        var dto = new UpdateProductDTO { ProductID = product.ProductID, ProductName = txtProductName.Text.Trim(), ProductNameAr = txtProductNameAr.Text.Trim(), CategoryID = selCat.ID, Barcode = txtBarcode.Text.Trim(), UnitPrice = unitPrice, CostPrice = costPrice, Description = txtDescription.Text.Trim(), ProductType = selectedType, QuantityInStock = quantityInStock, IsActive = chkActive.Checked };
                        if (await ApiHelper.PutAsync<Product>("products/" + product.ProductID, dto) != null)
                        { MessageHelper.ShowSuccess("Product updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
                };
                if (dlg.ShowDialog(this) == DialogResult.OK) _ = LoadProducts();
            }
        }


        private async void DeleteProduct(Product product)
        {
            if (product.ProductType == "Book") { MessageHelper.ShowWarning("To delete a book, please use the Books section."); return; }
            if (!MessageHelper.ShowConfirm($"Delete \"{product.ProductName}\"?\nThis action cannot be undone.")) return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("products/" + product.ProductID);
                MessageHelper.ShowSuccess("Product deleted successfully.");
                await LoadProducts();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }


        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_products); return; }
            string s = text.ToLower();
            var filtered = new List<Product>();
            foreach (var p in _products)
                if (p.ProductName.ToLower().Contains(s) ||
                   (p.Barcode != null && p.Barcode.ToLower().Contains(s)) ||
                   (p.CategoryName != null && p.CategoryName.ToLower().Contains(s)) ||
                   (p.ProductType != null && p.ProductType.ToLower().Contains(s)))
                    filtered.Add(p);
            BindGrid(filtered);
        }


        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadProducts();
        }


        private class ComboItem
        {
            public int ID { get; set; }
            public string Name { get; set; } = "";
            public override string ToString() => Name;
        }

        private class ComboBoxItem
        {
            public string Text { get; set; } = "";
            public string Value { get; set; } = "";
            public override string ToString() => Text;
        }
    }
}