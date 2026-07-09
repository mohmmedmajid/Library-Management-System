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
    public partial class FrmBooks : Form
    {
        private List<Book> _books = new List<Book>();
        private List<Category> _categories = new List<Category>();

        public FrmBooks()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(440, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(510, 15);
            searchBox.Size = new Size(280, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);

            dgvBooks.CellFormatting += DgvBooks_CellFormatting;
        }

 
        private void DgvBooks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int editCol = dgvBooks.Columns["colEdit"].Index;
            int delCol = dgvBooks.Columns["colDelete"].Index;

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


        private async void FrmBooks_Load(object sender, EventArgs e)
        {
            btnNew.Visible = SessionManager.IsAdmin;
            dgvBooks.Columns["colEdit"].Visible = SessionManager.IsAdmin;
            dgvBooks.Columns["colDelete"].Visible = SessionManager.IsAdmin;
            await LoadCategories();
            await LoadBooks();
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

        private async System.Threading.Tasks.Task LoadBooks()
        {
            try
            {
                spinner.Start();
                _books = await ApiHelper.GetAsync<List<Book>>("books")
                         ?? new List<Book>();
                BindGrid(_books);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading books: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<Book> list)
        {
            dgvBooks.Rows.Clear();
            foreach (var b in list)
            {
                dgvBooks.Rows.Add(
                    b.BookID,
                    b.ProductName,
                    b.ISBN,
                    b.Author,
                    b.Publisher,
                    b.PublicationYear?.ToString() ?? "",
                    b.Language,
                    b.CanSell ? "✓" : "✗",
                    b.CanBorrow ? "✓" : "✗",
                    b.BorrowPricePerDay.ToString("F2"),
                    b.AvailableQuantity?.ToString() ?? "0",
                    "✏️ Edit",
                    "🗑 Delete"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!SessionManager.IsAdmin) return;

            int bookId = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells["colBookID"].Value);
            var book = _books.Find(b => b.BookID == bookId);
            if (book == null) return;

            if (e.ColumnIndex == dgvBooks.Columns["colEdit"].Index)
                OpenEditDialog(book);
            else if (e.ColumnIndex == dgvBooks.Columns["colDelete"].Index)
                DeleteBook(book);
        }


        private void OpenEditDialog(Book book = null)
        {
            bool isNew = book == null;

            int dlgW = 620;
            int lh = 20; int fh = 28; int gap = 6;
            int lx = 15; int half = 290; int hw = 270;

            var dlg = new Form
            {
                Text = isNew ? "➕ Add New Book" : "✏️ Edit Book",
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Font = new Font("Segoe UI", 9.5f),
                Width = dlgW
            };

            var pnlHeader = new Panel { Location = new Point(0, 0), Size = new Size(dlgW, 46), BackColor = Color.FromArgb(22, 32, 50) };
            pnlHeader.Controls.Add(new Label { Text = isNew ? "➕ Add New Book" : "✏️ Edit Book", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Location = new Point(15, 10), Size = new Size(500, 26) });
            dlg.Controls.Add(pnlHeader);

            int y = 54;

            AddSection(dlg, "📦  Product Information", Color.FromArgb(30, 100, 180), ref y, dlgW);
            AddLabel(dlg, "Book Title *", lx, y, hw); AddLabel(dlg, "Arabic Title", half, y, hw); y += lh + gap;
            var txtProductName = AddTextBox(dlg, lx, y, hw, fh, isNew ? "" : book.ProductName);
            var txtProductNameAr = AddTextBox(dlg, half, y, hw, fh, isNew ? "" : book.ProductNameAr, rtl: true);
            y += fh + 10;

            AddLabel(dlg, "Category *", lx, y, hw); AddLabel(dlg, "Unit Price *", half, y, hw); y += lh + gap;
            var cmbCategory = new ComboBox { Location = new Point(lx, y), Size = new Size(hw, fh), DropDownStyle = ComboBoxStyle.DropDownList, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9.5f) };
            cmbCategory.Items.Add(new ComboItem { ID = 0, Name = "-- Select --" });
            foreach (var c in _categories) cmbCategory.Items.Add(new ComboItem { ID = c.CategoryID, Name = c.CategoryName });
            cmbCategory.DisplayMember = "Name"; cmbCategory.ValueMember = "ID"; cmbCategory.SelectedIndex = 0;
            dlg.Controls.Add(cmbCategory);
            var txtUnitPrice = AddTextBox(dlg, half, y, hw, fh, isNew ? "0.00" : book.UnitPrice.ToString("F2"));
            y += fh + 10;

            AddLabel(dlg, "Barcode", lx, y, hw); AddLabel(dlg, "ISBN", half, y, hw); y += lh + gap;
            var txtBarcode = AddTextBox(dlg, lx, y, hw, fh, isNew ? "" : book.Barcode);
            var txtISBN = AddTextBox(dlg, half, y, hw, fh, isNew ? "" : book.ISBN);
            y += fh + 10;

            AddLabel(dlg, "Quantity In Stock", lx, y, hw); y += lh + gap;
            var txtQuantityInStock = AddTextBox(dlg, lx, y, hw, fh, isNew ? "0" : book.AvailableQuantity?.ToString() ?? "0");
            y += fh + 10;

            AddSection(dlg, "📚  Book Details", Color.FromArgb(40, 160, 100), ref y, dlgW);
            AddLabel(dlg, "Author *", lx, y, hw); AddLabel(dlg, "Author (AR)", half, y, hw); y += lh + gap;
            var txtAuthor = AddTextBox(dlg, lx, y, hw, fh, isNew ? "" : book.Author);
            var txtAuthorAr = AddTextBox(dlg, half, y, hw, fh, isNew ? "" : book.AuthorAr, rtl: true);
            y += fh + 10;

            AddLabel(dlg, "Publisher", lx, y, hw); AddLabel(dlg, "Publisher (AR)", half, y, hw); y += lh + gap;
            var txtPublisher = AddTextBox(dlg, lx, y, hw, fh, isNew ? "" : book.Publisher);
            var txtPublisherAr = AddTextBox(dlg, half, y, hw, fh, "", rtl: true);
            y += fh + 10;

            int thirdW = 175;
            AddLabel(dlg, "Year", lx, y, thirdW); AddLabel(dlg, "Language", lx + thirdW + 10, y, thirdW); AddLabel(dlg, "Pages", lx + (thirdW + 10) * 2, y, thirdW); y += lh + gap;
            var txtYear = AddTextBox(dlg, lx, y, thirdW, fh, isNew ? "" : book.PublicationYear?.ToString() ?? "");
            var txtLang = AddTextBox(dlg, lx + thirdW + 10, y, thirdW, fh, isNew ? "" : book.Language);
            var txtPages = AddTextBox(dlg, lx + (thirdW + 10) * 2, y, thirdW, fh, isNew ? "" : book.Pages?.ToString() ?? "");
            y += fh + 10;

            AddSection(dlg, "🔄  Borrowing Settings", Color.FromArgb(180, 100, 0), ref y, dlgW);
            AddLabel(dlg, "Price / Day", lx, y, hw); AddLabel(dlg, "Max Borrow Days", half, y, hw); y += lh + gap;
            var txtPrice = AddTextBox(dlg, lx, y, hw, fh, isNew ? "0.00" : book.BorrowPricePerDay.ToString("F2"));
            var txtMaxDays = AddTextBox(dlg, half, y, hw, fh, isNew ? "30" : book.MaxBorrowDays?.ToString() ?? "30");
            y += fh + 10;

            var chkSell = new CheckBox { Text = "✓ Can Sell", Location = new Point(lx, y), Size = new Size(200, 26), Checked = isNew || book.CanSell, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(30, 100, 180), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkSell);
            var chkBorrow = new CheckBox { Text = "✓ Can Borrow", Location = new Point(lx + 220, y), Size = new Size(200, 26), Checked = isNew || book.CanBorrow, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 160, 100), Cursor = Cursors.Hand };
            dlg.Controls.Add(chkBorrow);
            y += 34;

            var divider = new Panel { Location = new Point(0, y), Size = new Size(dlgW, 1), BackColor = Color.FromArgb(220, 222, 225) };
            dlg.Controls.Add(divider); y += 8;

            var btnSave = new Button { Text = "💾 Save", Location = new Point(lx, y), Size = new Size(280, 38), BackColor = Color.FromArgb(30, 100, 180), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSave.FlatAppearance.BorderSize = 0; dlg.Controls.Add(btnSave);
            var btnCancel = new Button { Text = "✕ Cancel", Location = new Point(lx + 295, y), Size = new Size(280, 38), BackColor = Color.FromArgb(150, 150, 150), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCancel.FlatAppearance.BorderSize = 0; btnCancel.Click += (s, ev) => dlg.Close(); dlg.Controls.Add(btnCancel);
            y += 38 + 12;

            dlg.Height = y + 38;

            if (!isNew)
                foreach (ComboItem ci in cmbCategory.Items)
                    if (ci.ID == book.ProductID) { cmbCategory.SelectedItem = ci; break; }

            btnSave.Click += async (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text)) { MessageHelper.ShowWarning("Please enter book title."); return; }
                if (string.IsNullOrWhiteSpace(txtAuthor.Text)) { MessageHelper.ShowWarning("Please enter author name."); return; }
                var selCat = cmbCategory.SelectedItem as ComboItem;
                if (selCat == null || selCat.ID == 0) { MessageHelper.ShowWarning("Please select a category."); return; }
                if (!decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice)) { MessageHelper.ShowWarning("Invalid unit price."); return; }
                if (!decimal.TryParse(txtPrice.Text, out decimal borrowPrice)) { MessageHelper.ShowWarning("Invalid borrow price."); return; }
                if (!int.TryParse(txtQuantityInStock.Text, out int quantityInStock)) { MessageHelper.ShowWarning("Please enter a valid quantity."); return; }
                int.TryParse(txtYear.Text, out int pubYear); int.TryParse(txtMaxDays.Text, out int maxDays); int.TryParse(txtPages.Text, out int pages);
                try
                {
                    btnSave.Enabled = false; btnSave.Text = "Saving...";
                    if (isNew)
                    {
                        var productDto = new CreateProductDTO { ProductName = txtProductName.Text.Trim(), ProductNameAr = txtProductNameAr.Text.Trim(), CategoryID = selCat.ID, Barcode = txtBarcode.Text.Trim(), UnitPrice = unitPrice, CostPrice = 0, ProductType = "Book", QuantityInStock = quantityInStock, CreatedBy = SessionManager.UserId };
                        var createdProduct = await ApiHelper.PostAsync<Product>("products", productDto);
                        if (createdProduct == null) { MessageHelper.ShowError("Failed to create product."); return; }
                        var bookDto = new CreateBookDTO { ProductID = createdProduct.ProductID, ISBN = txtISBN.Text.Trim(), Author = txtAuthor.Text.Trim(), AuthorAr = txtAuthorAr.Text.Trim(), Publisher = txtPublisher.Text.Trim(), PublisherAr = txtPublisherAr.Text.Trim(), PublicationYear = pubYear, Language = txtLang.Text.Trim(), Pages = pages, CanSell = chkSell.Checked, CanBorrow = chkBorrow.Checked, BorrowPricePerDay = borrowPrice, MaxBorrowDays = maxDays == 0 ? 30 : maxDays };
                        if (await ApiHelper.PostAsync<Book>("books", bookDto) != null)
                        { MessageHelper.ShowSuccess("Book added successfully!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                    else
                    {
                        var productDto = new UpdateProductDTO { ProductID = book.ProductID, ProductName = txtProductName.Text.Trim(), ProductNameAr = txtProductNameAr.Text.Trim(), CategoryID = selCat.ID, Barcode = txtBarcode.Text.Trim(), UnitPrice = unitPrice, CostPrice = 0, ProductType = "Book", QuantityInStock = quantityInStock, IsActive = true };
                        await ApiHelper.PutAsync<Product>("products/" + book.ProductID, productDto);
                        var bookDto = new UpdateBookDTO { BookID = book.BookID, ISBN = txtISBN.Text.Trim(), Author = txtAuthor.Text.Trim(), AuthorAr = txtAuthorAr.Text.Trim(), Publisher = txtPublisher.Text.Trim(), PublisherAr = txtPublisherAr.Text.Trim(), PublicationYear = pubYear, Language = txtLang.Text.Trim(), Pages = pages, CanSell = chkSell.Checked, CanBorrow = chkBorrow.Checked, BorrowPricePerDay = borrowPrice, MaxBorrowDays = maxDays == 0 ? 30 : maxDays };
                        if (await ApiHelper.PutAsync<Book>("books/" + book.BookID, bookDto) != null)
                        { MessageHelper.ShowSuccess("Book updated successfully!"); dlg.DialogResult = DialogResult.OK; dlg.Close(); }
                    }
                }
                catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); btnSave.Enabled = true; btnSave.Text = "💾 Save"; }
            };

            if (dlg.ShowDialog(this) == DialogResult.OK)
                _ = LoadBooks();
        }

        private void AddSection(Form dlg, string text, Color color, ref int y, int w)
        {
            var pnl = new Panel { Location = new Point(0, y), Size = new Size(w, 24), BackColor = Color.FromArgb(240, 242, 245) };
            pnl.Controls.Add(new Label { Text = text, Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = color, Location = new Point(10, 4), Size = new Size(400, 18) });
            dlg.Controls.Add(pnl); y += 30;
        }

        private void AddLabel(Form dlg, string text, int x, int y, int w)
        {
            dlg.Controls.Add(new Label { Text = text, Location = new Point(x, y), Size = new Size(w, 20), Font = new Font("Segoe UI", 8.5f, FontStyle.Bold), ForeColor = Color.FromArgb(70, 70, 70) });
        }

        private TextBox AddTextBox(Form dlg, int x, int y, int w, int h, string val, bool rtl = false)
        {
            var t = new TextBox { Location = new Point(x, y), Size = new Size(w, h), Text = val, BorderStyle = BorderStyle.FixedSingle, Font = new Font("Segoe UI", 9.5f), RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No };
            dlg.Controls.Add(t); return t;
        }


        private async void DeleteBook(Book book)
        {
            if (!MessageHelper.ShowConfirm($"Delete \"{book.ProductName}\"?\nThis will also delete the product. Cannot be undone."))
                return;
            try
            {
                spinner.Start();
                await ApiHelper.DeleteAsync("books/" + book.BookID);
                await ApiHelper.DeleteAsync("products/" + book.ProductID);
                MessageHelper.ShowSuccess("Book deleted successfully.");
                await LoadBooks();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error: " + ex.Message); }
            finally { spinner.Stop(); }
        }


        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_books); return; }
            string s = text.ToLower();
            var filtered = new List<Book>();
            foreach (var b in _books)
                if (b.ProductName.ToLower().Contains(s) ||
                   (b.ISBN != null && b.ISBN.ToLower().Contains(s)) ||
                   (b.Author != null && b.Author.ToLower().Contains(s)) ||
                   (b.Publisher != null && b.Publisher.ToLower().Contains(s)))
                    filtered.Add(b);
            BindGrid(filtered);
        }

  
        private void btnNew_Click(object sender, EventArgs e) => OpenEditDialog(null);

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadBooks();
        }


        private class ComboItem
        {
            public int ID { get; set; }
            public string Name { get; set; } = "";
            public override string ToString() => Name;
        }
    }
}