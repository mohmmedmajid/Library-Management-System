namespace LibrarySystem.WinForms.Forms.Reports
{
    partial class FrmHRReports
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblReportTypeLbl = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblStatusLbl = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDeptLbl = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblSearchLbl = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSumTitle = new System.Windows.Forms.Label();
            this.lblStat1Lbl = new System.Windows.Forms.Label();
            this.lblStat1 = new System.Windows.Forms.Label();
            this.lblStat2Lbl = new System.Windows.Forms.Label();
            this.lblStat2 = new System.Windows.Forms.Label();
            this.lblStat3Lbl = new System.Windows.Forms.Label();
            this.lblStat3 = new System.Windows.Forms.Label();
            this.lblStat4Lbl = new System.Windows.Forms.Label();
            this.lblStat4 = new System.Windows.Forms.Label();
            this.lblStat5Lbl = new System.Windows.Forms.Label();
            this.lblStat5 = new System.Windows.Forms.Label();
            this.lblStat6Lbl = new System.Windows.Forms.Label();
            this.lblStat6 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1150, 55);
            this.pnlTop.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HR Reports";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lblStatus.Location = new System.Drawing.Point(310, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 22);
            this.lblStatus.TabIndex = 1;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lblCount.Location = new System.Drawing.Point(1020, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(110, 22);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Records: 0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Controls.Add(this.dtpFrom);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpTo);
            this.pnlFilters.Controls.Add(this.lblReportTypeLbl);
            this.pnlFilters.Controls.Add(this.cmbReportType);
            this.pnlFilters.Controls.Add(this.lblStatusLbl);
            this.pnlFilters.Controls.Add(this.cmbStatus);
            this.pnlFilters.Controls.Add(this.lblDeptLbl);
            this.pnlFilters.Controls.Add(this.cmbDepartment);
            this.pnlFilters.Controls.Add(this.lblSearchLbl);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.btnSearch);
            this.pnlFilters.Controls.Add(this.btnExport);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 55);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(1150, 60);
            this.pnlFilters.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(8, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 22);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(48, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 24);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(150, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 22);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(172, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 24);
            this.dtpTo.TabIndex = 3;
            // 
            // lblReportTypeLbl
            // 
            this.lblReportTypeLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblReportTypeLbl.Location = new System.Drawing.Point(275, 20);
            this.lblReportTypeLbl.Name = "lblReportTypeLbl";
            this.lblReportTypeLbl.Size = new System.Drawing.Size(50, 22);
            this.lblReportTypeLbl.TabIndex = 4;
            this.lblReportTypeLbl.Text = "Report:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbReportType.Items.AddRange(new object[] {
            "Employees",
            "Payroll",
            "Advances",
            "Bonuses"});
            this.cmbReportType.Location = new System.Drawing.Point(327, 17);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(105, 25);
            this.cmbReportType.TabIndex = 5;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.CmbReportType_SelectedIndexChanged);
            // 
            // lblStatusLbl
            // 
            this.lblStatusLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusLbl.Location = new System.Drawing.Point(440, 20);
            this.lblStatusLbl.Name = "lblStatusLbl";
            this.lblStatusLbl.Size = new System.Drawing.Size(45, 22);
            this.lblStatusLbl.TabIndex = 6;
            this.lblStatusLbl.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Active",
            "Inactive",
            "Terminated"});
            this.cmbStatus.Location = new System.Drawing.Point(487, 17);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 25);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblDeptLbl
            // 
            this.lblDeptLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDeptLbl.Location = new System.Drawing.Point(600, 20);
            this.lblDeptLbl.Name = "lblDeptLbl";
            this.lblDeptLbl.Size = new System.Drawing.Size(38, 22);
            this.lblDeptLbl.TabIndex = 8;
            this.lblDeptLbl.Text = "Dept:";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbDepartment.Location = new System.Drawing.Point(640, 17);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(110, 25);
            this.cmbDepartment.TabIndex = 9;
            // 
            // lblSearchLbl
            // 
            this.lblSearchLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchLbl.Location = new System.Drawing.Point(767, 20);
            this.lblSearchLbl.Name = "lblSearchLbl";
            this.lblSearchLbl.Size = new System.Drawing.Size(55, 22);
            this.lblSearchLbl.TabIndex = 10;
            this.lblSearchLbl.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(825, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 24);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(982, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(100)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1062, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 30);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // pnlSummary
            // 
            this.pnlSummary.AutoScroll = true;
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlSummary.Controls.Add(this.lblSumTitle);
            this.pnlSummary.Controls.Add(this.lblStat1Lbl);
            this.pnlSummary.Controls.Add(this.lblStat1);
            this.pnlSummary.Controls.Add(this.lblStat2Lbl);
            this.pnlSummary.Controls.Add(this.lblStat2);
            this.pnlSummary.Controls.Add(this.lblStat3Lbl);
            this.pnlSummary.Controls.Add(this.lblStat3);
            this.pnlSummary.Controls.Add(this.lblStat4Lbl);
            this.pnlSummary.Controls.Add(this.lblStat4);
            this.pnlSummary.Controls.Add(this.lblStat5Lbl);
            this.pnlSummary.Controls.Add(this.lblStat5);
            this.pnlSummary.Controls.Add(this.lblStat6Lbl);
            this.pnlSummary.Controls.Add(this.lblStat6);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 115);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1150, 80);
            this.pnlSummary.TabIndex = 1;
            // 
            // lblSumTitle
            // 
            this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblSumTitle.Location = new System.Drawing.Point(10, 8);
            this.lblSumTitle.Name = "lblSumTitle";
            this.lblSumTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSumTitle.TabIndex = 0;
            this.lblSumTitle.Text = "Summary";
            // 
            // lblStat1Lbl
            // 
            this.lblStat1Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStat1Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat1Lbl.Location = new System.Drawing.Point(10, 32);
            this.lblStat1Lbl.Name = "lblStat1Lbl";
            this.lblStat1Lbl.Size = new System.Drawing.Size(175, 18);
            this.lblStat1Lbl.TabIndex = 1;
            this.lblStat1Lbl.Text = "Total Employees";
            // 
            // lblStat1
            // 
            this.lblStat1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.lblStat1.Location = new System.Drawing.Point(10, 50);
            this.lblStat1.Name = "lblStat1";
            this.lblStat1.Size = new System.Drawing.Size(175, 24);
            this.lblStat1.TabIndex = 2;
            this.lblStat1.Text = "0";
            // 
            // lblStat2Lbl
            // 
            this.lblStat2Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStat2Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat2Lbl.Location = new System.Drawing.Point(195, 32);
            this.lblStat2Lbl.Name = "lblStat2Lbl";
            this.lblStat2Lbl.Size = new System.Drawing.Size(175, 18);
            this.lblStat2Lbl.TabIndex = 3;
            this.lblStat2Lbl.Text = "Active";
            // 
            // lblStat2
            // 
            this.lblStat2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStat2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(160)))), ((int)(((byte)(100)))));
            this.lblStat2.Location = new System.Drawing.Point(195, 50);
            this.lblStat2.Name = "lblStat2";
            this.lblStat2.Size = new System.Drawing.Size(175, 24);
            this.lblStat2.TabIndex = 4;
            this.lblStat2.Text = "0";
            // 
            // lblStat3Lbl
            // 
            this.lblStat3Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStat3Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat3Lbl.Location = new System.Drawing.Point(380, 32);
            this.lblStat3Lbl.Name = "lblStat3Lbl";
            this.lblStat3Lbl.Size = new System.Drawing.Size(175, 18);
            this.lblStat3Lbl.TabIndex = 5;
            this.lblStat3Lbl.Text = "Inactive";
            // 
            // lblStat3
            // 
            this.lblStat3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStat3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblStat3.Location = new System.Drawing.Point(380, 50);
            this.lblStat3.Name = "lblStat3";
            this.lblStat3.Size = new System.Drawing.Size(175, 24);
            this.lblStat3.TabIndex = 6;
            this.lblStat3.Text = "0";
            // 
            // lblStat4Lbl
            // 
            this.lblStat4Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStat4Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat4Lbl.Location = new System.Drawing.Point(565, 32);
            this.lblStat4Lbl.Name = "lblStat4Lbl";
            this.lblStat4Lbl.Size = new System.Drawing.Size(175, 18);
            this.lblStat4Lbl.TabIndex = 7;
            this.lblStat4Lbl.Text = "Total Salaries";
            // 
            // lblStat4
            // 
            this.lblStat4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStat4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblStat4.Location = new System.Drawing.Point(565, 50);
            this.lblStat4.Name = "lblStat4";
            this.lblStat4.Size = new System.Drawing.Size(175, 24);
            this.lblStat4.TabIndex = 8;
            this.lblStat4.Text = "0.00";
            // 
            // lblStat5Lbl
            // 
            this.lblStat5Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStat5Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat5Lbl.Location = new System.Drawing.Point(750, 32);
            this.lblStat5Lbl.Name = "lblStat5Lbl";
            this.lblStat5Lbl.Size = new System.Drawing.Size(175, 18);
            this.lblStat5Lbl.TabIndex = 9;
            this.lblStat5Lbl.Text = "Departments";
            // 
            // lblStat5
            // 
            this.lblStat5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStat5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.lblStat5.Location = new System.Drawing.Point(750, 50);
            this.lblStat5.Name = "lblStat5";
            this.lblStat5.Size = new System.Drawing.Size(175, 24);
            this.lblStat5.TabIndex = 10;
            this.lblStat5.Text = "0";
            // 
            // lblStat6Lbl
            // 
            this.lblStat6Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStat6Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat6Lbl.Location = new System.Drawing.Point(935, 32);
            this.lblStat6Lbl.Name = "lblStat6Lbl";
            this.lblStat6Lbl.Size = new System.Drawing.Size(175, 18);
            this.lblStat6Lbl.TabIndex = 11;
            this.lblStat6Lbl.Text = "Avg Salary";
            // 
            // lblStat6
            // 
            this.lblStat6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStat6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            this.lblStat6.Location = new System.Drawing.Point(935, 50);
            this.lblStat6.Name = "lblStat6";
            this.lblStat6.Size = new System.Drawing.Size(175, 24);
            this.lblStat6.TabIndex = 12;
            this.lblStat6.Text = "0.00";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvReport);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 195);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(1150, 505);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(32)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReport.ColumnHeadersHeight = 42;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvReport.Location = new System.Drawing.Point(10, 10);
            this.dgvReport.MultiSelect = false;
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.RowTemplate.Height = 36;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.Size = new System.Drawing.Size(1130, 485);
            this.dgvReport.TabIndex = 0;
            this.dgvReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvReport_CellFormatting);
            // 
            // FrmHRReports
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1150, 700);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmHRReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Reports";
            this.Load += new System.EventHandler(this.FrmHRReports_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCount;

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblReportTypeLbl;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblStatusLbl;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDeptLbl;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblSearchLbl;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSumTitle;
        private System.Windows.Forms.Label lblStat1Lbl, lblStat1;
        private System.Windows.Forms.Label lblStat2Lbl, lblStat2;
        private System.Windows.Forms.Label lblStat3Lbl, lblStat3;
        private System.Windows.Forms.Label lblStat4Lbl, lblStat4;
        private System.Windows.Forms.Label lblStat5Lbl, lblStat5;
        private System.Windows.Forms.Label lblStat6Lbl, lblStat6;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReport;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}