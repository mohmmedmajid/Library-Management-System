namespace LibrarySystem.WinForms.Forms.Reports
{
    partial class FrmCustomerReports
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
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDebtFilter = new System.Windows.Forms.Label();
            this.cmbDebtFilter = new System.Windows.Forms.ComboBox();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSumTitle = new System.Windows.Forms.Label();
            this.lblTotalCustomersLbl = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblTotalPurchasesLbl = new System.Windows.Forms.Label();
            this.lblTotalPurchases = new System.Windows.Forms.Label();
            this.lblTotalBorrowingsLbl = new System.Windows.Forms.Label();
            this.lblTotalBorrowings = new System.Windows.Forms.Label();
            this.lblTotalDebtLbl = new System.Windows.Forms.Label();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblTotalLateFeesLbl = new System.Windows.Forms.Label();
            this.lblTotalLateFees = new System.Windows.Forms.Label();
            this.lblWithDebtLbl = new System.Windows.Forms.Label();
            this.lblWithDebt = new System.Windows.Forms.Label();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalPurchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalBorrowings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDebt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLateFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlFilters.SuspendLayout();
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
            this.lblTitle.Text = "Customer Reports";

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

            // pnlFilters
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Size = new System.Drawing.Size(1020, 60);
            this.pnlFilters.AutoScroll = true;
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Controls.Add(this.lblStatusFilter);
            this.pnlFilters.Controls.Add(this.cmbStatus);
            this.pnlFilters.Controls.Add(this.lblDebtFilter);
            this.pnlFilters.Controls.Add(this.cmbDebtFilter);
            this.pnlFilters.Controls.Add(this.lblSearchFilter);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.btnSearch);
            this.pnlFilters.Controls.Add(this.btnExport);

            this.lblStatusFilter.Text = "Status:";
            this.lblStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatusFilter.Location = new System.Drawing.Point(8, 20);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(45, 22);

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbStatus.Location = new System.Drawing.Point(55, 17);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(110, 26);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            this.cmbStatus.SelectedIndex = 0;

            this.lblDebtFilter.Text = "Debt:";
            this.lblDebtFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblDebtFilter.Location = new System.Drawing.Point(175, 20);
            this.lblDebtFilter.Name = "lblDebtFilter";
            this.lblDebtFilter.Size = new System.Drawing.Size(38, 22);

            this.cmbDebtFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDebtFilter.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbDebtFilter.Location = new System.Drawing.Point(215, 17);
            this.cmbDebtFilter.Name = "cmbDebtFilter";
            this.cmbDebtFilter.Size = new System.Drawing.Size(110, 26);
            this.cmbDebtFilter.Items.AddRange(new object[] { "All", "With Debt", "No Debt" });
            this.cmbDebtFilter.SelectedIndex = 0;

            this.lblSearchFilter.Text = "Search:";
            this.lblSearchFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSearchFilter.Location = new System.Drawing.Point(335, 20);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(48, 22);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.Location = new System.Drawing.Point(385, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

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

            // pnlSummary
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(240, 246, 255);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Size = new System.Drawing.Size(1020, 80);
            this.pnlSummary.AutoScroll = true;
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Controls.Add(this.lblSumTitle);
            this.pnlSummary.Controls.Add(this.lblTotalCustomersLbl);
            this.pnlSummary.Controls.Add(this.lblTotalCustomers);
            this.pnlSummary.Controls.Add(this.lblTotalPurchasesLbl);
            this.pnlSummary.Controls.Add(this.lblTotalPurchases);
            this.pnlSummary.Controls.Add(this.lblTotalBorrowingsLbl);
            this.pnlSummary.Controls.Add(this.lblTotalBorrowings);
            this.pnlSummary.Controls.Add(this.lblTotalDebtLbl);
            this.pnlSummary.Controls.Add(this.lblTotalDebt);
            this.pnlSummary.Controls.Add(this.lblTotalLateFeesLbl);
            this.pnlSummary.Controls.Add(this.lblTotalLateFees);
            this.pnlSummary.Controls.Add(this.lblWithDebtLbl);
            this.pnlSummary.Controls.Add(this.lblWithDebt);

            this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblSumTitle.Location = new System.Drawing.Point(10, 8);
            this.lblSumTitle.Name = "lblSumTitle";
            this.lblSumTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSumTitle.Text = "Summary";

            this.lblTotalCustomersLbl.Text = "Total Customers";
            this.lblTotalCustomersLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalCustomersLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalCustomersLbl.Location = new System.Drawing.Point(10, 32);
            this.lblTotalCustomersLbl.Name = "lblTotalCustomersLbl";
            this.lblTotalCustomersLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblTotalCustomers.Location = new System.Drawing.Point(10, 50);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(140, 24);
            this.lblTotalCustomers.Text = "0";

            this.lblTotalPurchasesLbl.Text = "Total Purchases";
            this.lblTotalPurchasesLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalPurchasesLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalPurchasesLbl.Location = new System.Drawing.Point(160, 32);
            this.lblTotalPurchasesLbl.Name = "lblTotalPurchasesLbl";
            this.lblTotalPurchasesLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalPurchases.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalPurchases.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblTotalPurchases.Location = new System.Drawing.Point(160, 50);
            this.lblTotalPurchases.Name = "lblTotalPurchases";
            this.lblTotalPurchases.Size = new System.Drawing.Size(140, 24);
            this.lblTotalPurchases.Text = "0.00";

            this.lblTotalBorrowingsLbl.Text = "Total Borrowings";
            this.lblTotalBorrowingsLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalBorrowingsLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalBorrowingsLbl.Location = new System.Drawing.Point(310, 32);
            this.lblTotalBorrowingsLbl.Name = "lblTotalBorrowingsLbl";
            this.lblTotalBorrowingsLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalBorrowings.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalBorrowings.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblTotalBorrowings.Location = new System.Drawing.Point(310, 50);
            this.lblTotalBorrowings.Name = "lblTotalBorrowings";
            this.lblTotalBorrowings.Size = new System.Drawing.Size(140, 24);
            this.lblTotalBorrowings.Text = "0";

            this.lblTotalDebtLbl.Text = "Total Debt";
            this.lblTotalDebtLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalDebtLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalDebtLbl.Location = new System.Drawing.Point(460, 32);
            this.lblTotalDebtLbl.Name = "lblTotalDebtLbl";
            this.lblTotalDebtLbl.Size = new System.Drawing.Size(100, 18);

            this.lblTotalDebt.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalDebt.ForeColor = System.Drawing.Color.FromArgb(200, 80, 0);
            this.lblTotalDebt.Location = new System.Drawing.Point(460, 50);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(130, 24);
            this.lblTotalDebt.Text = "0.00";

            this.lblTotalLateFeesLbl.Text = "Late Fees";
            this.lblTotalLateFeesLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalLateFeesLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalLateFeesLbl.Location = new System.Drawing.Point(600, 32);
            this.lblTotalLateFeesLbl.Name = "lblTotalLateFeesLbl";
            this.lblTotalLateFeesLbl.Size = new System.Drawing.Size(80, 18);

            this.lblTotalLateFees.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalLateFees.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblTotalLateFees.Location = new System.Drawing.Point(600, 50);
            this.lblTotalLateFees.Name = "lblTotalLateFees";
            this.lblTotalLateFees.Size = new System.Drawing.Size(120, 24);
            this.lblTotalLateFees.Text = "0.00";

            this.lblWithDebtLbl.Text = "Customers w/ Debt";
            this.lblWithDebtLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblWithDebtLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblWithDebtLbl.Location = new System.Drawing.Point(730, 32);
            this.lblWithDebtLbl.Name = "lblWithDebtLbl";
            this.lblWithDebtLbl.Size = new System.Drawing.Size(130, 18);

            this.lblWithDebt.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblWithDebt.ForeColor = System.Drawing.Color.FromArgb(120, 30, 30);
            this.lblWithDebt.Location = new System.Drawing.Point(730, 50);
            this.lblWithDebt.Name = "lblWithDebt";
            this.lblWithDebt.Size = new System.Drawing.Size(70, 24);
            this.lblWithDebt.Text = "0";

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

            this.colID.HeaderText = "ID"; this.colID.Name = "colID"; this.colID.Visible = false;
            this.colCustomerName.HeaderText = "Customer"; this.colCustomerName.Name = "colCustomerName"; this.colCustomerName.FillWeight = 18f;
            this.colPhone.HeaderText = "Phone"; this.colPhone.Name = "colPhone"; this.colPhone.FillWeight = 11f;
            this.colEmail.HeaderText = "Email"; this.colEmail.Name = "colEmail"; this.colEmail.FillWeight = 16f;
            this.colTotalPurchases.HeaderText = "Total Purchases"; this.colTotalPurchases.Name = "colTotalPurchases"; this.colTotalPurchases.FillWeight = 12f;
            this.colTotalBorrowings.HeaderText = "Borrowings"; this.colTotalBorrowings.Name = "colTotalBorrowings"; this.colTotalBorrowings.FillWeight = 9f;
            this.colTotalDebt.HeaderText = "Total Debt"; this.colTotalDebt.Name = "colTotalDebt"; this.colTotalDebt.FillWeight = 10f;
            this.colLateFees.HeaderText = "Late Fees"; this.colLateFees.Name = "colLateFees"; this.colLateFees.FillWeight = 10f;
            this.colStatus.HeaderText = "Status"; this.colStatus.Name = "colStatus"; this.colStatus.FillWeight = 8f;
            this.colCreatedDate.HeaderText = "Created Date"; this.colCreatedDate.Name = "colCreatedDate"; this.colCreatedDate.FillWeight = 11f;

            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colCustomerName, this.colPhone, this.colEmail,
                this.colTotalPurchases, this.colTotalBorrowings, this.colTotalDebt,
                this.colLateFees, this.colStatus, this.colCreatedDate
            });

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Name = "FrmCustomerReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Reports";
            this.Load += new System.EventHandler(this.FrmCustomerReports_Load);

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
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDebtFilter;
        private System.Windows.Forms.ComboBox cmbDebtFilter;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSumTitle;
        private System.Windows.Forms.Label lblTotalCustomersLbl, lblTotalCustomers;
        private System.Windows.Forms.Label lblTotalPurchasesLbl, lblTotalPurchases;
        private System.Windows.Forms.Label lblTotalBorrowingsLbl, lblTotalBorrowings;
        private System.Windows.Forms.Label lblTotalDebtLbl, lblTotalDebt;
        private System.Windows.Forms.Label lblTotalLateFeesLbl, lblTotalLateFees;
        private System.Windows.Forms.Label lblWithDebtLbl, lblWithDebt;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalPurchases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalBorrowings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDebt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLateFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}