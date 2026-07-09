namespace LibrarySystem.WinForms.Forms.Accounting
{
    partial class FrmAccountBalances
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

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvBalances = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountNameAr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiscalYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiscalMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOpeningBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebitTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreditTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClosingBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.cmbAccount);
            this.pnlTop.Controls.Add(this.cmbYear);
            this.pnlTop.Controls.Add(this.cmbMonth);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(960, 65);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(10, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📈 Account Balances";

            // lblCount
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(232, 22);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(80, 25);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Total: 0";

            // cmbAccount
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbAccount.Location = new System.Drawing.Point(318, 18);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(200, 28);
            this.cmbAccount.TabIndex = 2;

            // cmbYear
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbYear.Location = new System.Drawing.Point(526, 18);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(80, 28);
            this.cmbYear.TabIndex = 3;

            // cmbMonth
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMonth.Location = new System.Drawing.Point(614, 18);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(70, 28);
            this.cmbMonth.TabIndex = 4;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(694, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(120, 130, 140);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(856, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 34);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // pnlGrid
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvBalances);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(8);
            this.pnlGrid.TabIndex = 1;

            // dgvBalances
            this.dgvBalances.AllowUserToAddRows = false;
            this.dgvBalances.AllowUserToDeleteRows = false;
            this.dgvBalances.AutoGenerateColumns = false;
            this.dgvBalances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBalances.BackgroundColor = System.Drawing.Color.White;
            this.dgvBalances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBalances.ReadOnly = true;
            this.dgvBalances.Dock = System.Windows.Forms.DockStyle.Fill;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvBalances.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBalances.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvBalances.ColumnHeadersHeight = 40;

            this.dgvBalances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID,
                this.colAccountCode,
                this.colAccountName,
                this.colAccountNameAr,
                this.colAccountType,
                this.colFiscalYear,
                this.colFiscalMonth,
                this.colOpeningBalance,
                this.colDebitTotal,
                this.colCreditTotal,
                this.colClosingBalance
            });

            this.dgvBalances.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvBalances.MultiSelect = false;
            this.dgvBalances.Name = "dgvBalances";
            this.dgvBalances.RowHeadersVisible = false;
            this.dgvBalances.RowTemplate.Height = 36;
            this.dgvBalances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalances.TabIndex = 0;

            // Columns
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;

            this.colAccountCode.FillWeight = 8F;
            this.colAccountCode.HeaderText = "Code";
            this.colAccountCode.Name = "colAccountCode";

            this.colAccountName.FillWeight = 18F;
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";

            this.colAccountNameAr.FillWeight = 14F;
            this.colAccountNameAr.HeaderText = "Arabic Name";
            this.colAccountNameAr.Name = "colAccountNameAr";

            this.colAccountType.FillWeight = 10F;
            this.colAccountType.HeaderText = "Type";
            this.colAccountType.Name = "colAccountType";

            this.colFiscalYear.FillWeight = 7F;
            this.colFiscalYear.HeaderText = "Year";
            this.colFiscalYear.Name = "colFiscalYear";

            this.colFiscalMonth.FillWeight = 7F;
            this.colFiscalMonth.HeaderText = "Month";
            this.colFiscalMonth.Name = "colFiscalMonth";

            this.colOpeningBalance.FillWeight = 11F;
            this.colOpeningBalance.HeaderText = "Opening";
            this.colOpeningBalance.Name = "colOpeningBalance";

            this.colDebitTotal.FillWeight = 11F;
            this.colDebitTotal.HeaderText = "Debit Total";
            this.colDebitTotal.Name = "colDebitTotal";

            this.colCreditTotal.FillWeight = 11F;
            this.colCreditTotal.HeaderText = "Credit Total";
            this.colCreditTotal.Name = "colCreditTotal";

            this.colClosingBalance.FillWeight = 11F;
            this.colClosingBalance.HeaderText = "Closing";
            this.colClosingBalance.Name = "colClosingBalance";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(960, 580);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmAccountBalances";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Balances";
            this.Load += new System.EventHandler(this.FrmAccountBalances_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvBalances;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountNameAr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiscalYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiscalMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOpeningBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDebitTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreditTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClosingBalance;
    }
}