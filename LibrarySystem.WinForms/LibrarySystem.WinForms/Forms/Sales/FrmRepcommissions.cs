using LibrarySystem.WinForms.Helpers;
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
    public partial class FrmRepCommissions : Form
    {
        private List<RepCommission> _commissions = new List<RepCommission>();
        private List<SalesRepresentative> _reps = new List<SalesRepresentative>();

        public FrmRepCommissions()
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

            dgvCommissions.CellFormatting += DgvCommissions_CellFormatting;
        }

        private void DgvCommissions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int payCol = dgvCommissions.Columns["colMarkPaid"].Index;
            int statusCol = dgvCommissions.Columns["colPaidStatus"].Index;

            if (e.ColumnIndex == payCol)
            {
                e.CellStyle.BackColor = Color.FromArgb(30, 100, 180);
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.FromArgb(20, 80, 160);
                e.CellStyle.SelectionForeColor = Color.White;
            }
            else if (e.ColumnIndex == statusCol)
            {
                var val = dgvCommissions.Rows[e.RowIndex].Cells["colPaidStatus"].Value?.ToString() ?? "";
                e.CellStyle.ForeColor = val.Contains("Paid") && !val.Contains("Unpaid")
                    ? Color.FromArgb(40, 160, 100)
                    : Color.FromArgb(200, 50, 50);
                e.CellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
        }

        private async void FrmRepCommissions_Load(object sender, EventArgs e)
        {
            dgvCommissions.Columns["colMarkPaid"].Visible = SessionManager.IsAdmin || SessionManager.IsCashier;
            await LoadReps();
            await LoadCommissions();
        }

        private async System.Threading.Tasks.Task LoadReps()
        {
            try
            {
                _reps = await ApiHelper.GetAsync<List<SalesRepresentative>>("salesrepresentatives")
                        ?? new List<SalesRepresentative>();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading reps: " + ex.Message); }
        }

        private async System.Threading.Tasks.Task LoadCommissions()
        {
            try
            {
                spinner.Start();
                _commissions = await ApiHelper.GetAsync<List<RepCommission>>("repcommissions")
                               ?? new List<RepCommission>();
                BindGrid(_commissions);
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading commissions: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void BindGrid(List<RepCommission> list)
        {
            dgvCommissions.Rows.Clear();
            foreach (var c in list)
            {
                dgvCommissions.Rows.Add(
                    c.CommissionID,
                    c.RepName,
                    c.InvoiceNumber,
                    c.SalesAmount.ToString("F2"),
                    c.CommissionPercent.ToString("F2"),
                    c.CommissionAmount.ToString("F2"),
                    c.IsPaid ? "✓ Paid" : "✗ Unpaid",
                    c.CreatedDate.ToString("yyyy-MM-dd"),
                    c.IsPaid ? "Paid" : "💰 Mark Paid"
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private async void dgvCommissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvCommissions.Rows[e.RowIndex].Cells["colCommissionID"].Value);
            var commission = _commissions.Find(c => c.CommissionID == id);
            if (commission == null) return;

            if (e.ColumnIndex == dgvCommissions.Columns["colMarkPaid"].Index &&
                (SessionManager.IsAdmin || SessionManager.IsCashier))
            {
                await MarkPaid(commission);
            }
        }

        private async System.Threading.Tasks.Task MarkPaid(RepCommission commission)
        {
            if (commission.IsPaid) return;

            if (!MessageHelper.ShowConfirm($"Confirm payment of {commission.CommissionAmount:F2} JD to {commission.RepName}?"))
                return;

            try
            {
                spinner.Start();
                var dto = new MarkCommissionAsPaidDTO { CommissionID = commission.CommissionID };
                await ApiHelper.PutAsync<object>("repcommissions/mark-paid", dto);
                MessageHelper.ShowSuccess("Commission marked as paid!");
                await LoadCommissions();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error marking commission as paid: " + ex.Message); }
            finally { spinner.Stop(); }
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_commissions); return; }
            string s = text.ToLower();
            var filtered = _commissions.Where(c =>
                (c.RepName ?? "").ToLower().Contains(s) ||
                (c.InvoiceNumber ?? "").ToLower().Contains(s)).ToList();
            BindGrid(filtered);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            await LoadCommissions();
        }
    }
}