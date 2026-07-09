using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    public partial class FrmBarcodes : Form
    {
        private List<Barcode> _barcodes = new List<Barcode>();
        private List<Product> _products = new List<Product>();
        private int _filterProductId = 0;
        private string _filterProductName = "";

        public FrmBarcodes(int productId = 0, string productName = "")
        {
            InitializeComponent();
            _filterProductId = productId;
            _filterProductName = productName;

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(510, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);

            dgvBarcodes.CellFormatting += DgvBarcodes_CellFormatting;
        }

        // ─────────────────────────────────────────────
        //  CELL FORMATTING
        // ─────────────────────────────────────────────
        private void DgvBarcodes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvBarcodes.Columns["colEdit"].Index;
            int delCol = dgvBarcodes.Columns["colDelete"].Index;

            if (e.ColumnIndex == editCol)
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

        // ─────────────────────────────────────────────
        //  LOAD
        // ─────────────────────────────────────────────
        private async void FrmBarcodes_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvBarcodes.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvBarcodes.Columns["colDelete"].Visible = SessionManager.IsAdmin;

            if (_filterProductId > 0)
                lblTitle.Text = $"🔲 Barcodes - {_filterProductName}";

            await LoadProducts();
            await LoadBarcodes();
        }

        private async System.Threading.Tasks.Task LoadProducts()
        {
            try
            {
                _products = await ApiHelper.GetAsync<List<Product>>("products")
                            ?? new List<Product>();
            }
            catch { }
        }

        private async System.Threading.Tasks.Task LoadBarcodes()
        {
            try
            {
                spinner.Start();
                string endpoint = _filterProductId > 0
                    ? $"barcodes?productId={_filterProductId}"
                    : "barcodes";
                _barcodes = await ApiHelper.GetAsync<List<Barcode>>(endpoint)
                            ?? new List<Barcode>();
                BindGrid(_barcodes);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading barcodes: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  BIND GRID
        // ─────────────────────────────────────────────
        private void BindGrid(List<Barcode> list)
        {
            dgvBarcodes.Rows.Clear();
            foreach (var b in list)
            {
                dgvBarcodes.Rows.Add(
                    b.BarcodeID,
                    b.ProductName,
                    b.BarcodeValue,
                    b.BarcodeType,
                    b.IsDefault ? "✔ Yes" : "No",
                    b.UnitPrice?.ToString("F2") ?? "0.00",
                    b.AvailableQuantity?.ToString() ?? "0",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        // ─────────────────────────────────────────────
        //  GRID CELL CLICK
        // ─────────────────────────────────────────────
        private void dgvBarcodes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int id = Convert.ToInt32(dgvBarcodes.Rows[e.RowIndex].Cells["colID"].Value);
            var barcode = _barcodes.Find(b => b.BarcodeID == id);
            if (barcode == null) return;

            if (e.ColumnIndex == dgvBarcodes.Columns["colEdit"].Index)
                OpenEditDialog(barcode);
            else if (e.ColumnIndex == dgvBarcodes.Columns["colDelete"].Index)
                DeleteBarcode(barcode);
        }

        // ─────────────────────────────────────────────
        //  OPEN EDIT DIALOG
        // ─────────────────────────────────────────────
        private void OpenEditDialog(Barcode barcode = null)
        {
            bool isNew = barcode == null;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add Barcode" : "✏️ Edit Barcode",
                Size = new Size(480, 400),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(480, 50), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = isNew ? "➕ Add Barcode" : "✏️ Edit Barcode", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 12), Size = new Size(440, 28) });
            dlg.Controls.Add(pnlHeader);

            int y = 68; int lx = 20; int fx = 20; int fw = 430;

            dlg.Controls.Add(new Label { Text = "Product *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var cmbProduct = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
            cmbProduct.Items.Add(new ComboItem { ID = 0, Name = "-- Select Product --" });
            foreach (var p in _products)
                cmbProduct.Items.Add(new ComboItem { ID = p.ProductID, Name = p.ProductName });
            cmbProduct.DisplayMember = "Name"; cmbProduct.ValueMember = "ID"; cmbProduct.SelectedIndex = 0;
            if (isNew && _filterProductId > 0)
            {
                foreach (ComboItem ci in cmbProduct.Items)
                    if (ci.ID == _filterProductId) { cmbProduct.SelectedItem = ci; break; }
                cmbProduct.Enabled = false;
            }
            else if (!isNew)
            {
                foreach (ComboItem ci in cmbProduct.Items)
                    if (ci.ID == barcode.ProductID) { cmbProduct.SelectedItem = ci; break; }
            }
            dlg.Controls.Add(cmbProduct); y += 44;

            dlg.Controls.Add(new Label { Text = "Barcode Value *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var txtBarcodeValue = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), Text = isNew ? "" : barcode.BarcodeValue, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtBarcodeValue); y += 44;

            dlg.Controls.Add(new Label { Text = "Barcode Type *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            y += 24;
            var cmbType = new ComboBox { Location = new Point(fx, y), Size = new Size(fw, 30), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f) };
            cmbType.Items.AddRange(new object[] { "EAN13", "CODE128", "QR", "CODE39" });
            cmbType.SelectedIndex = 0;
            if (!isNew) { int idx = cmbType.Items.IndexOf(barcode.BarcodeType); cmbType.SelectedIndex = idx >= 0 ? idx : 0; }
            dlg.Controls.Add(cmbType); y += 44;

            var chkDefault = new CheckBox { Text = "✓ Set as Default", Location = new Point(fx, y), Size = new Size(fw, 28), Checked = !isNew && barcode.IsDefault, Font = new Font("Segoe UI", 10f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkDefault); y += 40;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(fx, y), Size = new Size(205, 42), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0; dlg.Controls.Add(btnSave);

            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(fx + 225, y), Size = new Size(205, 42), BackColor = Color.FromArgb(160, 160, 160), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0; btnCancel.Click += (s, ev) => dlg.Close(); dlg.Controls.Add(btnCancel);

            btnSave.Click += async (s, ev) =>
            {
                var selProduct = cmbProduct.SelectedItem as ComboItem;
                if (selProduct == null || selProduct.ID == 0) { MessageHelper.ShowWarning("Please select a product."); return; }
                if (string.IsNullOrWhiteSpace(txtBarcodeValue.Text)) { MessageHelper.ShowWarning("Please enter barcode value."); return; }
                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var dto = new CreateBarcodeDTO { ProductID = selProduct.ID, BarcodeValue = txtBarcodeValue.Text.Trim(), BarcodeType = cmbType.SelectedItem?.ToString() ?? "EAN13", IsDefault = chkDefault.Checked };
                        if (await ApiHelper.PostAsync<Barcode>("barcodes", dto) != null)
                        { MessageHelper.ShowSuccess("Barcode added!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var dto = new UpdateBarcodeDTO { BarcodeID = barcode.BarcodeID, BarcodeValue = txtBarcodeValue.Text.Trim(), BarcodeType = cmbType.SelectedItem?.ToString() ?? "EAN13", IsDefault = chkDefault.Checked };
                        if (await ApiHelper.PutAsync<Barcode>("barcodes/" + barcode.BarcodeID, dto) != null)
                        { MessageHelper.ShowSuccess("Barcode updated!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadBarcodes();
        }

        // ─────────────────────────────────────────────
        //  DELETE
        // ─────────────────────────────────────────────
        private async void DeleteBarcode(Barcode barcode)
        {
            if (!MessageHelper.ShowConfirm($"Delete barcode \"{barcode.BarcodeValue}\"?\nThis action cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("barcodes/" + barcode.BarcodeID);
                MessageHelper.ShowSuccess("Barcode deleted successfully.");
                await LoadBarcodes();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        // ─────────────────────────────────────────────
        //  SEARCH
        // ─────────────────────────────────────────────
        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_barcodes); return; }
            string s = text.ToLower();
            var filtered = new List<Barcode>();
            foreach (var b in _barcodes)
                if (b.ProductName.ToLower().Contains(s) ||
                    b.BarcodeValue.ToLower().Contains(s) ||
                    b.BarcodeType.ToLower().Contains(s))
                    filtered.Add(b);
            BindGrid(filtered);
        }

        // ─────────────────────────────────────────────
        //  TOP BUTTONS
        // ─────────────────────────────────────────────
        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadBarcodes();
        }

        // ─────────────────────────────────────────────
        //  INNER CLASS
        // ─────────────────────────────────────────────
        private class ComboItem
        {
            public int ID { get; set; }
            public string Name { get; set; } = "";
            public override string ToString() => Name;
        }
    }
}