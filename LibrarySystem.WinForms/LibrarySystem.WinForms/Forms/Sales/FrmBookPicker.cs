using LibrarySystem.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmBookPicker : Form
    {
        private Panel pnlTop;
        private Label lblTitle;
        private Label lblCount;
        private Label lblBarcode;
        private TextBox txtBarcode;
        private Button btnBarcodeSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblPublisher;
        private ComboBox cmbPublisher;
        private Button btnSearch;
        private Panel pnlGrid;
        private DataGridView dgvBooks;
        private Button btnSelect;
        private Button btnCancel;

        private List<Book> _allBooks;
        public Book SelectedBook { get; private set; }

        public FrmBookPicker(List<Book> books)
        {
            InitializeComponent();
            _allBooks = books;
            BuildUi();
            LoadPublishers();
            BindBooks(_allBooks);
        }

        private void BuildUi()
        {
            Text = "Select Book";
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(680, 405);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Segoe UI", 9.5F);

            pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.White
            };

            lblTitle = new Label
            {
                Text = "📚 Select Book",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 40, 60),
                Location = new Point(15, 8),
                AutoSize = true
            };

            lblCount = new Label
            {
                Text = "Total: 0",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                Location = new Point(555, 14),
                Size = new Size(105, 18),
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            lblBarcode = new Label
            {
                Text = "Barcode",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(15, 44),
                Size = new Size(150, 16)
            };
            txtBarcode = new TextBox
            {
                Location = new Point(15, 62),
                Size = new Size(125, 25),
                Font = new Font("Segoe UI", 9.5F),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtBarcode.KeyDown += TxtBarcode_KeyDown;

            btnBarcodeSearch = new Button
            {
                Text = "🔍",
                Location = new Point(145, 61),
                Size = new Size(28, 27),
                BackColor = Color.FromArgb(22, 32, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            btnBarcodeSearch.FlatAppearance.BorderSize = 0;
            btnBarcodeSearch.Click += (s, e) => SearchByBarcode();

            lblSearch = new Label
            {
                Text = "Search (name / author)",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(180, 44),
                Size = new Size(260, 16)
            };
            txtSearch = new TextBox
            {
                Location = new Point(180, 62),
                Size = new Size(255, 25),
                Font = new Font("Segoe UI", 9.5F),
                BorderStyle = BorderStyle.FixedSingle
            };
            txtSearch.TextChanged += (s, e) => ApplyFilter();

            lblPublisher = new Label
            {
                Text = "Publisher",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(478, 44),
                Size = new Size(187, 16)
            };
            cmbPublisher = new ComboBox
            {
                Location = new Point(478, 62),
                Size = new Size(210, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F)
            };
            cmbPublisher.SelectedIndexChanged += (s, e) => ApplyFilter();

            btnSearch = new Button
            {
                Text = "🔍",
                Location = new Point(440, 61),
                Size = new Size(28, 27),
                BackColor = Color.FromArgb(22, 32, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += (s, e) => ApplyFilter();

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblCount);
            pnlTop.Controls.Add(lblBarcode);
            pnlTop.Controls.Add(txtBarcode);
            pnlTop.Controls.Add(btnBarcodeSearch);
            pnlTop.Controls.Add(lblSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(lblPublisher);
            pnlTop.Controls.Add(cmbPublisher);

            pnlGrid = new Panel
            {
                BackColor = Color.White,
                Location = new Point(10, 116),
                Size = new Size(660, 235),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
            };

            dgvBooks = new DataGridView
            {
                Location = new Point(0, 0),
                Size = new Size(660, 235),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ColumnHeadersHeight = 36,
                RowTemplate = { Height = 32 },
                Font = new Font("Segoe UI", 9F)
            };

            var headerStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(22, 32, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F),
                SelectionBackColor = Color.FromArgb(22, 32, 50),
                SelectionForeColor = Color.White
            };
            dgvBooks.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvBooks.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(245, 247, 250)
            };

            dgvBooks.Columns.Add("ProductID", "ID");
            dgvBooks.Columns.Add("ProductName", "Book Name");
            dgvBooks.Columns.Add("Author", "Author");
            dgvBooks.Columns.Add("Publisher", "Publisher");
            dgvBooks.Columns.Add("Barcode", "Barcode");
            dgvBooks.Columns.Add("AvailableQuantity", "Available");
            dgvBooks.Columns.Add("BorrowPricePerDay", "Price/Day");
            dgvBooks.Columns["ProductID"].Visible = false;
            dgvBooks.Columns["ProductName"].FillWeight = 26F;
            dgvBooks.Columns["Author"].FillWeight = 18F;
            dgvBooks.Columns["Publisher"].FillWeight = 16F;
            dgvBooks.Columns["Barcode"].FillWeight = 16F;
            dgvBooks.Columns["AvailableQuantity"].FillWeight = 12F;
            dgvBooks.Columns["BorrowPricePerDay"].FillWeight = 12F;
            dgvBooks.CellDoubleClick += (s, e) => { if (e.RowIndex >= 0) ConfirmSelection(); };

            pnlGrid.Controls.Add(dgvBooks);

            btnSelect = new Button
            {
                Text = "✔ Select",
                Location = new Point(455, 360),
                Size = new Size(105, 36),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(40, 160, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += (s, e) => ConfirmSelection();

            btnCancel = new Button
            {
                Text = "✕ Cancel",
                Location = new Point(565, 360),
                Size = new Size(105, 36),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                BackColor = Color.FromArgb(160, 160, 160),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.Add(pnlTop);
            Controls.Add(pnlGrid);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);

            AcceptButton = btnSelect;
            CancelButton = btnCancel;

            Load += (s, e) => txtBarcode.Focus();
        }

        private void LoadPublishers()
        {
            cmbPublisher.Items.Clear();
            cmbPublisher.Items.Add("-- All Publishers --");
            var pubs = _allBooks
                .Select(b => b.Publisher)
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Distinct()
                .OrderBy(p => p);
            foreach (var p in pubs)
                cmbPublisher.Items.Add(p);
            cmbPublisher.SelectedIndex = 0;
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchByBarcode();
            }
        }

        private void SearchByBarcode()
        {
            string code = txtBarcode.Text.Trim();
            if (string.IsNullOrEmpty(code)) return;

            var match = _allBooks.FirstOrDefault(b => b.Barcode == code);
            if (match != null)
            {
                SelectedBook = match;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("No book found with this barcode.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Clear();
            }
        }

        private void ApplyFilter()
        {
            var filtered = _allBooks.AsEnumerable();

            if (cmbPublisher.SelectedIndex > 0)
            {
                string selPub = cmbPublisher.SelectedItem.ToString();
                filtered = filtered.Where(b => b.Publisher == selPub);
            }

            string term = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(term))
            {
                filtered = filtered.Where(b =>
                    (b.ProductName?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (b.Author?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (b.Barcode?.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            BindBooks(filtered.ToList());
        }

        private void BindBooks(List<Book> books)
        {
            dgvBooks.Rows.Clear();
            foreach (var b in books)
            {
                dgvBooks.Rows.Add(
                    b.ProductID,
                    b.ProductName,
                    b.Author,
                    b.Publisher,
                    b.Barcode,
                    b.AvailableQuantity,
                    b.BorrowPricePerDay.ToString("F2")
                );
            }
            lblCount.Text = "Total: " + books.Count;
        }

        private void ConfirmSelection()
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["ProductID"].Value);
            SelectedBook = _allBooks.FirstOrDefault(b => b.ProductID == productId);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}