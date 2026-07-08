using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmSaleInvoiceView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private Panel pnlHeader, pnlBody, pnlFooter, pnlFooterButtons;
        private Label lblTitle, lblInvoiceNumber, lblDate;
        private GroupBox grpInfo;
        private Label lblCustomer, lblPaymentType, lblPaymentMethod, lblSalesRep, lblNotes;
        private DataGridView dgvItems;
        private DataGridViewTextBoxColumn colProductName, colQty, colUnitPrice, colDiscountAmt, colTotal;
        private GroupBox grpTotals;
        private Label lblSubTotalLabel, lblSubTotal;
        private Label lblDiscountLabel, lblDiscount;
        private Label lblTaxLabel, lblTax;
        private Label lblTotalLabel, lblTotal;
        private Label lblPaidLabel, lblPaid;
        private Label lblRemainingLabel, lblRemaining;
        private Button btnClose;
        private Button btnPrint;
        private CheckBox chkThermalPrint;

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblInvoiceNumber = new Label();
            this.lblDate = new Label();
            this.pnlBody = new Panel();
            this.grpInfo = new GroupBox();
            this.lblCustomer = new Label();
            this.lblPaymentType = new Label();
            this.lblPaymentMethod = new Label();
            this.lblSalesRep = new Label();
            this.lblNotes = new Label();
            this.dgvItems = new DataGridView();
            this.colProductName = new DataGridViewTextBoxColumn();
            this.colQty = new DataGridViewTextBoxColumn();
            this.colUnitPrice = new DataGridViewTextBoxColumn();
            this.colDiscountAmt = new DataGridViewTextBoxColumn();
            this.colTotal = new DataGridViewTextBoxColumn();
            this.pnlFooter = new Panel();
            this.grpTotals = new GroupBox();
            this.lblSubTotalLabel = new Label();
            this.lblSubTotal = new Label();
            this.lblDiscountLabel = new Label();
            this.lblDiscount = new Label();
            this.lblTaxLabel = new Label();
            this.lblTax = new Label();
            this.lblTotalLabel = new Label();
            this.lblTotal = new Label();
            this.lblPaidLabel = new Label();
            this.lblPaid = new Label();
            this.lblRemainingLabel = new Label();
            this.lblRemaining = new Label();
            this.pnlFooterButtons = new Panel();
            this.btnClose = new Button();
            this.btnPrint = new Button();
            this.chkThermalPrint = new CheckBox();

            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.grpTotals.SuspendLayout();
            this.pnlFooterButtons.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.FromArgb(22, 32, 50);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Size = new Size(1000, 58);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblInvoiceNumber);
            this.pnlHeader.Controls.Add(this.lblDate);

            // lblTitle
            this.lblTitle.Text = "🧾 Sale Invoice";
            this.lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(15, 13);
            this.lblTitle.Size = new Size(240, 32);

            // lblInvoiceNumber
            this.lblInvoiceNumber.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            this.lblInvoiceNumber.ForeColor = Color.FromArgb(160, 200, 255);
            this.lblInvoiceNumber.Location = new Point(260, 16);
            this.lblInvoiceNumber.Size = new Size(280, 26);

            // lblDate
            this.lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblDate.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.lblDate.ForeColor = Color.White;
            this.lblDate.Location = new Point(700, 18);
            this.lblDate.Size = new Size(280, 22);
            this.lblDate.TextAlign = ContentAlignment.MiddleRight;

            // pnlBody
            this.pnlBody.BackColor = Color.FromArgb(240, 242, 245);
            this.pnlBody.Dock = DockStyle.Fill;
            this.pnlBody.Padding = new Padding(8);
            this.pnlBody.Location = new Point(0, 58);
            this.pnlBody.Size = new Size(1000, 532);
            this.pnlBody.Controls.Add(this.dgvItems);
            this.pnlBody.Controls.Add(this.grpInfo);

            // grpInfo
            this.grpInfo.Dock = DockStyle.Top;
            this.grpInfo.Height = 100;
            this.grpInfo.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.grpInfo.ForeColor = Color.FromArgb(22, 32, 50);
            this.grpInfo.Text = "Invoice Info";
            this.grpInfo.Controls.Add(this.lblCustomer);
            this.grpInfo.Controls.Add(this.lblPaymentType);
            this.grpInfo.Controls.Add(this.lblPaymentMethod);
            this.grpInfo.Controls.Add(this.lblSalesRep);
            this.grpInfo.Controls.Add(this.lblNotes);

            // lblCustomer
            this.lblCustomer.Font = new Font("Segoe UI", 9.5f);
            this.lblCustomer.Location = new Point(15, 26);
            this.lblCustomer.Size = new Size(300, 20);

            // lblPaymentType
            this.lblPaymentType.Font = new Font("Segoe UI", 9.5f);
            this.lblPaymentType.Location = new Point(325, 26);
            this.lblPaymentType.Size = new Size(220, 20);

            // lblPaymentMethod
            this.lblPaymentMethod.Font = new Font("Segoe UI", 9.5f);
            this.lblPaymentMethod.Location = new Point(555, 26);
            this.lblPaymentMethod.Size = new Size(220, 20);

            // lblSalesRep
            this.lblSalesRep.Font = new Font("Segoe UI", 9.5f);
            this.lblSalesRep.Location = new Point(15, 52);
            this.lblSalesRep.Size = new Size(400, 20);

            // lblNotes
            this.lblNotes.Font = new Font("Segoe UI", 9f, FontStyle.Italic);
            this.lblNotes.ForeColor = Color.Gray;
            this.lblNotes.Location = new Point(15, 76);
            this.lblNotes.Size = new Size(940, 20);

            // dgvItems
            this.dgvItems.Dock = DockStyle.Fill;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.MultiSelect = false;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.BorderStyle = BorderStyle.None;
            this.dgvItems.BackgroundColor = Color.White;
            this.dgvItems.Font = new Font("Segoe UI", 9.5f);
            this.dgvItems.ColumnHeadersHeight = 40;
            this.dgvItems.EnableHeadersVisualStyles = false;
            this.dgvItems.RowTemplate.Height = 32;
            this.dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 32, 50);
            this.dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            this.dgvItems.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            this.dgvItems.Columns.AddRange(new DataGridViewColumn[] {
                this.colProductName, this.colQty, this.colUnitPrice, this.colDiscountAmt, this.colTotal });

            // columns
            this.colProductName.HeaderText = "Product";
            this.colProductName.Name = "colProductName";
            this.colProductName.FillWeight = 40;

            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.FillWeight = 12;
            this.colQty.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.FillWeight = 16;
            this.colUnitPrice.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colDiscountAmt.HeaderText = "Discount";
            this.colDiscountAmt.Name = "colDiscountAmt";
            this.colDiscountAmt.FillWeight = 16;
            this.colDiscountAmt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.FillWeight = 16;
            this.colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // pnlFooter
            this.pnlFooter.BackColor = Color.White;
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Height = 90;
            this.pnlFooter.Location = new Point(0, 590);
            this.pnlFooter.Size = new Size(1000, 90);
            this.pnlFooter.Controls.Add(this.grpTotals);
            this.pnlFooter.Controls.Add(this.pnlFooterButtons);

            // grpTotals
            this.grpTotals.Dock = DockStyle.Fill;
            this.grpTotals.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            this.grpTotals.Text = "Totals";
            this.grpTotals.Controls.Add(this.lblSubTotalLabel);
            this.grpTotals.Controls.Add(this.lblSubTotal);
            this.grpTotals.Controls.Add(this.lblDiscountLabel);
            this.grpTotals.Controls.Add(this.lblDiscount);
            this.grpTotals.Controls.Add(this.lblTaxLabel);
            this.grpTotals.Controls.Add(this.lblTax);
            this.grpTotals.Controls.Add(this.lblTotalLabel);
            this.grpTotals.Controls.Add(this.lblTotal);
            this.grpTotals.Controls.Add(this.lblPaidLabel);
            this.grpTotals.Controls.Add(this.lblPaid);
            this.grpTotals.Controls.Add(this.lblRemainingLabel);
            this.grpTotals.Controls.Add(this.lblRemaining);

            this.lblSubTotalLabel.Text = "SubTotal:";
            this.lblSubTotalLabel.Font = new Font("Segoe UI", 7.5f);
            this.lblSubTotalLabel.ForeColor = Color.Gray;
            this.lblSubTotalLabel.Location = new Point(15, 20);
            this.lblSubTotalLabel.Size = new Size(70, 14);

            this.lblSubTotal.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblSubTotal.ForeColor = Color.FromArgb(30, 100, 180);
            this.lblSubTotal.Location = new Point(15, 35);
            this.lblSubTotal.Size = new Size(110, 22);
            this.lblSubTotal.Text = "0.000";

            this.lblDiscountLabel.Text = "Discount:";
            this.lblDiscountLabel.Font = new Font("Segoe UI", 7.5f);
            this.lblDiscountLabel.ForeColor = Color.Gray;
            this.lblDiscountLabel.Location = new Point(135, 20);
            this.lblDiscountLabel.Size = new Size(70, 14);

            this.lblDiscount.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblDiscount.Location = new Point(135, 35);
            this.lblDiscount.Size = new Size(110, 22);
            this.lblDiscount.Text = "0.000";

            this.lblTaxLabel.Text = "Tax:";
            this.lblTaxLabel.Font = new Font("Segoe UI", 7.5f);
            this.lblTaxLabel.ForeColor = Color.Gray;
            this.lblTaxLabel.Location = new Point(255, 20);
            this.lblTaxLabel.Size = new Size(70, 14);

            this.lblTax.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblTax.ForeColor = Color.FromArgb(150, 90, 0);
            this.lblTax.Location = new Point(255, 35);
            this.lblTax.Size = new Size(110, 22);
            this.lblTax.Text = "0.000";

            this.lblTotalLabel.Text = "Total:";
            this.lblTotalLabel.Font = new Font("Segoe UI", 7.5f);
            this.lblTotalLabel.ForeColor = Color.Gray;
            this.lblTotalLabel.Location = new Point(375, 20);
            this.lblTotalLabel.Size = new Size(70, 14);

            this.lblTotal.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            this.lblTotal.ForeColor = Color.FromArgb(22, 32, 50);
            this.lblTotal.Location = new Point(375, 33);
            this.lblTotal.Size = new Size(140, 26);
            this.lblTotal.Text = "0.000";

            this.lblPaidLabel.Text = "Paid:";
            this.lblPaidLabel.Font = new Font("Segoe UI", 7.5f);
            this.lblPaidLabel.ForeColor = Color.Gray;
            this.lblPaidLabel.Location = new Point(525, 20);
            this.lblPaidLabel.Size = new Size(70, 14);

            this.lblPaid.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.lblPaid.Location = new Point(525, 35);
            this.lblPaid.Size = new Size(110, 22);
            this.lblPaid.Text = "0.000";

            this.lblRemainingLabel.Text = "Remaining:";
            this.lblRemainingLabel.Font = new Font("Segoe UI", 7.5f);
            this.lblRemainingLabel.ForeColor = Color.Gray;
            this.lblRemainingLabel.Location = new Point(645, 20);
            this.lblRemainingLabel.Size = new Size(80, 14);

            this.lblRemaining.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            this.lblRemaining.ForeColor = Color.FromArgb(200, 50, 50);
            this.lblRemaining.Location = new Point(645, 34);
            this.lblRemaining.Size = new Size(200, 24);
            this.lblRemaining.Text = "0.000";

            // pnlFooterButtons
            this.pnlFooterButtons.Dock = DockStyle.Right;
            this.pnlFooterButtons.Width = 260;
            this.pnlFooterButtons.BackColor = Color.White;
            this.pnlFooterButtons.Controls.Add(this.btnClose);
            this.pnlFooterButtons.Controls.Add(this.btnPrint);
            this.pnlFooterButtons.Controls.Add(this.chkThermalPrint);

            // btnPrint
            this.btnPrint.Text = "🖨 Print";
            this.btnPrint.Size = new Size(110, 40);
            this.btnPrint.Location = new Point(15, 25);
            this.btnPrint.BackColor = Color.FromArgb(80, 140, 60);
            this.btnPrint.ForeColor = Color.White;
            this.btnPrint.FlatStyle = FlatStyle.Flat;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.Cursor = Cursors.Hand;
            this.btnPrint.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);

            // chkThermalPrint
            this.chkThermalPrint.Text = "Thermal";
            this.chkThermalPrint.Location = new Point(15, 5);
            this.chkThermalPrint.Size = new Size(90, 18);
            this.chkThermalPrint.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            this.chkThermalPrint.Cursor = Cursors.Hand;

            // btnClose
            this.btnClose.Text = "✖ Close";
            this.btnClose.Size = new Size(110, 40);
            this.btnClose.Location = new Point(135, 25);
            this.btnClose.BackColor = Color.FromArgb(100, 110, 130);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // FrmSaleInvoiceView
            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 680);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Font = new Font("Segoe UI", 10f);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaleInvoiceView";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Sale Invoice - View";

            this.pnlHeader.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.grpInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.grpTotals.ResumeLayout(false);
            this.pnlFooterButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}