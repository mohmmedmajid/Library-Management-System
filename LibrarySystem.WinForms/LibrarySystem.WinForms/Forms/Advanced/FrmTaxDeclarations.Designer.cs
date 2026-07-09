namespace LibrarySystem.WinForms.Forms.Advanced
{
    partial class FrmTaxDeclarations
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
            System.Windows.Forms.DataGridViewCellStyle colSubmitStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colPayStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvDeclarations = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeclarationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTaxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeclarationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiscalYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiscalMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPeriodEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetTaxDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemainingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colPay = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeclarations)).BeginInit();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);
            this.pnlTop.TabIndex = 0;

            // ── lblTitle ──
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(15, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🧾 Tax Declarations";

            // ── lblCount ──
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(280, 22);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(80, 22);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Total: 0";

            // ── btnNew ──
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(890, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(90, 34);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "+ New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // ── btnRefresh ──
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(990, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(95, 34);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvDeclarations);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlGrid.TabIndex = 1;

            // ── dgvDeclarations ──
            this.dgvDeclarations.AllowUserToAddRows = false;
            this.dgvDeclarations.AllowUserToDeleteRows = false;
            this.dgvDeclarations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeclarations.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeclarations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeclarations.Dock = System.Windows.Forms.DockStyle.Fill;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvDeclarations.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeclarations.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvDeclarations.ColumnHeadersHeight = 40;

            this.dgvDeclarations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID,
                this.colDeclarationNumber,
                this.colTaxName,
                this.colDeclarationType,
                this.colFiscalYear,
                this.colFiscalMonth,
                this.colPeriodStart,
                this.colPeriodEnd,
                this.colNetTaxDue,
                this.colPaidAmount,
                this.colRemainingAmount,
                this.colStatus,
                this.colSubmit,
                this.colPay
            });

            this.dgvDeclarations.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvDeclarations.MultiSelect = false;
            this.dgvDeclarations.Name = "dgvDeclarations";
            this.dgvDeclarations.RowHeadersVisible = false;
            this.dgvDeclarations.RowTemplate.Height = 36;
            this.dgvDeclarations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeclarations.TabIndex = 0;
            this.dgvDeclarations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeclarations_CellClick);

            // ── Columns ──
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;

            this.colDeclarationNumber.FillWeight = 12F;
            this.colDeclarationNumber.HeaderText = "Declaration #";
            this.colDeclarationNumber.Name = "colDeclarationNumber";

            this.colTaxName.FillWeight = 12F;
            this.colTaxName.HeaderText = "Tax Name";
            this.colTaxName.Name = "colTaxName";

            this.colDeclarationType.FillWeight = 9F;
            this.colDeclarationType.HeaderText = "Type";
            this.colDeclarationType.Name = "colDeclarationType";

            this.colFiscalYear.FillWeight = 6F;
            this.colFiscalYear.HeaderText = "Year";
            this.colFiscalYear.Name = "colFiscalYear";

            this.colFiscalMonth.FillWeight = 6F;
            this.colFiscalMonth.HeaderText = "Month";
            this.colFiscalMonth.Name = "colFiscalMonth";

            this.colPeriodStart.FillWeight = 8F;
            this.colPeriodStart.HeaderText = "Period Start";
            this.colPeriodStart.Name = "colPeriodStart";

            this.colPeriodEnd.FillWeight = 8F;
            this.colPeriodEnd.HeaderText = "Period End";
            this.colPeriodEnd.Name = "colPeriodEnd";

            this.colNetTaxDue.FillWeight = 8F;
            this.colNetTaxDue.HeaderText = "Net Due";
            this.colNetTaxDue.Name = "colNetTaxDue";

            this.colPaidAmount.FillWeight = 7F;
            this.colPaidAmount.HeaderText = "Paid";
            this.colPaidAmount.Name = "colPaidAmount";

            this.colRemainingAmount.FillWeight = 7F;
            this.colRemainingAmount.HeaderText = "Remaining";
            this.colRemainingAmount.Name = "colRemainingAmount";

            this.colStatus.FillWeight = 7F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";

            // ── colSubmit ──
            colSubmitStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colSubmitStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colSubmitStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colSubmitStyle.ForeColor = System.Drawing.Color.White;
            colSubmitStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colSubmitStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colSubmit.DefaultCellStyle = colSubmitStyle;
            this.colSubmit.FillWeight = 8F;
            this.colSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colSubmit.HeaderText = "";
            this.colSubmit.Name = "colSubmit";

            // ── colPay ──
            colPayStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colPayStyle.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            colPayStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colPayStyle.ForeColor = System.Drawing.Color.White;
            colPayStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 130, 80);
            colPayStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colPay.DefaultCellStyle = colPayStyle;
            this.colPay.FillWeight = 8F;
            this.colPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colPay.HeaderText = "";
            this.colPay.Name = "colPay";

            // ── FrmTaxDeclarations ──
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmTaxDeclarations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Declarations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTaxDeclarations_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeclarations)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvDeclarations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeclarationNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTaxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeclarationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiscalYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiscalMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetTaxDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRemainingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colSubmit;
        private System.Windows.Forms.DataGridViewButtonColumn colPay;
    }
}