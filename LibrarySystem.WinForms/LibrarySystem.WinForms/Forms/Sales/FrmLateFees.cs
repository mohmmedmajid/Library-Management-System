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
    public partial class FrmLateFees : Form
    {
        private List<LateFee> _lateFees = new List<LateFee>();

        public FrmLateFees()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(510, 3);
            spinner.Size = new Size(44, 44);
            pnlSearch.Controls.Add(spinner);

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

        private void DgvLateFees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int statusCol = dgvLateFees.Columns["colStatus"]?.Index ?? -1;
            int remainCol = dgvLateFees.Columns["colRemaining"]?.Index ?? -1;
            int viewCol = dgvLateFees.Columns["colView"]?.Index ?? -1;

            if (e.ColumnIndex == statusCol)
            {
                string s = e.Value?.ToString() ?? "";
                switch (s)
                {
                    case "Pending":
                        e.CellStyle.ForeColor = Color.FromArgb(200, 50, 50);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Paid":
                        e.CellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                    case "Waived":
                        e.CellStyle.ForeColor = Color.FromArgb(120, 120, 120);
                        e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                        break;
                }
            }
            else if (e.ColumnIndex == remainCol)
            {
                if (decimal.TryParse(e.Value?.ToString(), out decimal rem) && rem > 0)
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

        private async void FrmLateFees_Load(object sender, EventArgs e)
        {
            await LoadLateFees();
        }

        private async System.Threading.Tasks.Task LoadLateFees()
        {
            try
            {
                spinner.Start();
                string status = cmbStatus.SelectedItem?.ToString() ?? "All";
                string endpoint = status == "All"
                    ? "latefees"
                    : $"latefees?Status={status}";

                _lateFees = await ApiHelper.GetAsync<List<LateFee>>(endpoint)
                            ?? new List<LateFee>();
                BindFeesGrid(_lateFees);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading late fees: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void BindFeesGrid(List<LateFee> list)
        {
            dgvLateFees.Rows.Clear();
            foreach (var f in list)
            {
                dgvLateFees.Rows.Add(
                    f.LateFeeID,
                    f.BorrowingNumber,
                    f.CustomerName,
                    f.LateDays,
                    f.TotalFee.ToString("F2"),
                    f.PaidAmount.ToString("F2"),
                    f.RemainingAmount.ToString("F2"),
                    f.Status,
                    "👁 View"
                );
            }
            lblFeeCount.Text = "Records: " + list.Count;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string q = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(q) || q == "borrowing # or customer name...")
            { BindFeesGrid(_lateFees); return; }

            var filtered = _lateFees.FindAll(f =>
                f.BorrowingNumber.ToLower().Contains(q) ||
                f.CustomerName.ToLower().Contains(q));
            BindFeesGrid(filtered);
        }

        private async void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadLateFees();
        }

        private async void dgvLateFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int viewCol = dgvLateFees.Columns["colView"].Index;
            if (e.ColumnIndex != viewCol) return;

            int id = Convert.ToInt32(dgvLateFees.Rows[e.RowIndex].Cells["colLateFeeID"].Value);
            var fee = _lateFees.Find(f => f.LateFeeID == id);
            if (fee == null) return;

            using (var frm = new FrmLateFeeDetails(fee))
            {
                frm.ShowDialog(this);
                if (frm.Changed)
                    await LoadLateFees();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Borrowing # or customer name...";
            txtSearch.ForeColor = Color.Gray;
            await LoadLateFees();
        }
    }
}