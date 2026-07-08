using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.DTOs;
using LibrarySystem.WinForms.Models.Sales;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmBorrowInvoice : Form
    {
        private List<Book> _books = new List<Book>();
        private List<Customer> _customers = new List<Customer>();
        private List<BorrowingDetailItemDTO> _details = new List<BorrowingDetailItemDTO>();

        private decimal _subTotal = 0;
        private decimal _totalAmount = 0;
        private int _totalDays = 0;
        private int _editingProductID = -1;
        private Book _selectedBook;

        public FrmBorrowInvoice()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 10);
            spinner.Size = new Size(40, 40);
            pnlHeader.Controls.Add(spinner);

            dgvDetails.CellFormatting += DgvDetails_CellFormatting;
            dgvDetails.CellClick += DgvDetails_CellClick;
        }

        private void DgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == dgvDetails.Columns["colDetailDelete"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(200, 50, 50);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(170, 30, 30);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == dgvDetails.Columns["colDetailEdit"].Index)
            {
                e.CellStyle.BackColor = Color.FromArgb(40, 110, 200);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmBorrowInvoice_Load(object sender, EventArgs e)
        {
            grpDetails.Width = pnlRight.Width - grpDetails.Left - 8;
            dgvDetails.Width = grpDetails.Width - 16;

            grpSummary.Width = pnlRight.Width - grpSummary.Left - 8;
            pnlTotalBar.Width = grpSummary.Width - 16;

            try
            {
                spinner.Start();
                await LoadLookups();
                GenerateBorrowNumber();
                dtpBorrowDate.Value = DateTime.Today;
                nudDays.Value = 7;
                UpdateReturnDate();
                UpdateTotals();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading form: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private async System.Threading.Tasks.Task LoadLookups()
        {
            _customers = await ApiHelper.GetAsync<List<Customer>>("customers") ?? new List<Customer>();
            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add(new ComboItem { ID = 0, Name = "-- Select Customer --" });
            foreach (var c in _customers.Where(x => x.IsActive))
                cmbCustomer.Items.Add(new ComboItem { ID = c.CustomerID, Name = $"{c.CustomerName} | {c.Phone}" });
            cmbCustomer.SelectedIndex = 0;

            _books = await ApiHelper.GetAsync<List<Book>>("books") ?? new List<Book>();
        }

        private void GenerateBorrowNumber()
        {
            txtBorrowNumber.Text = "BRW-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }

        private void nudDays_ValueChanged(object sender, EventArgs e)
        {
            UpdateReturnDate();
            UpdateTotals();
        }

        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateReturnDate();
        }

        private void UpdateReturnDate()
        {
            _totalDays = (int)nudDays.Value;
            dtpReturnDate.Value = dtpBorrowDate.Value.AddDays(_totalDays);
        }

        private void btnSelectBook_Click(object sender, EventArgs e)
        {
            using (var picker = new FrmBookPicker(_books))
            {
                if (picker.ShowDialog(this) == DialogResult.OK && picker.SelectedBook != null)
                {
                    _selectedBook = picker.SelectedBook;
                    txtSelectedBook.Text = $"{_selectedBook.ProductName} | {_selectedBook.Author}";
                    txtPricePerDay.Text = _selectedBook.BorrowPricePerDay.ToString("F2");
                    txtQty.Focus();
                    txtQty.SelectAll();
                }
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            if (_selectedBook == null)
            { MessageHelper.ShowWarning("Please select a book."); return; }

            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            { MessageHelper.ShowWarning("Please enter a valid quantity."); return; }

            if (!decimal.TryParse(txtPricePerDay.Text, out decimal pricePerDay) || pricePerDay < 0)
            { MessageHelper.ShowWarning("Please enter a valid price per day."); return; }

            var book = _books.FirstOrDefault(b => b.ProductID == _selectedBook.ProductID);
            if (book == null) return;

            int days = _totalDays;
            decimal total = pricePerDay * qty * days;

            if (_editingProductID != -1)
            {
                var editing = _details.FirstOrDefault(d => d.ProductID == _editingProductID);
                if (editing != null)
                {
                    if (qty > (book.AvailableQuantity ?? 0))
                    { MessageHelper.ShowWarning($"Not enough stock. Available: {book.AvailableQuantity}"); return; }

                    editing.ProductID = book.ProductID;
                    editing.Quantity = qty;
                    editing.PricePerDay = pricePerDay;
                    editing.TotalDays = days;
                    editing.TotalPrice = total;
                }
                _editingProductID = -1;
                btnAddBook.Text = "➕ Add Book";
                btnCancelEdit.Visible = false;
            }
            else
            {
                if (qty > (book.AvailableQuantity ?? 0))
                { MessageHelper.ShowWarning($"Not enough stock. Available: {book.AvailableQuantity}"); return; }

                var existing = _details.FirstOrDefault(d => d.ProductID == book.ProductID);
                if (existing != null)
                {
                    int newQty = existing.Quantity + qty;
                    if (newQty > (book.AvailableQuantity ?? 0))
                    { MessageHelper.ShowWarning($"Total quantity exceeds available stock: {book.AvailableQuantity}"); return; }
                    existing.Quantity = newQty;
                    existing.TotalPrice = existing.PricePerDay * newQty * days;
                }
                else
                {
                    _details.Add(new BorrowingDetailItemDTO
                    {
                        ProductID = book.ProductID,
                        Quantity = qty,
                        PricePerDay = pricePerDay,
                        TotalDays = days,
                        TotalPrice = total
                    });
                }
            }

            BindDetailsGrid();
            UpdateTotals();
            ResetBookInput();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ResetBookInput();
        }

        private void ResetBookInput()
        {
            _selectedBook = null;
            txtSelectedBook.Text = "";
            txtQty.Text = "1";
            txtPricePerDay.Text = "0.00";
            _editingProductID = -1;
            btnAddBook.Text = "➕ Add Book";
            btnCancelEdit.Visible = false;
            txtSelectedBook.Focus();
        }

        private void BindDetailsGrid()
        {
            dgvDetails.Rows.Clear();
            foreach (var d in _details)
            {
                var book = _books.FirstOrDefault(b => b.ProductID == d.ProductID);
                string name = book?.ProductName ?? "";
                string author = book?.Author ?? "";
                dgvDetails.Rows.Add(
                    d.ProductID,
                    name,
                    author,
                    d.Quantity,
                    d.PricePerDay.ToString("F2"),
                    _totalDays,
                    d.TotalPrice.ToString("F2"),
                    "✏",
                    "🗑"
                );
            }
        }

        private void DgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int productID = Convert.ToInt32(dgvDetails.Rows[e.RowIndex].Cells["colDetailProductID"].Value);

            if (e.ColumnIndex == dgvDetails.Columns["colDetailDelete"].Index)
            {
                _details.RemoveAll(d => d.ProductID == productID);
                BindDetailsGrid();
                UpdateTotals();
            }
            else if (e.ColumnIndex == dgvDetails.Columns["colDetailEdit"].Index)
            {
                var detail = _details.FirstOrDefault(d => d.ProductID == productID);
                if (detail == null) return;

                _selectedBook = _books.FirstOrDefault(b => b.ProductID == productID);
                txtSelectedBook.Text = _selectedBook != null ? $"{_selectedBook.ProductName} | {_selectedBook.Author}" : "";

                txtQty.Text = detail.Quantity.ToString();
                txtPricePerDay.Text = detail.PricePerDay.ToString("F2");

                _editingProductID = productID;
                btnAddBook.Text = "✏ Update Book";
                btnCancelEdit.Visible = true;
            }
        }

        private void UpdateTotals()
        {
            _totalDays = (int)nudDays.Value;
            foreach (var d in _details)
            {
                d.TotalDays = _totalDays;
                d.TotalPrice = d.PricePerDay * d.Quantity * _totalDays;
            }

            _subTotal = _details.Sum(d => d.TotalPrice);

            decimal.TryParse(txtDiscount.Text, out decimal disc);
            if (disc < 0) disc = 0;
            if (disc > _subTotal) disc = _subTotal;

            _totalAmount = _subTotal - disc;

            lblTotalDays.Text = _totalDays.ToString() + " days";
            lblTotalBooks.Text = _details.Sum(d => d.Quantity).ToString() + " books";
            lblTotalAmount.Text = _totalAmount.ToString("F2");

            UpdateRemaining();

            if (_details.Count > 0)
                BindDetailsGrid();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateRemaining()
        {
            decimal.TryParse(txtPaidAmount.Text, out decimal paid);
            decimal remaining = _totalAmount - paid;

            if (remaining < 0)
            {
                lblRemainingLabel.Text = "Change:";
                lblRemaining.Text = Math.Abs(remaining).ToString("F2");
                lblRemaining.ForeColor = Color.FromArgb(80, 200, 120);
            }
            else
            {
                lblRemainingLabel.Text = "Remaining:";
                lblRemaining.Text = remaining.ToString("F2");
                lblRemaining.ForeColor = remaining > 0 ? Color.Red : Color.FromArgb(80, 200, 120);
            }
        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateRemaining();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var selCustomer = cmbCustomer.SelectedItem as ComboItem;
            if (selCustomer == null || selCustomer.ID == 0)
            { MessageHelper.ShowWarning("Please select a customer."); return; }

            if (_details.Count == 0)
            { MessageHelper.ShowWarning("Please add at least one book."); return; }

            if (_totalDays <= 0)
            { MessageHelper.ShowWarning("Borrowing days must be greater than zero."); return; }

            if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount < 0)
            { MessageHelper.ShowWarning("Invalid discount."); return; }

            if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount) || paidAmount < 0)
            { MessageHelper.ShowWarning("Please enter a valid paid amount."); return; }

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Saving...";
                spinner.Start();

                foreach (var d in _details)
                    d.TotalDays = _totalDays;

                var dto = new CreateBorrowingWithDetailsDTO
                {
                    BorrowingNumber = txtBorrowNumber.Text.Trim(),
                    CustomerID = selCustomer.ID,
                    BorrowingDate = dtpBorrowDate.Value,
                    ExpectedReturnDate = dtpReturnDate.Value,
                    TotalDays = _totalDays,
                    TotalAmount = _totalAmount,
                    PaidAmount = Math.Min(paidAmount, _totalAmount),
                    Status = "Borrowed",
                    Notes = txtNotes.Text.Trim(),
                    CreatedBy = SessionManager.UserId,
                    Details = _details
                };

                var data = BuildPrintData();

                var result = await ApiHelper.PostAsync<BorrowingTransaction>("BorrowingTransactions/with-details", dto);
                if (result != null)
                {
                    if (!string.IsNullOrWhiteSpace(result.BorrowingNumber))
                        data.InvoiceNumber = result.BorrowingNumber;

                    if (MessageHelper.ShowConfirm("Borrowing saved!\nBorrowing #: " + data.InvoiceNumber + "\n\nDo you want to print it now?"))
                    {
                        if (chkThermalPrint.Checked)
                            InvoicePrinter.PrintInvoiceThermal(data, showPreview: true);
                        else
                            InvoicePrinter.PrintInvoice(data, showPreview: true);
                    }

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error saving borrowing: " + ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Save Borrowing";
                spinner.Stop();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_details.Count == 0)
            { MessageHelper.ShowWarning("Please add at least one book."); return; }

            var data = BuildPrintData();

            if (chkThermalPrint.Checked)
                InvoicePrinter.PrintInvoiceThermal(data, true);
            else
                InvoicePrinter.PrintInvoice(data, true);
        }

        private PrintInvoiceData BuildPrintData()
        {
            var selCustomer = cmbCustomer.SelectedItem as ComboItem;
            decimal.TryParse(txtPaidAmount.Text, out decimal paid);
            decimal.TryParse(txtDiscount.Text, out decimal disc);

            decimal remaining = _totalAmount - paid;
            string changeNote = remaining < 0
                ? $"Change returned to customer: {Math.Abs(remaining):F2} JD"
                : "";

            string notes = string.IsNullOrWhiteSpace(txtNotes.Text)
                ? changeNote
                : (string.IsNullOrEmpty(changeNote) ? txtNotes.Text : txtNotes.Text + " | " + changeNote);

            var data = new PrintInvoiceData
            {
                InvoiceNumber = txtBorrowNumber.Text,
                InvoiceDate = dtpBorrowDate.Value,
                CustomerName = selCustomer?.Name ?? "",
                PaymentType = "Borrow",
                PaymentMethod = "-",
                SalesRepName = "",
                CashierName = SessionManager.UserId.ToString(),
                Notes = notes,
                SubTotal = _subTotal,
                DiscountAmount = disc,
                TaxAmount = 0,
                TaxPercent = 0,
                TotalAmount = _totalAmount,
                PaidAmount = paid,
                RemainingAmount = remaining,
                TotalDays = _totalDays,
                ReturnDate = dtpReturnDate.Value
            };

            foreach (var d in _details)
            {
                var book = _books.FirstOrDefault(b => b.ProductID == d.ProductID);
                data.Lines.Add(new PrintInvoiceLine
                {
                    ProductName = book?.ProductName ?? "",
                    Quantity = d.Quantity,
                    UnitPrice = d.PricePerDay,
                    DiscountAmount = 0,
                    Total = d.TotalPrice
                });
            }

            return data;
        }

        private void ClearForm()
        {
            _details.Clear();
            dgvDetails.Rows.Clear();
            GenerateBorrowNumber();
            dtpBorrowDate.Value = DateTime.Today;
            nudDays.Value = 7;
            cmbCustomer.SelectedIndex = 0;
            txtNotes.Text = "";
            txtDiscount.Text = "0";
            txtPaidAmount.Text = "0.00";
            ResetBookInput();
            UpdateReturnDate();
            UpdateTotals();
            btnSave.Enabled = true;
            btnSave.Text = "💾 Save Borrowing";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!MessageHelper.ShowConfirm("Clear all data and start a new borrowing?")) return;
            ClearForm();
        }

        private class ComboItem
        {
            public int ID { get; set; }
            public string Name { get; set; } = "";
            public override string ToString() => Name;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}