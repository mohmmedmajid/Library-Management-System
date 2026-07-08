using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Purchasing;
using LibrarySystem.WinForms.Models.Sales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    public partial class FrmPurchaseInvoice : Form
    {
        private const decimal TAX_PERCENT = 16m;
        private const int INVOICE_TYPE_PURCHASE = 6;

        private List<Supplier> _suppliers = new List<Supplier>();
        private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();
        private Product _selectedProduct = null;
        private string _currentInvoiceNumber = null;

        private PrintInvoiceData _lastInvoiceForPrint = null;

        public FrmPurchaseInvoice()
        {
            InitializeComponent();
            dgvItems.CellEndEdit += DgvItems_CellEndEdit;
        }

        private async void FrmPurchaseInvoice_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin)
            {
                MessageHelper.ShowWarning("Purchase invoices are restricted to Admin users only.");
                this.BeginInvoke(new Action(() => this.Close()));
                return;
            }

            lblDateValue.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm");
            await LoadInvoiceNumber();
            await LoadSuppliers();
            await LoadPaymentMethods();
        }

        private async Task LoadInvoiceNumber()
        {
            try
            {
                var num = await ApiHelper.GetAsync<string>("invoices/next-number");
                _currentInvoiceNumber = !string.IsNullOrWhiteSpace(num) ? num : GenerateFallbackInvoiceNumber();
            }
            catch
            {
                _currentInvoiceNumber = GenerateFallbackInvoiceNumber();
            }

            lblInvoiceNumber.Text = "Invoice #: " + _currentInvoiceNumber;
        }

        private string GenerateFallbackInvoiceNumber()
        {
            return "PUR-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private async Task LoadSuppliers()
        {
            try
            {
                var list = await ApiHelper.GetAsync<List<Supplier>>("suppliers");
                _suppliers = list ?? new List<Supplier>();

                var blank = new Supplier { SupplierID = 0, SupplierName = "-- Select Supplier --" };
                _suppliers.Insert(0, blank);

                cmbSupplier.SelectedIndexChanged -= cmbSupplier_SelectedIndexChanged;

                cmbSupplier.DataSource = null;
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierID";
                cmbSupplier.DataSource = _suppliers;

                if (cmbSupplier.Items.Count > 0)
                    cmbSupplier.SelectedIndex = 0;

                cmbSupplier.SelectedIndexChanged += cmbSupplier_SelectedIndexChanged;
                cmbSupplier_SelectedIndexChanged(cmbSupplier, EventArgs.Empty);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading suppliers: " + ex.Message); }
        }

        private async Task LoadPaymentMethods()
        {
            try
            {
                var list = await ApiHelper.GetAsync<List<PaymentMethod>>("paymentmethods");
                _paymentMethods = list ?? new List<PaymentMethod>();
                cmbPaymentMethod.DataSource = _paymentMethods;
                cmbPaymentMethod.DisplayMember = "MethodName";
                cmbPaymentMethod.ValueMember = "PaymentMethodID";
            }
            catch { }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier s = cmbSupplier.SelectedItem as Supplier;
            if (s != null && s.SupplierID > 0)
            {
                if (s.TotalDebt > 0)
                {
                    lblSupplierDebt.Text = "⚠ Outstanding Debt to Supplier: " + s.TotalDebt.ToString("F3");
                    lblSupplierDebt.ForeColor = Color.FromArgb(200, 50, 50);
                }
                else
                {
                    lblSupplierDebt.Text = "✔ No outstanding debt";
                    lblSupplierDebt.ForeColor = Color.FromArgb(40, 160, 100);
                }
            }
            else
            {
                lblSupplierDebt.Text = "";
            }
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            var dlg = new Form
            {
                Text = "➕ Add Supplier",
                Size = new Size(480, 420),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(480, 50),
                BackColor = Color.FromArgb(22, 32, 50)
            };
            pnlHead.Controls.Add(new Label
            {
                Text = "➕ Add Supplier",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(15, 12),
                Size = new Size(450, 28)
            });
            dlg.Controls.Add(pnlHead);

            int y = 68; int lx = 20; int fx = 20; int fw = 430;

            dlg.Controls.Add(new Label { Text = "Supplier Name *", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtName = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtName); y += 44;

            dlg.Controls.Add(new Label { Text = "Phone", Location = new Point(lx, y), Size = new Size(200, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) });
            dlg.Controls.Add(new Label { Text = "Email", Location = new Point(235, y), Size = new Size(215, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtPhone = new TextBox { Location = new Point(fx, y), Size = new Size(200, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtPhone);
            var txtEmail = new TextBox { Location = new Point(235, y), Size = new Size(215, 30), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f) };
            dlg.Controls.Add(txtEmail); y += 44;

            dlg.Controls.Add(new Label { Text = "Address", Location = new Point(lx, y), Size = new Size(fw, 22), Font = new Font("Segoe UI", 9f, FontStyle.Bold), ForeColor = Color.FromArgb(60, 60, 60) }); y += 24;
            var txtAddress = new TextBox { Location = new Point(fx, y), Size = new Size(fw, 55), BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 10f), Multiline = true };
            dlg.Controls.Add(txtAddress); y += 68;

            var btnSaveSup = new Button
            {
                Text = "💾 Save",
                Location = new Point(fx, y),
                Size = new Size(205, 42),
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSaveSup.FlatAppearance.BorderSize = 0;
            dlg.Controls.Add(btnSaveSup);

            var btnCancelSup = new Button
            {
                Text = "✕ Cancel",
                Location = new Point(fx + 220, y),
                Size = new Size(205, 42),
                BackColor = Color.FromArgb(160, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancelSup.FlatAppearance.BorderSize = 0;
            btnCancelSup.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancelSup);

            dlg.Size = new Size(480, y + 100);

            btnSaveSup.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                { MessageHelper.ShowWarning("Please enter supplier name."); return; }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !ValidationHelper.IsValidEmail(txtEmail.Text))
                { MessageHelper.ShowWarning("Please enter a valid email address."); return; }

                if (!string.IsNullOrWhiteSpace(txtPhone.Text) && !ValidationHelper.IsValidPhone(txtPhone.Text))
                { MessageHelper.ShowWarning("Please enter a valid phone number."); return; }

                try
                {
                    btnSaveSup.Enabled = false;
                    btnSaveSup.Text = "Saving...";

                    var dto = new CreateSupplierDTO
                    {
                        SupplierName = txtName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        CreatedBy = SessionManager.UserId
                    };

                    var created = await ApiHelper.PostAsync<Supplier>("suppliers", dto);
                    if (created != null)
                    {
                        MessageHelper.ShowSuccess("Supplier added successfully!");
                        dlg.DialogResult = DialogResult.OK;
                        dlg.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error: " + ex.Message);
                    btnSaveSup.Enabled = true;
                    btnSaveSup.Text = "💾 Save";
                }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _ = ReloadAndSelectNewSupplier();
            }
        }

        private async Task ReloadAndSelectNewSupplier()
        {
            try
            {
                var list = await ApiHelper.GetAsync<List<Supplier>>("suppliers");
                _suppliers = list ?? new List<Supplier>();

                var blank = new Supplier { SupplierID = 0, SupplierName = "-- Select Supplier --" };
                _suppliers.Insert(0, blank);

                cmbSupplier.SelectedIndexChanged -= cmbSupplier_SelectedIndexChanged;

                cmbSupplier.DataSource = null;
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierID";
                cmbSupplier.DataSource = _suppliers;

                if (_suppliers.Count > 1)
                    cmbSupplier.SelectedIndex = _suppliers.Count - 1;
                else if (cmbSupplier.Items.Count > 0)
                    cmbSupplier.SelectedIndex = 0;

                cmbSupplier.SelectedIndexChanged += cmbSupplier_SelectedIndexChanged;
                cmbSupplier_SelectedIndexChanged(cmbSupplier, EventArgs.Empty);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error reloading suppliers: " + ex.Message); }
        }

        private void cmbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isCredit = cmbPaymentType.SelectedItem != null &&
                            cmbPaymentType.SelectedItem.ToString() == "Credit";

            if (isCredit)
            {
                txtPaid.Text = "0";
                txtPaid.ReadOnly = true;
            }
            else
            {
                txtPaid.ReadOnly = false;
            }

            RecalcTotals();
        }

        private async void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string term = txtSearchProduct.Text.Trim();
            if (string.IsNullOrEmpty(term)) return;

            try
            {
                var results = await ApiHelper.GetAsync<List<Product>>("products/search?term=" + term);
                if (results == null || results.Count == 0)
                {
                    MessageHelper.ShowWarning("No products found.");
                    return;
                }

                if (results.Count == 1)
                {
                    _selectedProduct = results[0];
                    txtSearchProduct.Text = _selectedProduct.ProductName;
                }
                else
                {
                    ShowProductPicker(results);
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Search error: " + ex.Message); }
        }

        private void ShowProductPicker(List<Product> products)
        {
            Form dlg = new Form();
            dlg.Text = "Select Product";
            dlg.Size = new Size(450, 380);
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.MaximizeBox = false;
            dlg.MinimizeBox = false;

            ListBox lb = new ListBox();
            lb.Dock = DockStyle.Fill;
            lb.Font = new Font("Segoe UI", 10f);

            foreach (var p in products)
                lb.Items.Add(p.ProductName + "  |  " + p.Barcode + "  |  Cost: " + p.CostPrice.ToString("F3") + "  |  In Stock: " + p.QuantityInStock);

            Button btn = new Button();
            btn.Text = "Select";
            btn.Dock = DockStyle.Bottom;
            btn.Height = 38;
            btn.BackColor = Color.FromArgb(30, 100, 180);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.FlatAppearance.BorderSize = 0;

            List<Product> capturedProducts = products;
            btn.Click += delegate
            {
                if (lb.SelectedIndex >= 0)
                {
                    _selectedProduct = capturedProducts[lb.SelectedIndex];
                    txtSearchProduct.Text = _selectedProduct.ProductName;
                    dlg.Close();
                }
            };

            dlg.Controls.Add(lb);
            dlg.Controls.Add(btn);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LookupAndAddByBarcode();
            }
        }

        private async void btnBarcodeSearch_Click(object sender, EventArgs e)
        {
            await LookupAndAddByBarcode();
        }

        private async Task LookupAndAddByBarcode()
        {
            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(barcode)) return;
            try
            {
                var product = await ApiHelper.GetAsync<Product>("products/by-barcode?barcode=" + barcode);
                if (product == null)
                {
                    MessageHelper.ShowWarning("Product not found for barcode: " + barcode);
                    return;
                }
                _selectedProduct = product;
                txtSearchProduct.Text = product.ProductName;
                txtBarcode.Clear();
                AddSelectedProductToGrid();
            }
            catch (Exception ex) { MessageHelper.ShowError("Barcode error: " + ex.Message); }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddSelectedProductToGrid();
        }

        private void AddSelectedProductToGrid()
        {
            if (_selectedProduct == null)
            {
                MessageHelper.ShowWarning("Please search and select a product first.");
                return;
            }

            int qty = (int)nudQty.Value;
            if (qty <= 0)
            {
                MessageHelper.ShowWarning("Quantity must be > 0.");
                return;
            }

            decimal discPct = 0;
            decimal.TryParse(txtDiscount.Text, out discPct);
            if (discPct < 0 || discPct > 100)
            {
                MessageHelper.ShowWarning("Discount must be 0-100.");
                return;
            }

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Cells["colProductID"].Value != null &&
                    row.Cells["colProductID"].Value.ToString() == _selectedProduct.ProductID.ToString())
                {
                    int existQty = 0;
                    string qtyStr = row.Cells["colQty"].Value != null ? row.Cells["colQty"].Value.ToString() : "0";
                    int.TryParse(qtyStr, out existQty);
                    existQty += qty;
                    row.Cells["colQty"].Value = existQty;
                    RecalcRow(row);
                    RecalcTotals();
                    ResetProductInput();
                    return;
                }
            }

            decimal costPrice = _selectedProduct.CostPrice;
            decimal discAmt = Math.Round(costPrice * qty * discPct / 100, 3);
            decimal total = Math.Round(costPrice * qty - discAmt, 3);

            dgvItems.Rows.Add(
                _selectedProduct.ProductID,
                _selectedProduct.ProductName,
                _selectedProduct.Barcode,
                qty,
                costPrice.ToString("F3"),
                discPct.ToString("F2"),
                discAmt.ToString("F3"),
                total.ToString("F3")
            );

            RecalcTotals();
            ResetProductInput();
        }

        private void ResetProductInput()
        {
            _selectedProduct = null;
            txtSearchProduct.Clear();
            nudQty.Value = 1;
            txtDiscount.Text = "0";
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvItems.Columns["colDelete"].Index)
            {
                if (MessageHelper.ShowConfirm("Remove this item?"))
                {
                    dgvItems.Rows.RemoveAt(e.RowIndex);
                    RecalcTotals();
                }
            }
            else if (e.ColumnIndex == dgvItems.Columns["colEdit"].Index)
            {
                EditRowQuantity(dgvItems.Rows[e.RowIndex]);
            }
        }

        private void EditRowQuantity(DataGridViewRow row)
        {
            int currentQty = 0;
            int.TryParse(row.Cells["colQty"].Value != null ? row.Cells["colQty"].Value.ToString() : "0", out currentQty);

            int maxStock = 99999;

            Form dlg = new Form
            {
                Text = "Edit Quantity",
                Size = new Size(300, 180),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 10f)
            };

            var lbl = new Label
            {
                Text = "Product: " + row.Cells["colProductName"].Value,
                Location = new Point(15, 15),
                Size = new Size(260, 22)
            };
            dlg.Controls.Add(lbl);

            var nud = new NumericUpDown
            {
                Location = new Point(15, 45),
                Size = new Size(260, 28),
                Minimum = 1,
                Maximum = maxStock,
                Value = currentQty > 0 ? currentQty : 1,
                Font = new Font("Segoe UI", 11f)
            };
            dlg.Controls.Add(nud);

            var btnOk = new Button
            {
                Text = "Save",
                Location = new Point(15, 90),
                Size = new Size(120, 36),
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += (s, ev) =>
            {
                row.Cells["colQty"].Value = (int)nud.Value;
                RecalcRow(row);
                RecalcTotals();
                dlg.DialogResult = DialogResult.OK;
                dlg.Close();
            };
            dlg.Controls.Add(btnOk);

            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(155, 90),
                Size = new Size(120, 36),
                BackColor = Color.FromArgb(160, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, ev) => dlg.Close();
            dlg.Controls.Add(btnCancel);

            dlg.ShowDialog(this);
        }

        private async void btnBrowseProducts_Click(object sender, EventArgs e)
        {
            try
            {
                var products = await ApiHelper.GetAsync<List<Product>>("products");
                if (products == null || products.Count == 0)
                {
                    MessageHelper.ShowWarning("No products found.");
                    return;
                }
                ShowProductBrowser(products);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading products: " + ex.Message); }
        }

        private void ShowProductBrowser(List<Product> products)
        {
            Form dlg = new Form
            {
                Text = "📋 Browse Products",
                Size = new Size(820, 560),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.Sizable,
                MinimumSize = new Size(650, 420),
                Font = new Font("Segoe UI", 10f)
            };

            var pnlHead = new Panel
            {
                Dock = DockStyle.Top,
                Height = 6,
                BackColor = Color.FromArgb(22, 32, 50)
            };
            dlg.Controls.Add(pnlHead);

            var pnlCategories = new Panel
            {
                Dock = DockStyle.Left,
                Width = 170,
                Padding = new Padding(0, 0, 4, 0)
            };

            var lstCategories = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5f),
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(245, 247, 250),
                IntegralHeight = false
            };
            pnlCategories.Controls.Add(lstCategories);

            var pnlGrid = new Panel
            {
                Dock = DockStyle.Fill
            };

            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                Font = new Font("Segoe UI", 9.5f),
                ColumnHeadersHeight = 34
            };
            grid.RowTemplate.Height = 30;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 32, 50);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.EnableHeadersVisualStyles = false;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            grid.Columns.Add("Name", "Product Name");
            grid.Columns.Add("Barcode", "Barcode");
            grid.Columns.Add("Cost", "Cost Price");
            grid.Columns.Add("Qty", "In Stock");
            grid.Columns["Name"].FillWeight = 42;
            grid.Columns["Barcode"].FillWeight = 25;
            grid.Columns["Cost"].FillWeight = 16;
            grid.Columns["Qty"].FillWeight = 17;
            grid.Columns["Cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var grouped = new Dictionary<string, List<Product>>();
            foreach (var p in products)
            {
                string cat = string.IsNullOrWhiteSpace(p.CategoryName) ? "Uncategorized" : p.CategoryName;
                if (!grouped.ContainsKey(cat))
                    grouped[cat] = new List<Product>();
                grouped[cat].Add(p);
            }

            lstCategories.Items.Add("All");
            foreach (var key in grouped.Keys)
                lstCategories.Items.Add(key);

            void FillGrid(string category)
            {
                grid.Rows.Clear();
                List<Product> list = category == "All" ? products : grouped[category];
                foreach (var p in list)
                {
                    int idx = grid.Rows.Add(p.ProductName, p.Barcode, p.CostPrice.ToString("F3"), p.QuantityInStock);
                    grid.Rows[idx].Tag = p;
                }
            }

            lstCategories.SelectedIndexChanged += (s, ev) =>
            {
                if (lstCategories.SelectedItem != null)
                    FillGrid(lstCategories.SelectedItem.ToString());
            };

            var btnSelect = new Button
            {
                Text = "✔ Select",
                Dock = DockStyle.Bottom,
                Height = 44,
                BackColor = Color.FromArgb(30, 100, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += (s, ev) =>
            {
                if (grid.SelectedRows.Count > 0)
                {
                    var p = grid.SelectedRows[0].Tag as Product;
                    if (p != null)
                    {
                        _selectedProduct = p;
                        txtSearchProduct.Text = p.ProductName;
                        dlg.Close();
                    }
                }
                else
                {
                    MessageHelper.ShowWarning("Please select a product first.");
                }
            };

            grid.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    var p = grid.Rows[ev.RowIndex].Tag as Product;
                    if (p != null)
                    {
                        _selectedProduct = p;
                        txtSearchProduct.Text = p.ProductName;
                        dlg.Close();
                    }
                }
            };

            pnlGrid.Controls.Add(grid);

            dlg.Controls.Add(pnlGrid);
            dlg.Controls.Add(pnlCategories);
            dlg.Controls.Add(btnSelect);

            lstCategories.SelectedIndex = 0;

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void DgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            RecalcRow(dgvItems.Rows[e.RowIndex]);
            RecalcTotals();
        }

        private void RecalcRow(DataGridViewRow row)
        {
            decimal price = 0;
            int qty = 0;
            decimal discPct = 0;

            string priceStr = row.Cells["colCostPrice"].Value != null ? row.Cells["colCostPrice"].Value.ToString() : "";
            string qtyStr = row.Cells["colQty"].Value != null ? row.Cells["colQty"].Value.ToString() : "";
            string discStr = row.Cells["colDiscountPct"].Value != null ? row.Cells["colDiscountPct"].Value.ToString() : "0";

            if (!decimal.TryParse(priceStr, out price)) return;
            if (!int.TryParse(qtyStr, out qty)) return;
            decimal.TryParse(discStr, out discPct);

            decimal discAmt = Math.Round(price * qty * discPct / 100, 3);
            decimal total = Math.Round(price * qty - discAmt, 3);

            row.Cells["colDiscountAmt"].Value = discAmt.ToString("F3");
            row.Cells["colTotal"].Value = total.ToString("F3");
        }

        private void txtInvoiceDiscount_TextChanged(object sender, EventArgs e)
        {
            RecalcTotals();
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            RecalcTotals();
        }

        private void RecalcTotals()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal rowTotal = 0;
                string totalStr = row.Cells["colTotal"].Value != null ? row.Cells["colTotal"].Value.ToString() : "";
                if (decimal.TryParse(totalStr, out rowTotal))
                    subTotal += rowTotal;
            }

            decimal invDiscount = 0;
            decimal.TryParse(txtInvoiceDiscount.Text, out invDiscount);

            decimal afterDiscount = subTotal - invDiscount;
            if (afterDiscount < 0) afterDiscount = 0;

            decimal tax = Math.Round(afterDiscount * TAX_PERCENT / 100, 3);
            decimal total = afterDiscount + tax;

            decimal paid = 0;
            decimal.TryParse(txtPaid.Text, out paid);

            decimal remaining = total - paid;

            lblSubTotal.Text = subTotal.ToString("F3");
            lblTaxValue.Text = tax.ToString("F3");
            lblTotal.Text = total.ToString("F3");

            if (remaining > 0)
            {
                lblRemainingLabel.Text = "We Owe Supplier (Debit):";
                lblRemaining.Text = remaining.ToString("F3");
                lblRemaining.ForeColor = Color.FromArgb(200, 50, 50);
            }
            else if (remaining < 0)
            {
                lblRemainingLabel.Text = "Supplier Owes Us (Credit):";
                lblRemaining.Text = Math.Abs(remaining).ToString("F3");
                lblRemaining.ForeColor = Color.FromArgb(40, 160, 100);
            }
            else
            {
                lblRemainingLabel.Text = "Status:";
                lblRemaining.Text = "Fully Paid";
                lblRemaining.ForeColor = Color.FromArgb(40, 160, 100);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInvoice()) return;

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Saving...";

                if (string.IsNullOrWhiteSpace(_currentInvoiceNumber))
                    _currentInvoiceNumber = GenerateFallbackInvoiceNumber();

                var dto = BuildDTO();

                _lastInvoiceForPrint = BuildPrintData(dto);

                var result = await ApiHelper.PostAsync<Invoice>("invoices/with-details", dto);

                if (result != null)
                {
                    string finalInvoiceNumber = !string.IsNullOrWhiteSpace(result.InvoiceNumber)
                        ? result.InvoiceNumber
                        : _currentInvoiceNumber;

                    _lastInvoiceForPrint.InvoiceNumber = finalInvoiceNumber;

                    decimal paid = 0;
                    decimal.TryParse(txtPaid.Text, out paid);
                    decimal remaining = dto.TotalAmount - paid;

                    string statusMsg;
                    if (remaining > 0)
                        statusMsg = "We owe the supplier: " + remaining.ToString("F3");
                    else if (remaining < 0)
                        statusMsg = "Supplier owes us: " + Math.Abs(remaining).ToString("F3");
                    else
                        statusMsg = "Invoice fully paid";

                    string summary = "Purchase invoice saved!\nInvoice #: " + finalInvoiceNumber +
                                      "\nPaid: " + paid.ToString("F3") +
                                      "\n" + statusMsg +
                                      "\n\nDo you want to print it now?";

                    if (MessageHelper.ShowConfirm(summary))
                    {
                        if (chkThermalPrint.Checked)
                            InvoicePrinter.PrintInvoiceThermal(_lastInvoiceForPrint, showPreview: true);
                        else
                            InvoicePrinter.PrintInvoice(_lastInvoiceForPrint, showPreview: true);
                    }

                    ClearForm();
                    await LoadInvoiceNumber();
                }
                else
                {
                    MessageHelper.ShowError("Failed to save purchase invoice.");
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Save error: " + ex.Message); }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Save";
            }
        }

        private bool ValidateInvoice()
        {
            if (dgvItems.Rows.Count == 0)
            {
                MessageHelper.ShowWarning("Please add at least one product.");
                return false;
            }

            Supplier supplier = cmbSupplier.SelectedItem as Supplier;
            if (supplier == null || supplier.SupplierID == 0)
            {
                MessageHelper.ShowWarning("Please select a supplier.");
                return false;
            }

            decimal paid = 0;
            if (!decimal.TryParse(txtPaid.Text, out paid) || paid < 0)
            {
                MessageHelper.ShowWarning("Invalid paid amount.");
                return false;
            }

            decimal disc = 0;
            if (!decimal.TryParse(txtInvoiceDiscount.Text, out disc) || disc < 0)
            {
                MessageHelper.ShowWarning("Invalid discount.");
                return false;
            }

            return true;
        }

        private CreatePurchaseInvoiceWithDetailsDTO BuildDTO()
        {
            decimal subTotal = 0;
            decimal.TryParse(lblSubTotal.Text, out subTotal);
            decimal invDiscount = 0;
            decimal.TryParse(txtInvoiceDiscount.Text, out invDiscount);
            decimal tax = 0;
            decimal.TryParse(lblTaxValue.Text, out tax);
            decimal total = 0;
            decimal.TryParse(lblTotal.Text, out total);
            decimal paidEntered = 0;
            decimal.TryParse(txtPaid.Text, out paidEntered);

            decimal paidForApi = Math.Min(paidEntered, total);
            decimal remaining = total - paidEntered;

            string payType = cmbPaymentType.SelectedItem != null ? cmbPaymentType.SelectedItem.ToString() : "Cash";

            Supplier supplier = cmbSupplier.SelectedItem as Supplier;
            int supplierID = supplier != null ? supplier.SupplierID : 0;

            PaymentMethod pm = cmbPaymentMethod.SelectedItem as PaymentMethod;
            int payMethodID = pm != null ? pm.PaymentMethodID : 1;

            var details = new List<InvoiceDetailItemDTO>();
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal up = 0;
                decimal.TryParse(row.Cells["colCostPrice"].Value != null ? row.Cells["colCostPrice"].Value.ToString() : "0", out up);
                int qty = 0;
                int.TryParse(row.Cells["colQty"].Value != null ? row.Cells["colQty"].Value.ToString() : "0", out qty);
                decimal dp = 0;
                decimal.TryParse(row.Cells["colDiscountPct"].Value != null ? row.Cells["colDiscountPct"].Value.ToString() : "0", out dp);
                decimal da = 0;
                decimal.TryParse(row.Cells["colDiscountAmt"].Value != null ? row.Cells["colDiscountAmt"].Value.ToString() : "0", out da);
                decimal tot = 0;
                decimal.TryParse(row.Cells["colTotal"].Value != null ? row.Cells["colTotal"].Value.ToString() : "0", out tot);
                int pid = 0;
                int.TryParse(row.Cells["colProductID"].Value != null ? row.Cells["colProductID"].Value.ToString() : "0", out pid);

                details.Add(new InvoiceDetailItemDTO
                {
                    ProductID = pid,
                    Quantity = qty,
                    UnitPrice = up,
                    DiscountPercent = dp,
                    DiscountAmount = da,
                    TotalPrice = tot
                });
            }

            return new CreatePurchaseInvoiceWithDetailsDTO
            {
                InvoiceNumber = _currentInvoiceNumber,
                InvoiceDate = DateTime.Now,
                InvoiceTypeID = INVOICE_TYPE_PURCHASE,
                SupplierID = supplierID,
                PaymentMethodID = payMethodID,
                PaymentType = payType,
                SubTotal = subTotal,
                DiscountAmount = invDiscount,
                TaxAmount = tax,
                TaxPercent = TAX_PERCENT,
                TotalAmount = total,
                PaidAmount = paidForApi,
                RemainingAmount = Math.Max(remaining, 0),
                Notes = txtNotes.Text.Trim(),
                Status = "Completed",
                CreatedBy = SessionManager.UserId,
                Details = details
            };
        }

        private PrintInvoiceData BuildPrintData(CreatePurchaseInvoiceWithDetailsDTO dto)
        {
            Supplier supplier = cmbSupplier.SelectedItem as Supplier;
            PaymentMethod pm = cmbPaymentMethod.SelectedItem as PaymentMethod;

            decimal actualPaid = 0;
            decimal.TryParse(txtPaid.Text, out actualPaid);
            decimal remaining = dto.TotalAmount - actualPaid;

            string statusNote;
            if (remaining > 0)
                statusNote = "We owe supplier: " + remaining.ToString("F3");
            else if (remaining < 0)
                statusNote = "Supplier owes us: " + Math.Abs(remaining).ToString("F3");
            else
                statusNote = "Fully paid";

            var data = new PrintInvoiceData
            {
                InvoiceNumber = dto.InvoiceNumber,
                InvoiceDate = dto.InvoiceDate,
                CustomerName = (supplier != null && supplier.SupplierID > 0) ? supplier.SupplierName : "Unknown Supplier",
                PaymentType = dto.PaymentType,
                PaymentMethod = pm != null ? pm.MethodName : "Cash",
                SalesRepName = "",
                Notes = string.IsNullOrWhiteSpace(dto.Notes) ? statusNote : dto.Notes + " | " + statusNote,
                SubTotal = dto.SubTotal,
                DiscountAmount = dto.DiscountAmount,
                TaxAmount = dto.TaxAmount,
                TaxPercent = dto.TaxPercent,
                TotalAmount = dto.TotalAmount,
                PaidAmount = actualPaid,
                RemainingAmount = remaining
            };

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                decimal up = 0, da = 0, tot = 0;
                int qty = 0;
                decimal.TryParse(row.Cells["colCostPrice"].Value != null ? row.Cells["colCostPrice"].Value.ToString() : "0", out up);
                int.TryParse(row.Cells["colQty"].Value != null ? row.Cells["colQty"].Value.ToString() : "0", out qty);
                decimal.TryParse(row.Cells["colDiscountAmt"].Value != null ? row.Cells["colDiscountAmt"].Value.ToString() : "0", out da);
                decimal.TryParse(row.Cells["colTotal"].Value != null ? row.Cells["colTotal"].Value.ToString() : "0", out tot);

                data.Lines.Add(new PrintInvoiceLine
                {
                    ProductName = row.Cells["colProductName"].Value != null ? row.Cells["colProductName"].Value.ToString() : "",
                    Quantity = qty,
                    UnitPrice = up,
                    DiscountAmount = da,
                    Total = tot
                });
            }

            return data;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ShowConfirm("Clear the current invoice?"))
                ClearForm();
        }

        private void ClearForm()
        {
            dgvItems.Rows.Clear();
            cmbSupplier.SelectedIndex = 0;
            cmbPaymentType.SelectedIndex = 0;
            txtInvoiceDiscount.Text = "0";
            txtPaid.Text = "0";
            txtNotes.Clear();
            lblSupplierDebt.Text = "";
            _selectedProduct = null;
            txtSearchProduct.Clear();
            nudQty.Value = 1;
            txtDiscount.Text = "0";
            RecalcTotals();
            lblDateValue.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm");
        }

        private void btnPrintLast_Click(object sender, EventArgs e)
        {
            if (_lastInvoiceForPrint == null)
            {
                MessageHelper.ShowWarning("No saved invoice to print yet. Save an invoice first.");
                return;
            }

            if (chkThermalPrint.Checked)
                InvoicePrinter.PrintInvoiceThermal(_lastInvoiceForPrint, showPreview: true);
            else
                InvoicePrinter.PrintInvoice(_lastInvoiceForPrint, showPreview: true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}