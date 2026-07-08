using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Forms.Sales;
using LibrarySystem.WinForms.Forms.Purchases;
using LibrarySystem.WinForms.Models.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    public partial class FrmAllInvoices : Form
    {
        private List<AllInvoiceItem> _invoices = new List<AllInvoiceItem>();

        public FrmAllInvoices()
        {
            InitializeComponent();
        }

        private async void FrmAllInvoices_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("All");
            cmbType.Items.Add("Sale");
            cmbType.Items.Add("Borrow");
            cmbType.Items.Add("Return");
            cmbType.Items.Add("Purchase");
            cmbType.Items.Add("SaleReturn");
            cmbType.Items.Add("Exchange");
            cmbType.SelectedIndex = 0;

            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;

            await LoadInvoices();
        }

        private async Task LoadInvoices()
        {
            try
            {
                var query = new StringBuilder("invoices/all?");

                string type = cmbType.SelectedItem != null ? cmbType.SelectedItem.ToString() : "All";
                if (type != "All")
                    query.Append("invoiceType=" + Uri.EscapeDataString(type) + "&");

                if (chkFilterDate.Checked)
                {
                    query.Append("startDate=" + dtpStartDate.Value.ToString("yyyy-MM-dd") + "&");
                    query.Append("endDate=" + dtpEndDate.Value.ToString("yyyy-MM-dd") + "&");
                }

                var results = await ApiHelper.GetAsync<List<AllInvoiceItem>>(query.ToString());
                _invoices = results ?? new List<AllInvoiceItem>();

                string customerFilter = txtCustomerName.Text.Trim();
                if (!string.IsNullOrEmpty(customerFilter))
                {
                    _invoices = _invoices.FindAll(i =>
                        !string.IsNullOrEmpty(i.PartyName) &&
                        i.PartyName.ToLower().Contains(customerFilter.ToLower()));
                }

                FillGrid();
            }
            catch (Exception ex) { MessageHelper.ShowError("Error loading invoices: " + ex.Message); }
        }

        private void FillGrid()
        {
            dgvInvoices.Rows.Clear();
            foreach (var inv in _invoices)
            {
                int idx = dgvInvoices.Rows.Add(
                    inv.InvoiceNumber,
                    inv.InvoiceDate.ToString("yyyy-MM-dd HH:mm"),
                    string.IsNullOrEmpty(inv.TypeNameAr) ? inv.TypeName : inv.TypeNameAr,
                    inv.PartyName,
                    inv.TotalAmount.ToString("F3"),
                    inv.RemainingAmount.ToString("F3"),
                    inv.Status
                );
                dgvInvoices.Rows[idx].Tag = inv;
            }

            lblCount.Text = "Total: " + _invoices.Count + " invoice(s)";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await LoadInvoices();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            txtCustomerName.Clear();
            chkFilterDate.Checked = false;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            await LoadInvoices();
        }

        private void chkFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpStartDate.Enabled = chkFilterDate.Checked;
            dtpEndDate.Enabled = chkFilterDate.Checked;
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var invoice = dgvInvoices.Rows[e.RowIndex].Tag as AllInvoiceItem;
            if (invoice == null) return;

            OpenOriginalInvoice(invoice);
        }

        private void OpenOriginalInvoice(AllInvoiceItem invoice)
        {
            switch (invoice.TypeName)
            {
                case "Sale":
                    try
                    {
                        var frm = new FrmSaleInvoiceView(invoice.InvoiceNumber);
                        frm.ShowDialog(this);
                    }
                    catch (Exception ex) { MessageHelper.ShowError("Error opening invoice: " + ex.Message); }
                    break;
                case "Borrow":
                    MessageHelper.ShowWarning("Open borrow invoice details for #" + invoice.InvoiceNumber + ".");
                    break;
                case "Return":
                    MessageHelper.ShowWarning("Open return invoice details for #" + invoice.InvoiceNumber + ".");
                    break;
                case "Purchase":
                    try
                    {
                        var frmP = new FrmPurchaseInvoiceView(invoice.InvoiceNumber);
                        frmP.ShowDialog(this);
                    }
                    catch (Exception ex) { MessageHelper.ShowError("Error opening invoice: " + ex.Message); }
                    break;
                case "SaleReturn":
                    MessageHelper.ShowWarning("Open sale return details for #" + invoice.InvoiceNumber + ".");
                    break;
                case "Exchange":
                    MessageHelper.ShowWarning("Open exchange details for #" + invoice.InvoiceNumber + ".");
                    break;
                default:
                    MessageHelper.ShowWarning("Unknown invoice type.");
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}