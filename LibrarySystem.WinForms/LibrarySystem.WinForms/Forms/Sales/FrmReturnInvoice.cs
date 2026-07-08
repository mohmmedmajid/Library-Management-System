// ==================== FrmReturnInvoice.cs ====================
using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models;
using LibrarySystem.WinForms.Models.Sales;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmReturnInvoice : Form
    {
        private List<BorrowingTransaction> _borrowings = new List<BorrowingTransaction>();

        public FrmReturnInvoice()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(10, 8);
            spinner.Size = new Size(50, 50);
            pnlSearch.Controls.Add(spinner);

            dgvBorrowings.CellFormatting += DgvBorrowings_CellFormatting;
            dgvBorrowings.CellClick += DgvBorrowings_CellClick;

            txtSearch.GotFocus += new EventHandler(txtSearch_GotFocus);
            txtSearch.LostFocus += new EventHandler(txtSearch_LostFocus);
        }

        private void txtSearch_GotFocus(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Borrowing # or customer name...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Borrowing # or customer name...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void DgvBorrowings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int statusCol = dgvBorrowings.Columns["colStatus"]?.Index ?? -1;
            int daysCol = dgvBorrowings.Columns["colLateDays"]?.Index ?? -1;
            int viewCol = dgvBorrowings.Columns["colView"]?.Index ?? -1;

            if (e.ColumnIndex == statusCol)
            {
                string s = e.Value?.ToString() ?? "";
                switch (s)
                {
                    case "Borrowed":
                        e.CellStyle.ForeColor = Color.FromArgb(30, 100, 180);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Overdue":
                        e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Returned":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                }
            }
            else if (e.ColumnIndex == daysCol)
            {
                if (int.TryParse(e.Value?.ToString(), out int days) && days > 0)
                {
                    e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
            }
            else if (e.ColumnIndex == viewCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.SelectionForeColor = Color.White;
            }
        }

        private async void FrmReturnInvoice_Load(object sender, EventArgs e)
        {
            await LoadActiveBorrowings();
        }

        private async System.Threading.Tasks.Task LoadActiveBorrowings()
        {
            try
            {
                spinner.Start();
                string endpoint = "borrowingtransactions?Status=Borrowed";
                _borrowings = await ApiHelper.GetAsync<List<BorrowingTransaction>>(endpoint)
                              ?? new List<BorrowingTransaction>();
                BindBorrowingsGrid(_borrowings);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading borrowings: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void BindBorrowingsGrid(List<BorrowingTransaction> list)
        {
            dgvBorrowings.Rows.Clear();
            foreach (var b in list)
            {
                int lateDays = (DateTime.Today - b.ExpectedReturnDate).Days;
                if (lateDays < 0) lateDays = 0;
                string status = lateDays > 0 ? "Overdue" : b.Status;

                dgvBorrowings.Rows.Add(
                    b.BorrowingID,
                    b.BorrowingNumber,
                    b.CustomerName,
                    b.BorrowingDate.ToString("yyyy-MM-dd"),
                    b.ExpectedReturnDate.ToString("yyyy-MM-dd"),
                    b.TotalDays,
                    b.TotalAmount.ToString("F2"),
                    lateDays,
                    status,
                    "↩ Return"
                );
            }
            lblBorrowCount.Text = "Records: " + list.Count;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(q) || q == "borrowing # or customer name...")
            { BindBorrowingsGrid(_borrowings); return; }

            var filtered = _borrowings.FindAll(b =>
                b.BorrowingNumber.ToLower().Contains(q) ||
                b.CustomerName.ToLower().Contains(q));
            BindBorrowingsGrid(filtered);
        }

        private async void DgvBorrowings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int viewCol = dgvBorrowings.Columns["colView"].Index;
            if (e.ColumnIndex != viewCol) return;

            int id = Convert.ToInt32(dgvBorrowings.Rows[e.RowIndex].Cells["colBorrowingID"].Value);
            var borrowing = _borrowings.Find(b => b.BorrowingID == id);
            if (borrowing == null) return;

            using (var frm = new FrmReturnDetails(borrowing))
            {
                frm.ShowDialog(this);
                if (frm.Changed)
                    await LoadActiveBorrowings();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Borrowing # or customer name...";
            txtSearch.ForeColor = Color.Gray;
            await LoadActiveBorrowings();
        }
    }
}