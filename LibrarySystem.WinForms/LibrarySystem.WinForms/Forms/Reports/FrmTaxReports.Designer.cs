namespace LibrarySystem.WinForms.Forms.Reports
{
    partial class FrmTaxReports
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

            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblReportTypeLbl = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblStatusLbl = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTaxTypeLbl = new System.Windows.Forms.Label();
            this.cmbTaxType = new System.Windows.Forms.ComboBox();
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

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(1130, 55);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblStatus);
            this.pnlTop.Controls.Add(this.lblCount);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.Text = "Tax Reports";

            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblStatus.Location = new System.Drawing.Point(250, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 22);
            this.lblStatus.Text = "";

            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblCount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblCount.Location = new System.Drawing.Point(1010, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 22);
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCount.Text = "Records: 0";

            // pnlFilters
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Size = new System.Drawing.Size(1130, 60);
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Controls.Add(this.lblFrom);
            this.pnlFilters.Controls.Add(this.dtpFrom);
            this.pnlFilters.Controls.Add(this.lblTo);
            this.pnlFilters.Controls.Add(this.dtpTo);
            this.pnlFilters.Controls.Add(this.lblReportTypeLbl);
            this.pnlFilters.Controls.Add(this.cmbReportType);
            this.pnlFilters.Controls.Add(this.lblStatusLbl);
            this.pnlFilters.Controls.Add(this.cmbStatus);
            this.pnlFilters.Controls.Add(this.lblTaxTypeLbl);
            this.pnlFilters.Controls.Add(this.cmbTaxType);
            this.pnlFilters.Controls.Add(this.lblSearchLbl);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.btnSearch);
            this.pnlFilters.Controls.Add(this.btnExport);

            this.lblFrom.Text = "From:";
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(8, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(38, 22);

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpFrom.Location = new System.Drawing.Point(48, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(95, 26);

            this.lblTo.Text = "To:";
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(150, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 22);

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpTo.Location = new System.Drawing.Point(172, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(95, 26);

            this.lblReportTypeLbl.Text = "Report:";
            this.lblReportTypeLbl.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblReportTypeLbl.Location = new System.Drawing.Point(275, 20);
            this.lblReportTypeLbl.Name = "lblReportTypeLbl";
            this.lblReportTypeLbl.Size = new System.Drawing.Size(48, 22);

            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbReportType.Location = new System.Drawing.Point(323, 17);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(110, 26);
            this.cmbReportType.Items.AddRange(new object[] { "Declarations", "Invoice Taxes" });
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.CmbReportType_SelectedIndexChanged);

            this.lblStatusLbl.Text = "Status:";
            this.lblStatusLbl.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatusLbl.Location = new System.Drawing.Point(441, 20);
            this.lblStatusLbl.Name = "lblStatusLbl";
            this.lblStatusLbl.Size = new System.Drawing.Size(45, 22);

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbStatus.Location = new System.Drawing.Point(488, 17);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(90, 26);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Draft", "Submitted", "Paid" });

            this.lblTaxTypeLbl.Text = "Tax Type:";
            this.lblTaxTypeLbl.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblTaxTypeLbl.Location = new System.Drawing.Point(586, 20);
            this.lblTaxTypeLbl.Name = "lblTaxTypeLbl";
            this.lblTaxTypeLbl.Size = new System.Drawing.Size(60, 22);

            this.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbTaxType.Location = new System.Drawing.Point(648, 17);
            this.cmbTaxType.Name = "cmbTaxType";
            this.cmbTaxType.Size = new System.Drawing.Size(120, 26);

            this.lblSearchLbl.Text = "Search:";
            this.lblSearchLbl.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSearchLbl.Location = new System.Drawing.Point(776, 20);
            this.lblSearchLbl.Name = "lblSearchLbl";
            this.lblSearchLbl.Size = new System.Drawing.Size(48, 22);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.Location = new System.Drawing.Point(826, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(115, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(949, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(62, 30);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            this.btnExport.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1020, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 30);
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            // pnlSummary
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Size = new System.Drawing.Size(1130, 80);
            this.pnlSummary.AutoScroll = true;
            this.pnlSummary.Name = "pnlSummary";
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

            this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblSumTitle.Location = new System.Drawing.Point(10, 8);
            this.lblSumTitle.Name = "lblSumTitle";
            this.lblSumTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSumTitle.Text = "Summary";

            int[] xPos = new int[] { 10, 175, 340, 505, 670, 835 };

            this.lblStat1Lbl.Text = "Sales Tax";
            this.lblStat1Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStat1Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat1Lbl.Location = new System.Drawing.Point(xPos[0], 32);
            this.lblStat1Lbl.Name = "lblStat1Lbl";
            this.lblStat1Lbl.Size = new System.Drawing.Size(140, 18);

            this.lblStat1.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblStat1.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblStat1.Location = new System.Drawing.Point(xPos[0], 50);
            this.lblStat1.Name = "lblStat1";
            this.lblStat1.Size = new System.Drawing.Size(140, 24);
            this.lblStat1.Text = "0.00";

            this.lblStat2Lbl.Text = "Purchase Tax";
            this.lblStat2Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStat2Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat2Lbl.Location = new System.Drawing.Point(xPos[1], 32);
            this.lblStat2Lbl.Name = "lblStat2Lbl";
            this.lblStat2Lbl.Size = new System.Drawing.Size(140, 18);

            this.lblStat2.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblStat2.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblStat2.Location = new System.Drawing.Point(xPos[1], 50);
            this.lblStat2.Name = "lblStat2";
            this.lblStat2.Size = new System.Drawing.Size(140, 24);
            this.lblStat2.Text = "0.00";

            this.lblStat3Lbl.Text = "Net Due";
            this.lblStat3Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStat3Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat3Lbl.Location = new System.Drawing.Point(xPos[2], 32);
            this.lblStat3Lbl.Name = "lblStat3Lbl";
            this.lblStat3Lbl.Size = new System.Drawing.Size(140, 18);

            this.lblStat3.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblStat3.ForeColor = System.Drawing.Color.FromArgb(200, 80, 0);
            this.lblStat3.Location = new System.Drawing.Point(xPos[2], 50);
            this.lblStat3.Name = "lblStat3";
            this.lblStat3.Size = new System.Drawing.Size(140, 24);
            this.lblStat3.Text = "0.00";

            this.lblStat4Lbl.Text = "Paid";
            this.lblStat4Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStat4Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat4Lbl.Location = new System.Drawing.Point(xPos[3], 32);
            this.lblStat4Lbl.Name = "lblStat4Lbl";
            this.lblStat4Lbl.Size = new System.Drawing.Size(140, 18);

            this.lblStat4.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblStat4.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblStat4.Location = new System.Drawing.Point(xPos[3], 50);
            this.lblStat4.Name = "lblStat4";
            this.lblStat4.Size = new System.Drawing.Size(140, 24);
            this.lblStat4.Text = "0.00";

            this.lblStat5Lbl.Text = "Remaining";
            this.lblStat5Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStat5Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat5Lbl.Location = new System.Drawing.Point(xPos[4], 32);
            this.lblStat5Lbl.Name = "lblStat5Lbl";
            this.lblStat5Lbl.Size = new System.Drawing.Size(140, 18);

            this.lblStat5.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblStat5.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblStat5.Location = new System.Drawing.Point(xPos[4], 50);
            this.lblStat5.Name = "lblStat5";
            this.lblStat5.Size = new System.Drawing.Size(140, 24);
            this.lblStat5.Text = "0.00";

            this.lblStat6Lbl.Text = "Paid Declarations";
            this.lblStat6Lbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblStat6Lbl.ForeColor = System.Drawing.Color.Gray;
            this.lblStat6Lbl.Location = new System.Drawing.Point(xPos[5], 32);
            this.lblStat6Lbl.Name = "lblStat6Lbl";
            this.lblStat6Lbl.Size = new System.Drawing.Size(140, 18);

            this.lblStat6.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblStat6.ForeColor = System.Drawing.Color.FromArgb(180, 120, 0);
            this.lblStat6.Location = new System.Drawing.Point(xPos[5], 50);
            this.lblStat6.Name = "lblStat6";
            this.lblStat6.Size = new System.Drawing.Size(140, 24);
            this.lblStat6.Text = "0";

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
            this.ClientSize = new System.Drawing.Size(1130, 700);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Name = "FrmTaxReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax Reports";
            this.Load += new System.EventHandler(this.FrmTaxReports_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblTaxTypeLbl;
        private System.Windows.Forms.ComboBox cmbTaxType;
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