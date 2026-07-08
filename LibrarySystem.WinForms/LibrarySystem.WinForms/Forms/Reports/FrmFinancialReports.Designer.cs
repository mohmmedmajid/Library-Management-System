namespace LibrarySystem.WinForms.Forms.Reports
{
    partial class FrmFinancialReports
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
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();

            this.pnlReportType = new System.Windows.Forms.Panel();
            this.lblReportTypeFilter = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.pnlJournalFilters = new System.Windows.Forms.Panel();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();

            this.pnlBalanceFilters = new System.Windows.Forms.Panel();
            this.lblAccountFilter = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();

            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSumTitle = new System.Windows.Forms.Label();
            this.lblLbl1 = new System.Windows.Forms.Label();
            this.lblVal1 = new System.Windows.Forms.Label();
            this.lblLbl2 = new System.Windows.Forms.Label();
            this.lblVal2 = new System.Windows.Forms.Label();
            this.lblLbl3 = new System.Windows.Forms.Label();
            this.lblVal3 = new System.Windows.Forms.Label();
            this.lblLbl4 = new System.Windows.Forms.Label();
            this.lblVal4 = new System.Windows.Forms.Label();
            this.lblLbl5 = new System.Windows.Forms.Label();
            this.lblVal5 = new System.Windows.Forms.Label();
            this.lblLbl6 = new System.Windows.Forms.Label();
            this.lblVal6 = new System.Windows.Forms.Label();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlReportType.SuspendLayout();
            this.pnlJournalFilters.SuspendLayout();
            this.pnlBalanceFilters.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1020, 55);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.lblCount);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.Text = "Financial Reports";

            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblStatus.Location = new System.Drawing.Point(310, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 22);
            this.lblStatus.Text = "";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblCount.Location = new System.Drawing.Point(900, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(110, 22);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Text = "Records: 0";

            // pnlReportType
            this.pnlReportType.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlReportType.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlReportType.Size = new System.Drawing.Size(1020, 60);
            this.pnlReportType.Name = "pnlReportType";
            this.pnlReportType.Controls.Add(this.lblReportTypeFilter);
            this.pnlReportType.Controls.Add(this.cmbReportType);
            this.pnlReportType.Controls.Add(this.lblFromDate);
            this.pnlReportType.Controls.Add(this.dtpFrom);
            this.pnlReportType.Controls.Add(this.lblToDate);
            this.pnlReportType.Controls.Add(this.dtpTo);
            this.pnlReportType.Controls.Add(this.btnSearch);
            this.pnlReportType.Controls.Add(this.btnExport);

            this.lblReportTypeFilter.Text = "Report:";
            this.lblReportTypeFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblReportTypeFilter.Location = new System.Drawing.Point(8, 20);
            this.lblReportTypeFilter.Name = "lblReportTypeFilter";
            this.lblReportTypeFilter.Size = new System.Drawing.Size(50, 22);

            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbReportType.Location = new System.Drawing.Point(60, 17);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(150, 26);
            this.cmbReportType.Items.AddRange(new object[] { "Journal Entries", "Trial Balance", "Account Balances" });
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.CmbReportType_SelectedIndexChanged);

            this.lblFromDate.Text = "From:";
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFromDate.Location = new System.Drawing.Point(220, 20);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(38, 22);

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpFrom.Location = new System.Drawing.Point(260, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 26);

            this.lblToDate.Text = "To:";
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblToDate.Location = new System.Drawing.Point(362, 20);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(22, 22);

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpTo.Location = new System.Drawing.Point(386, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 26);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(804, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            this.btnExport.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(895, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 30);
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // pnlJournalFilters
            this.pnlJournalFilters.BackColor = System.Drawing.Color.FromArgb(238, 242, 248);
            this.pnlJournalFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlJournalFilters.Name = "pnlJournalFilters";
            this.pnlJournalFilters.Size = new System.Drawing.Size(1020, 50);
            this.pnlJournalFilters.Visible = true;
            this.pnlJournalFilters.Controls.Add(this.lblStatusFilter);
            this.pnlJournalFilters.Controls.Add(this.cmbStatus);
            this.pnlJournalFilters.Controls.Add(this.lblSearchFilter);
            this.pnlJournalFilters.Controls.Add(this.txtSearch);

            this.lblStatusFilter.Text = "Status:";
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatusFilter.Location = new System.Drawing.Point(8, 15);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(45, 22);

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbStatus.Location = new System.Drawing.Point(55, 12);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 26);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Draft", "Posted", "Reversed" });
            this.cmbStatus.SelectedIndex = 0;

            this.lblSearchFilter.Text = "Search:";
            this.lblSearchFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSearchFilter.Location = new System.Drawing.Point(185, 15);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(50, 22);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.Location = new System.Drawing.Point(237, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            // pnlBalanceFilters
            this.pnlBalanceFilters.BackColor = System.Drawing.Color.FromArgb(238, 242, 248);
            this.pnlBalanceFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBalanceFilters.Name = "pnlBalanceFilters";
            this.pnlBalanceFilters.Size = new System.Drawing.Size(1020, 50);
            this.pnlBalanceFilters.Visible = false;
            this.pnlBalanceFilters.Controls.Add(this.lblAccountFilter);
            this.pnlBalanceFilters.Controls.Add(this.cmbAccount);

            this.lblAccountFilter.Text = "Account:";
            this.lblAccountFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblAccountFilter.Location = new System.Drawing.Point(8, 15);
            this.lblAccountFilter.Name = "lblAccountFilter";
            this.lblAccountFilter.Size = new System.Drawing.Size(55, 22);

            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbAccount.Location = new System.Drawing.Point(66, 12);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(260, 26);

            // pnlSummary
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Size = new System.Drawing.Size(1020, 80);
            this.pnlSummary.AutoScroll = true;
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Controls.Add(this.lblSumTitle);
            this.pnlSummary.Controls.Add(this.lblLbl1);
            this.pnlSummary.Controls.Add(this.lblVal1);
            this.pnlSummary.Controls.Add(this.lblLbl2);
            this.pnlSummary.Controls.Add(this.lblVal2);
            this.pnlSummary.Controls.Add(this.lblLbl3);
            this.pnlSummary.Controls.Add(this.lblVal3);
            this.pnlSummary.Controls.Add(this.lblLbl4);
            this.pnlSummary.Controls.Add(this.lblVal4);
            this.pnlSummary.Controls.Add(this.lblLbl5);
            this.pnlSummary.Controls.Add(this.lblVal5);
            this.pnlSummary.Controls.Add(this.lblLbl6);
            this.pnlSummary.Controls.Add(this.lblVal6);

            this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblSumTitle.Location = new System.Drawing.Point(10, 8);
            this.lblSumTitle.Name = "lblSumTitle";
            this.lblSumTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSumTitle.Text = "Summary";

            // lblLbl1 / lblVal1
            this.lblLbl1.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLbl1.ForeColor = System.Drawing.Color.Gray;
            this.lblLbl1.Location = new System.Drawing.Point(10, 32);
            this.lblLbl1.Name = "lblLbl1";
            this.lblLbl1.Size = new System.Drawing.Size(150, 18);
            this.lblLbl1.Text = "";

            this.lblVal1.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblVal1.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblVal1.Location = new System.Drawing.Point(10, 50);
            this.lblVal1.Name = "lblVal1";
            this.lblVal1.Size = new System.Drawing.Size(155, 24);
            this.lblVal1.Text = "0";

            // lblLbl2 / lblVal2
            this.lblLbl2.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLbl2.ForeColor = System.Drawing.Color.Gray;
            this.lblLbl2.Location = new System.Drawing.Point(175, 32);
            this.lblLbl2.Name = "lblLbl2";
            this.lblLbl2.Size = new System.Drawing.Size(150, 18);
            this.lblLbl2.Text = "";

            this.lblVal2.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblVal2.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblVal2.Location = new System.Drawing.Point(175, 50);
            this.lblVal2.Name = "lblVal2";
            this.lblVal2.Size = new System.Drawing.Size(155, 24);
            this.lblVal2.Text = "0";

            // lblLbl3 / lblVal3
            this.lblLbl3.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLbl3.ForeColor = System.Drawing.Color.Gray;
            this.lblLbl3.Location = new System.Drawing.Point(340, 32);
            this.lblLbl3.Name = "lblLbl3";
            this.lblLbl3.Size = new System.Drawing.Size(150, 18);
            this.lblLbl3.Text = "";

            this.lblVal3.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblVal3.ForeColor = System.Drawing.Color.FromArgb(180, 120, 0);
            this.lblVal3.Location = new System.Drawing.Point(340, 50);
            this.lblVal3.Name = "lblVal3";
            this.lblVal3.Size = new System.Drawing.Size(155, 24);
            this.lblVal3.Text = "0";

            // lblLbl4 / lblVal4
            this.lblLbl4.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLbl4.ForeColor = System.Drawing.Color.Gray;
            this.lblLbl4.Location = new System.Drawing.Point(505, 32);
            this.lblLbl4.Name = "lblLbl4";
            this.lblLbl4.Size = new System.Drawing.Size(150, 18);
            this.lblLbl4.Text = "";

            this.lblVal4.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblVal4.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblVal4.Location = new System.Drawing.Point(505, 50);
            this.lblVal4.Name = "lblVal4";
            this.lblVal4.Size = new System.Drawing.Size(155, 24);
            this.lblVal4.Text = "0";

            // lblLbl5 / lblVal5
            this.lblLbl5.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLbl5.ForeColor = System.Drawing.Color.Gray;
            this.lblLbl5.Location = new System.Drawing.Point(670, 32);
            this.lblLbl5.Name = "lblLbl5";
            this.lblLbl5.Size = new System.Drawing.Size(150, 18);
            this.lblLbl5.Text = "";

            this.lblVal5.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblVal5.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblVal5.Location = new System.Drawing.Point(670, 50);
            this.lblVal5.Name = "lblVal5";
            this.lblVal5.Size = new System.Drawing.Size(155, 24);
            this.lblVal5.Text = "0";

            // lblLbl6 / lblVal6
            this.lblLbl6.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLbl6.ForeColor = System.Drawing.Color.Gray;
            this.lblLbl6.Location = new System.Drawing.Point(835, 32);
            this.lblLbl6.Name = "lblLbl6";
            this.lblLbl6.Size = new System.Drawing.Size(150, 18);
            this.lblLbl6.Text = "";

            this.lblVal6.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblVal6.ForeColor = System.Drawing.Color.FromArgb(120, 30, 30);
            this.lblVal6.Location = new System.Drawing.Point(835, 50);
            this.lblVal6.Name = "lblVal6";
            this.lblVal6.Size = new System.Drawing.Size(155, 24);
            this.lblVal6.Text = "0";

            // pnlGrid
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Controls.Add(this.dgvReport);

            // dgvReport
            altStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvReport.AlternatingRowsDefaultCellStyle = altStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.ColumnHeadersHeight = 42;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowTemplate.Height = 36;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvReport_CellFormatting);

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlBalanceFilters);
            this.Controls.Add(this.pnlJournalFilters);
            this.Controls.Add(this.pnlReportType);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Name = "FrmFinancialReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Reports";
            this.Load += new System.EventHandler(this.FrmFinancialReports_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlReportType.ResumeLayout(false);
            this.pnlJournalFilters.ResumeLayout(false);
            this.pnlBalanceFilters.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.Panel pnlReportType;
        private System.Windows.Forms.Label lblReportTypeFilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Panel pnlJournalFilters;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.TextBox txtSearch;

        private System.Windows.Forms.Panel pnlBalanceFilters;
        private System.Windows.Forms.Label lblAccountFilter;
        private System.Windows.Forms.ComboBox cmbAccount;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSumTitle;
        private System.Windows.Forms.Label lblLbl1, lblVal1;
        private System.Windows.Forms.Label lblLbl2, lblVal2;
        private System.Windows.Forms.Label lblLbl3, lblVal3;
        private System.Windows.Forms.Label lblLbl4, lblVal4;
        private System.Windows.Forms.Label lblLbl5, lblVal5;
        private System.Windows.Forms.Label lblLbl6, lblVal6;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReport;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}