namespace LibrarySystem.WinForms.Forms.Reports
{
    partial class FrmInventoryReports
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
            this.lblCategoryFilter = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblStockStatusFilter = new System.Windows.Forms.Label();
            this.cmbStockStatus = new System.Windows.Forms.ComboBox();
            this.lblSearchFilter = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();

            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSumTitle = new System.Windows.Forms.Label();

            this.lblTotalProductsLbl = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalStockLbl = new System.Windows.Forms.Label();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblTotalBorrowedLbl = new System.Windows.Forms.Label();
            this.lblTotalBorrowed = new System.Windows.Forms.Label();
            this.lblTotalAvailableLbl = new System.Windows.Forms.Label();
            this.lblTotalAvailable = new System.Windows.Forms.Label();
            this.lblLowStockLbl = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblOutOfStockLbl = new System.Windows.Forms.Label();
            this.lblOutOfStock = new System.Windows.Forms.Label();

            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorrowed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();

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
            this.lblTitle.Text = "Inventory Reports";

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
            this.pnlFilters.Controls.Add(this.lblCategoryFilter);
            this.pnlFilters.Controls.Add(this.cmbCategory);
            this.pnlFilters.Controls.Add(this.lblStockStatusFilter);
            this.pnlFilters.Controls.Add(this.cmbStockStatus);
            this.pnlFilters.Controls.Add(this.lblSearchFilter);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Controls.Add(this.btnSearch);
            this.pnlFilters.Controls.Add(this.btnExport);

            this.lblCategoryFilter.Text = "Category:";
            this.lblCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblCategoryFilter.Location = new System.Drawing.Point(8, 20);
            this.lblCategoryFilter.Name = "lblCategoryFilter";
            this.lblCategoryFilter.Size = new System.Drawing.Size(65, 22);

            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbCategory.Location = new System.Drawing.Point(76, 17);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 26);

            this.lblStockStatusFilter.Text = "Stock Status:";
            this.lblStockStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStockStatusFilter.Location = new System.Drawing.Point(235, 20);
            this.lblStockStatusFilter.Name = "lblStockStatusFilter";
            this.lblStockStatusFilter.Size = new System.Drawing.Size(85, 22);

            this.cmbStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbStockStatus.Location = new System.Drawing.Point(323, 17);
            this.cmbStockStatus.Name = "cmbStockStatus";
            this.cmbStockStatus.Size = new System.Drawing.Size(120, 26);
            this.cmbStockStatus.Items.AddRange(new object[] { "All", "Available", "Low Stock", "Out of Stock" });
            this.cmbStockStatus.SelectedIndex = 0;

            this.lblSearchFilter.Text = "Search:";
            this.lblSearchFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSearchFilter.Location = new System.Drawing.Point(455, 20);
            this.lblSearchFilter.Name = "lblSearchFilter";
            this.lblSearchFilter.Size = new System.Drawing.Size(48, 22);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.Location = new System.Drawing.Point(505, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 26);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);

            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(676, 15);
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
            this.btnExport.Location = new System.Drawing.Point(769, 15);
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
            this.pnlSummary.Controls.Add(this.lblTotalProductsLbl);
            this.pnlSummary.Controls.Add(this.lblTotalProducts);
            this.pnlSummary.Controls.Add(this.lblTotalStockLbl);
            this.pnlSummary.Controls.Add(this.lblTotalStock);
            this.pnlSummary.Controls.Add(this.lblTotalBorrowedLbl);
            this.pnlSummary.Controls.Add(this.lblTotalBorrowed);
            this.pnlSummary.Controls.Add(this.lblTotalAvailableLbl);
            this.pnlSummary.Controls.Add(this.lblTotalAvailable);
            this.pnlSummary.Controls.Add(this.lblLowStockLbl);
            this.pnlSummary.Controls.Add(this.lblLowStock);
            this.pnlSummary.Controls.Add(this.lblOutOfStockLbl);
            this.pnlSummary.Controls.Add(this.lblOutOfStock);

            this.lblSumTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSumTitle.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblSumTitle.Location = new System.Drawing.Point(10, 8);
            this.lblSumTitle.Name = "lblSumTitle";
            this.lblSumTitle.Size = new System.Drawing.Size(100, 20);
            this.lblSumTitle.Text = "Summary";

            this.lblTotalProductsLbl.Text = "Total Products";
            this.lblTotalProductsLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalProductsLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalProductsLbl.Location = new System.Drawing.Point(10, 32);
            this.lblTotalProductsLbl.Name = "lblTotalProductsLbl";
            this.lblTotalProductsLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.lblTotalProducts.Location = new System.Drawing.Point(10, 50);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(140, 24);
            this.lblTotalProducts.Text = "0";

            this.lblTotalStockLbl.Text = "Total In Stock";
            this.lblTotalStockLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalStockLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalStockLbl.Location = new System.Drawing.Point(160, 32);
            this.lblTotalStockLbl.Name = "lblTotalStockLbl";
            this.lblTotalStockLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalStock.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalStock.ForeColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.lblTotalStock.Location = new System.Drawing.Point(160, 50);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(140, 24);
            this.lblTotalStock.Text = "0";

            this.lblTotalBorrowedLbl.Text = "Total Borrowed";
            this.lblTotalBorrowedLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalBorrowedLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalBorrowedLbl.Location = new System.Drawing.Point(310, 32);
            this.lblTotalBorrowedLbl.Name = "lblTotalBorrowedLbl";
            this.lblTotalBorrowedLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalBorrowed.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalBorrowed.ForeColor = System.Drawing.Color.FromArgb(180, 120, 0);
            this.lblTotalBorrowed.Location = new System.Drawing.Point(310, 50);
            this.lblTotalBorrowed.Name = "lblTotalBorrowed";
            this.lblTotalBorrowed.Size = new System.Drawing.Size(140, 24);
            this.lblTotalBorrowed.Text = "0";

            this.lblTotalAvailableLbl.Text = "Total Available";
            this.lblTotalAvailableLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblTotalAvailableLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalAvailableLbl.Location = new System.Drawing.Point(460, 32);
            this.lblTotalAvailableLbl.Name = "lblTotalAvailableLbl";
            this.lblTotalAvailableLbl.Size = new System.Drawing.Size(120, 18);

            this.lblTotalAvailable.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblTotalAvailable.ForeColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.lblTotalAvailable.Location = new System.Drawing.Point(460, 50);
            this.lblTotalAvailable.Name = "lblTotalAvailable";
            this.lblTotalAvailable.Size = new System.Drawing.Size(140, 24);
            this.lblTotalAvailable.Text = "0";

            this.lblLowStockLbl.Text = "Low Stock Items";
            this.lblLowStockLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblLowStockLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblLowStockLbl.Location = new System.Drawing.Point(610, 32);
            this.lblLowStockLbl.Name = "lblLowStockLbl";
            this.lblLowStockLbl.Size = new System.Drawing.Size(110, 18);

            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblLowStock.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.lblLowStock.Location = new System.Drawing.Point(610, 50);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(100, 24);
            this.lblLowStock.Text = "0";

            this.lblOutOfStockLbl.Text = "Out of Stock";
            this.lblOutOfStockLbl.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            this.lblOutOfStockLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblOutOfStockLbl.Location = new System.Drawing.Point(720, 32);
            this.lblOutOfStockLbl.Name = "lblOutOfStockLbl";
            this.lblOutOfStockLbl.Size = new System.Drawing.Size(100, 18);

            this.lblOutOfStock.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Bold);
            this.lblOutOfStock.ForeColor = System.Drawing.Color.FromArgb(120, 30, 30);
            this.lblOutOfStock.Location = new System.Drawing.Point(720, 50);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Size = new System.Drawing.Size(100, 24);
            this.lblOutOfStock.Text = "0";

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
            this.colProductID.HeaderText = "ProductID"; this.colProductID.Name = "colProductID"; this.colProductID.Visible = false;
            this.colProduct.HeaderText = "Product"; this.colProduct.Name = "colProduct"; this.colProduct.FillWeight = 22f;
            this.colCategory.HeaderText = "Category"; this.colCategory.Name = "colCategory"; this.colCategory.FillWeight = 14f;
            this.colInStock.HeaderText = "In Stock"; this.colInStock.Name = "colInStock"; this.colInStock.FillWeight = 10f;
            this.colBorrowed.HeaderText = "Borrowed"; this.colBorrowed.Name = "colBorrowed"; this.colBorrowed.FillWeight = 10f;
            this.colAvailable.HeaderText = "Available"; this.colAvailable.Name = "colAvailable"; this.colAvailable.FillWeight = 10f;
            this.colMinLevel.HeaderText = "Min Level"; this.colMinLevel.Name = "colMinLevel"; this.colMinLevel.FillWeight = 10f;
            this.colStockStatus.HeaderText = "Status"; this.colStockStatus.Name = "colStockStatus"; this.colStockStatus.FillWeight = 10f;
            this.colLastUpdated.HeaderText = "Last Updated"; this.colLastUpdated.Name = "colLastUpdated"; this.colLastUpdated.FillWeight = 14f;

            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colProductID, this.colProduct, this.colCategory,
                this.colInStock, this.colBorrowed, this.colAvailable, this.colMinLevel,
                this.colStockStatus, this.colLastUpdated
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
            this.Name = "FrmInventoryReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Reports";
            this.Load += new System.EventHandler(this.FrmInventoryReports_Load);

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
        private System.Windows.Forms.Label lblCategoryFilter;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblStockStatusFilter;
        private System.Windows.Forms.ComboBox cmbStockStatus;
        private System.Windows.Forms.Label lblSearchFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSumTitle;
        private System.Windows.Forms.Label lblTotalProductsLbl, lblTotalProducts;
        private System.Windows.Forms.Label lblTotalStockLbl, lblTotalStock;
        private System.Windows.Forms.Label lblTotalBorrowedLbl, lblTotalBorrowed;
        private System.Windows.Forms.Label lblTotalAvailableLbl, lblTotalAvailable;
        private System.Windows.Forms.Label lblLowStockLbl, lblLowStock;
        private System.Windows.Forms.Label lblOutOfStockLbl, lblOutOfStock;

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorrowed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastUpdated;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}