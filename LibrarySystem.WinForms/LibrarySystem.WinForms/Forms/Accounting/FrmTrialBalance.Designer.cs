namespace LibrarySystem.WinForms.Forms.Accounting
{
    partial class FrmTrialBalance
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

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPeriodLabel = new System.Windows.Forms.Label();
            this.lblPeriodValue = new System.Windows.Forms.Label();

            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblYear = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();

            this.dgvTrialBalance = new System.Windows.Forms.DataGridView();
            this.colAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreditTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalOpeningLbl = new System.Windows.Forms.Label();
            this.lblTotalOpeningVal = new System.Windows.Forms.Label();
            this.lblTotalDebitLbl = new System.Windows.Forms.Label();
            this.lblTotalDebitVal = new System.Windows.Forms.Label();
            this.lblTotalCreditLbl = new System.Windows.Forms.Label();
            this.lblTotalCreditVal = new System.Windows.Forms.Label();
            this.lblTotalClosingLbl = new System.Windows.Forms.Label();
            this.lblTotalClosingVal = new System.Windows.Forms.Label();
            this.lblBalanceLbl = new System.Windows.Forms.Label();
            this.lblBalanceVal = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrialBalance)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════
            // pnlHeader
            // ══════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 58;
            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblPeriodLabel, this.lblPeriodValue });

            this.lblTitle.Text = "Trial Balance";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Size = new System.Drawing.Size(260, 32);

            this.lblPeriodLabel.Text = "Period:";
            this.lblPeriodLabel.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblPeriodLabel.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblPeriodLabel.Location = new System.Drawing.Point(290, 20);
            this.lblPeriodLabel.Size = new System.Drawing.Size(50, 20);

            this.lblPeriodValue.Text = "--";
            this.lblPeriodValue.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblPeriodValue.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblPeriodValue.Location = new System.Drawing.Point(344, 20);
            this.lblPeriodValue.Size = new System.Drawing.Size(300, 20);

            // ══════════════════════════════════════
            // pnlFilter
            // ══════════════════════════════════════
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Height = 56;
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblYear, this.nudYear,
                this.lblMonth, this.cmbMonth,
                this.btnGenerate,
                this.lblSearch, this.txtSearch,
                this.lblCount });

            this.lblYear.Text = "Year:";
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblYear.Location = new System.Drawing.Point(12, 18);
            this.lblYear.Size = new System.Drawing.Size(38, 20);

            this.nudYear.Location = new System.Drawing.Point(54, 15);
            this.nudYear.Size = new System.Drawing.Size(80, 26);
            this.nudYear.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.nudYear.Minimum = 2000;
            this.nudYear.Maximum = 2100;
            this.nudYear.Value = System.DateTime.Now.Year;

            this.lblMonth.Text = "Month:";
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblMonth.Location = new System.Drawing.Point(146, 18);
            this.lblMonth.Size = new System.Drawing.Size(50, 20);

            this.cmbMonth.Location = new System.Drawing.Point(200, 15);
            this.cmbMonth.Size = new System.Drawing.Size(140, 26);
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Items.AddRange(new object[] {
                "1 - January", "2 - February", "3 - March", "4 - April",
                "5 - May", "6 - June", "7 - July", "8 - August",
                "9 - September", "10 - October", "11 - November", "12 - December" });
            this.cmbMonth.SelectedIndex = 0;

            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Location = new System.Drawing.Point(352, 14);
            this.btnGenerate.Size = new System.Drawing.Size(100, 28);
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            this.lblSearch.Text = "Search:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSearch.Location = new System.Drawing.Point(470, 18);
            this.lblSearch.Size = new System.Drawing.Size(52, 20);

            this.txtSearch.Location = new System.Drawing.Point(526, 15);
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(740, 18);
            this.lblCount.Size = new System.Drawing.Size(120, 20);
            this.lblCount.Text = "Accounts: 0";

            // ══════════════════════════════════════
            // pnlFooter
            // ══════════════════════════════════════
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 56;
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlFooter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTotalOpeningLbl, this.lblTotalOpeningVal,
                this.lblTotalDebitLbl, this.lblTotalDebitVal,
                this.lblTotalCreditLbl, this.lblTotalCreditVal,
                this.lblTotalClosingLbl, this.lblTotalClosingVal,
                this.lblBalanceLbl, this.lblBalanceVal,
                this.btnClose });

            // Opening
            this.lblTotalOpeningLbl.Text = "Opening:";
            this.lblTotalOpeningLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalOpeningLbl.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblTotalOpeningLbl.Location = new System.Drawing.Point(68, 10);
            this.lblTotalOpeningLbl.Size = new System.Drawing.Size(60, 18);

            this.lblTotalOpeningVal.Text = "0.000";
            this.lblTotalOpeningVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalOpeningVal.ForeColor = System.Drawing.Color.White;
            this.lblTotalOpeningVal.Location = new System.Drawing.Point(68, 28);
            this.lblTotalOpeningVal.Size = new System.Drawing.Size(130, 20);

            // Debit
            this.lblTotalDebitLbl.Text = "Total Debit:";
            this.lblTotalDebitLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalDebitLbl.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblTotalDebitLbl.Location = new System.Drawing.Point(220, 10);
            this.lblTotalDebitLbl.Size = new System.Drawing.Size(90, 18);

            this.lblTotalDebitVal.Text = "0.000";
            this.lblTotalDebitVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalDebitVal.ForeColor = System.Drawing.Color.FromArgb(100, 180, 255);
            this.lblTotalDebitVal.Location = new System.Drawing.Point(220, 28);
            this.lblTotalDebitVal.Size = new System.Drawing.Size(130, 20);

            // Credit
            this.lblTotalCreditLbl.Text = "Total Credit:";
            this.lblTotalCreditLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalCreditLbl.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblTotalCreditLbl.Location = new System.Drawing.Point(370, 10);
            this.lblTotalCreditLbl.Size = new System.Drawing.Size(90, 18);

            this.lblTotalCreditVal.Text = "0.000";
            this.lblTotalCreditVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalCreditVal.ForeColor = System.Drawing.Color.FromArgb(100, 220, 140);
            this.lblTotalCreditVal.Location = new System.Drawing.Point(370, 28);
            this.lblTotalCreditVal.Size = new System.Drawing.Size(130, 20);

            // Closing
            this.lblTotalClosingLbl.Text = "Closing:";
            this.lblTotalClosingLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalClosingLbl.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblTotalClosingLbl.Location = new System.Drawing.Point(520, 10);
            this.lblTotalClosingLbl.Size = new System.Drawing.Size(70, 18);

            this.lblTotalClosingVal.Text = "0.000";
            this.lblTotalClosingVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblTotalClosingVal.ForeColor = System.Drawing.Color.White;
            this.lblTotalClosingVal.Location = new System.Drawing.Point(520, 28);
            this.lblTotalClosingVal.Size = new System.Drawing.Size(130, 20);

            // Balance status
            this.lblBalanceLbl.Text = "Status:";
            this.lblBalanceLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblBalanceLbl.ForeColor = System.Drawing.Color.FromArgb(180, 190, 210);
            this.lblBalanceLbl.Location = new System.Drawing.Point(666, 10);
            this.lblBalanceLbl.Size = new System.Drawing.Size(50, 18);

            this.lblBalanceVal.Text = "--";
            this.lblBalanceVal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblBalanceVal.ForeColor = System.Drawing.Color.White;
            this.lblBalanceVal.Location = new System.Drawing.Point(666, 28);
            this.lblBalanceVal.Size = new System.Drawing.Size(260, 20);

            this.btnClose.Text = "Close";
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnClose.Size = new System.Drawing.Size(100, 34);
            this.btnClose.Location = new System.Drawing.Point(980, 11);
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ══════════════════════════════════════
            // dgvTrialBalance
            // ══════════════════════════════════════
            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvTrialBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrialBalance.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvTrialBalance.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrialBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTrialBalance.RowTemplate.Height = 36;
            this.dgvTrialBalance.ColumnHeadersHeight = 42;
            this.dgvTrialBalance.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvTrialBalance.AlternatingRowsDefaultCellStyle = alternatingStyle;
            this.dgvTrialBalance.AllowUserToAddRows = false;
            this.dgvTrialBalance.AllowUserToDeleteRows = false;
            this.dgvTrialBalance.ReadOnly = true;
            this.dgvTrialBalance.MultiSelect = false;
            this.dgvTrialBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrialBalance.RowHeadersVisible = false;
            this.dgvTrialBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.colAccountCode.HeaderText = "Account Code";
            this.colAccountCode.Name = "colAccountCode";
            this.colAccountCode.FillWeight = 12f;

            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.FillWeight = 32f;

            this.colAccountType.HeaderText = "Type";
            this.colAccountType.Name = "colAccountType";
            this.colAccountType.FillWeight = 14f;

            this.colOpening.HeaderText = "Opening Balance";
            this.colOpening.Name = "colOpening";
            this.colOpening.FillWeight = 14f;
            this.colOpening.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colDebitTotal.HeaderText = "Debit";
            this.colDebitTotal.Name = "colDebitTotal";
            this.colDebitTotal.FillWeight = 14f;
            this.colDebitTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colCreditTotal.HeaderText = "Credit";
            this.colCreditTotal.Name = "colCreditTotal";
            this.colCreditTotal.FillWeight = 14f;
            this.colCreditTotal.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colClosingBalance.HeaderText = "Closing Balance";
            this.colClosingBalance.Name = "colClosingBalance";
            this.colClosingBalance.FillWeight = 14f;
            this.colClosingBalance.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.dgvTrialBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAccountCode, this.colAccountName, this.colAccountType,
                this.colOpening, this.colDebitTotal, this.colCreditTotal, this.colClosingBalance });

            // ══════════════════════════════════════
            // Form
            // ══════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.dgvTrialBalance);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Name = "FrmTrialBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trial Balance";
            this.Load += new System.EventHandler(this.FrmTrialBalance_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrialBalance)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPeriodLabel;
        private System.Windows.Forms.Label lblPeriodValue;

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.DataGridView dgvTrialBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpening;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreditTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosingBalance;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTotalOpeningLbl;
        private System.Windows.Forms.Label lblTotalOpeningVal;
        private System.Windows.Forms.Label lblTotalDebitLbl;
        private System.Windows.Forms.Label lblTotalDebitVal;
        private System.Windows.Forms.Label lblTotalCreditLbl;
        private System.Windows.Forms.Label lblTotalCreditVal;
        private System.Windows.Forms.Label lblTotalClosingLbl;
        private System.Windows.Forms.Label lblTotalClosingVal;
        private System.Windows.Forms.Label lblBalanceLbl;
        private System.Windows.Forms.Label lblBalanceVal;
        private System.Windows.Forms.Button btnClose;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}