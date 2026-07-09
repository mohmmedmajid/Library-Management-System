using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    public partial class FrmInventoryMovements : Form
    {
        private List<InventoryMovement> _movements = new List<InventoryMovement>();
        private LoadingSpinnerControl spinner;
        private SearchBoxControl searchBox;

        public FrmInventoryMovements()
        {
            InitializeComponent();

            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(390, 8);
            spinner.Size = new Size(50, 50);
            pnlTop.Controls.Add(spinner);

            searchBox = new SearchBoxControl();
            searchBox.Location = new Point(450, 15);
            searchBox.Size = new Size(250, 35);
            searchBox.OnSearch += SearchBox_OnSearch;
            pnlTop.Controls.Add(searchBox);
        }

        private async void FrmInventoryMovements_Load(object sender, EventArgs e)
        {
            cmbFilterType.Items.Clear();
            cmbFilterType.Items.Add("All Types");
            cmbFilterType.Items.Add("Purchase");
            cmbFilterType.Items.Add("Sale");
            cmbFilterType.Items.Add("Return");
            cmbFilterType.Items.Add("Adjustment");
            cmbFilterType.Items.Add("Borrow");
            cmbFilterType.SelectedIndex = 0;

            // ── Date Limits ──
            dtpFrom.MinDate = new DateTime(1990, 1, 1);
            dtpFrom.MaxDate = DateTime.Today;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);

            dtpTo.MinDate = new DateTime(1990, 1, 1);
            dtpTo.MaxDate = DateTime.Today;
            dtpTo.Value = DateTime.Today;

            await LoadMovements();
        }

        private async System.Threading.Tasks.Task LoadMovements()
        {
            try
            {
                spinner.Start();
                _movements = await ApiHelper.GetAsync<List<InventoryMovement>>("inventorymovements")
                             ?? new List<InventoryMovement>();
                BindGrid(_movements);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading movements: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
            }
        }

        private void BindGrid(List<InventoryMovement> list)
        {
            dgvMovements.Rows.Clear();
            foreach (var m in list)
            {
                dgvMovements.Rows.Add(
                    m.MovementID,
                    m.MovementDate.ToString("yyyy-MM-dd HH:mm"),
                    m.ProductName,
                    m.MovementType,
                    m.Quantity,
                    m.UnitPrice.HasValue ? m.UnitPrice.Value.ToString("N2") : "0.00",
                    m.TotalAmount.HasValue ? m.TotalAmount.Value.ToString("N2") : "0.00",
                    m.ReferenceType,
                    m.Notes
                );
            }
            lblCount.Text = "Total: " + list.Count;
        }

        private void SearchBox_OnSearch(object sender, string text)
        {
            if (string.IsNullOrEmpty(text)) { BindGrid(_movements); return; }

            string search = text.ToLower();
            var filtered = new List<InventoryMovement>();

            foreach (var m in _movements)
            {
                if (m.ProductName.ToLower().Contains(search) ||
                   (m.MovementType != null && m.MovementType.ToLower().Contains(search)) ||
                   (m.ReferenceType != null && m.ReferenceType.ToLower().Contains(search)))
                {
                    filtered.Add(m);
                }
            }

            BindGrid(filtered);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedType = cmbFilterType.SelectedIndex > 0
                ? cmbFilterType.SelectedItem?.ToString() : "";

            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1);

            var filtered = new List<InventoryMovement>();

            foreach (var m in _movements)
            {
                bool matchType = string.IsNullOrEmpty(selectedType)
                    || m.MovementType == selectedType;

                bool matchDate = m.MovementDate >= fromDate
                    && m.MovementDate < toDate;

                if (matchType && matchDate)
                    filtered.Add(m);
            }

            BindGrid(filtered);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            searchBox.Clear();
            BindGrid(_movements);
        }

        private void dgvMovements_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMovements.Rows[e.RowIndex];
            string type = row.Cells["colMovementType"].Value?.ToString();

            switch (type)
            {
                case "Purchase":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(40, 160, 100);
                    break;
                case "Sale":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 100, 180);
                    break;
                case "Adjustment":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 110, 0);
                    break;
                case "Return":
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 50, 150);
                    break;
                default:
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 40, 60);
                    break;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            cmbFilterType.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            await LoadMovements();
        }
    }
}