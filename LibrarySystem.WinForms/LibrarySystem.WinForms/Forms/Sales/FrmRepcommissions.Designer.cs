namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmRepCommissions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colMarkPaidStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCommissions = new System.Windows.Forms.DataGridView();

            this.colCommissionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSalesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCommAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMarkPaid = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommissions)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1134, 65);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.TabIndex = 0;

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(280, 35);
            this.lblTitle.Text = "💰 Rep Commissions";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(300, 22);
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.Text = "Total: 0";

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1025, 15);
            this.btnRefresh.Size = new System.Drawing.Size(105, 36);
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvCommissions);
            this.pnlGrid.Location = new System.Drawing.Point(10, 75);
            this.pnlGrid.Size = new System.Drawing.Size(1114, 600);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.TabIndex = 1;

            // ── dgvCommissions ──
            this.dgvCommissions.AllowUserToAddRows = false;
            this.dgvCommissions.AllowUserToDeleteRows = false;
            this.dgvCommissions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommissions.BackgroundColor = System.Drawing.Color.White;
            this.dgvCommissions.BorderStyle = System.Windows.Forms.BorderStyle.None;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvCommissions.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommissions.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvCommissions.ColumnHeadersHeight = 42;

            this.dgvCommissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCommissionID,
                this.colRepName,
                this.colInvoiceNumber,
                this.colSalesAmount,
                this.colCommPercent,
                this.colCommAmount,
                this.colPaidStatus,
                this.colCreatedDate,
                this.colMarkPaid
            });

            this.dgvCommissions.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvCommissions.Location = new System.Drawing.Point(0, 0);
            this.dgvCommissions.MultiSelect = false;
            this.dgvCommissions.Name = "dgvCommissions";
            this.dgvCommissions.RowHeadersVisible = false;
            this.dgvCommissions.RowTemplate.Height = 38;
            this.dgvCommissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommissions.Size = new System.Drawing.Size(1114, 590);
            this.dgvCommissions.TabIndex = 0;
            this.dgvCommissions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommissions_CellClick);

            // ── Columns ──
            this.colCommissionID.HeaderText = "ID";
            this.colCommissionID.Name = "colCommissionID";
            this.colCommissionID.Visible = false;

            this.colRepName.FillWeight = 16F;
            this.colRepName.HeaderText = "Rep";
            this.colRepName.Name = "colRepName";

            this.colInvoiceNumber.FillWeight = 13F;
            this.colInvoiceNumber.HeaderText = "Invoice #";
            this.colInvoiceNumber.Name = "colInvoiceNumber";

            this.colSalesAmount.FillWeight = 12F;
            this.colSalesAmount.HeaderText = "Sales Amt";
            this.colSalesAmount.Name = "colSalesAmount";

            this.colCommPercent.FillWeight = 9F;
            this.colCommPercent.HeaderText = "Rate %";
            this.colCommPercent.Name = "colCommPercent";

            this.colCommAmount.FillWeight = 12F;
            this.colCommAmount.HeaderText = "Commission";
            this.colCommAmount.Name = "colCommAmount";

            this.colPaidStatus.FillWeight = 10F;
            this.colPaidStatus.HeaderText = "Status";
            this.colPaidStatus.Name = "colPaidStatus";

            this.colCreatedDate.FillWeight = 11F;
            this.colCreatedDate.HeaderText = "Date";
            this.colCreatedDate.Name = "colCreatedDate";

            // colMarkPaid - blue
            colMarkPaidStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colMarkPaidStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colMarkPaidStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colMarkPaidStyle.ForeColor = System.Drawing.Color.White;
            colMarkPaidStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colMarkPaidStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colMarkPaid.DefaultCellStyle = colMarkPaidStyle;
            this.colMarkPaid.FillWeight = 12F;
            this.colMarkPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colMarkPaid.HeaderText = "";
            this.colMarkPaid.Name = "colMarkPaid";

            // ── FrmRepCommissions ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1134, 690);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmRepCommissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rep Commissions";
            this.Load += new System.EventHandler(this.FrmRepCommissions_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommissions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvCommissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommissionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSalesAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCommAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
        private System.Windows.Forms.DataGridViewButtonColumn colMarkPaid;
    }
}