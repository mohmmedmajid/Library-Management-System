using LibrarySystem.WinForms.Forms.Inventory;

namespace LibrarySystem.WinForms.Forms.Inventory
{
    partial class FrmInventory
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorrowed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.lblFilterStatus = new System.Windows.Forms.Label();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text = "Inventory";
            this.Size = new System.Drawing.Size(1100, 720);
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Load += new System.EventHandler(this.FrmInventory_Load);

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);

            // lblTitle
            this.lblTitle.Text = "Inventory";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(250, 35);

            // lblCount
            this.lblCount.Text = "Total: 0";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(280, 22);
            this.lblCount.Size = new System.Drawing.Size(100, 25);

            // btnAdjust
            this.btnAdjust.Text = "Adjust Stock";
            this.btnAdjust.Location = new System.Drawing.Point(840, 15);
            this.btnAdjust.Size = new System.Drawing.Size(130, 35);
            this.btnAdjust.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnAdjust.ForeColor = System.Drawing.Color.White;
            this.btnAdjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjust.FlatAppearance.BorderSize = 0;
            this.btnAdjust.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAdjust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdjust.Visible = false;
            this.btnAdjust.Click += new System.EventHandler(this.btnAdjust_Click);

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(985, 15);
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // pnlFilter
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(10, 75);
            this.pnlFilter.Size = new System.Drawing.Size(1080, 60);

            // lblFilterCategory
            this.lblFilterCategory.Text = "Category:";
            this.lblFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFilterCategory.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFilterCategory.Location = new System.Drawing.Point(10, 18);
            this.lblFilterCategory.Size = new System.Drawing.Size(70, 22);

            // cmbFilterCategory
            this.cmbFilterCategory.Location = new System.Drawing.Point(85, 15);
            this.cmbFilterCategory.Size = new System.Drawing.Size(180, 28);
            this.cmbFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Cursor = System.Windows.Forms.Cursors.Hand;

            // lblFilterType
            this.lblFilterType.Text = "Type:";
            this.lblFilterType.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFilterType.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFilterType.Location = new System.Drawing.Point(285, 18);
            this.lblFilterType.Size = new System.Drawing.Size(40, 22);

            // cmbFilterType
            this.cmbFilterType.Location = new System.Drawing.Point(330, 15);
            this.cmbFilterType.Size = new System.Drawing.Size(150, 28);
            this.cmbFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Cursor = System.Windows.Forms.Cursors.Hand;

            // lblFilterStatus
            this.lblFilterStatus.Text = "Status:";
            this.lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFilterStatus.Location = new System.Drawing.Point(500, 18);
            this.lblFilterStatus.Size = new System.Drawing.Size(50, 22);

            // cmbFilterStatus
            this.cmbFilterStatus.Location = new System.Drawing.Point(555, 15);
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 28);
            this.cmbFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnFilter
            this.btnFilter.Text = "Filter";
            this.btnFilter.Location = new System.Drawing.Point(725, 13);
            this.btnFilter.Size = new System.Drawing.Size(90, 32);
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // btnClearFilter
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.Location = new System.Drawing.Point(825, 13);
            this.btnClearFilter.Size = new System.Drawing.Size(80, 32);
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);

            // pnlGrid
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(10, 145);
            this.pnlGrid.Size = new System.Drawing.Size(1080, 560);

            // dgvInventory
            this.dgvInventory.Location = new System.Drawing.Point(10, 10);
            this.dgvInventory.Size = new System.Drawing.Size(1060, 540);
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvInventory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.dgvInventory.ColumnHeadersHeight = 40;
            this.dgvInventory.RowTemplate.Height = 35;
            this.dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvInventory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvInventory_CellFormatting);

            // Columns
            this.colProductID.Name = "colProductID";
            this.colProductID.HeaderText = "ID";
            this.colProductID.Visible = false;

            this.colProductName.Name = "colProductName";
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.FillWeight = 28;

            this.colCategory.Name = "colCategory";
            this.colCategory.HeaderText = "Category";
            this.colCategory.FillWeight = 16;

            this.colProductType.Name = "colProductType";
            this.colProductType.HeaderText = "Type";
            this.colProductType.FillWeight = 10;

            this.colInStock.Name = "colInStock";
            this.colInStock.HeaderText = "In Stock";
            this.colInStock.FillWeight = 12;

            this.colBorrowed.Name = "colBorrowed";
            this.colBorrowed.HeaderText = "Borrowed";
            this.colBorrowed.FillWeight = 12;

            this.colAvailable.Name = "colAvailable";
            this.colAvailable.HeaderText = "Available";
            this.colAvailable.FillWeight = 12;

            this.colMinStock.Name = "colMinStock";
            this.colMinStock.HeaderText = "Min Stock";
            this.colMinStock.FillWeight = 10;

            this.colStatus.Name = "colStatus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.FillWeight = 10;

            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colProductID,
                this.colProductName,
                this.colCategory,
                this.colProductType,
                this.colInStock,
                this.colBorrowed,
                this.colAvailable,
                this.colMinStock,
                this.colStatus
            });

            // Add to pnlTop
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnAdjust);
            this.pnlTop.Controls.Add(this.btnRefresh);

            // Add to pnlFilter
            this.pnlFilter.Controls.Add(this.lblFilterCategory);
            this.pnlFilter.Controls.Add(this.cmbFilterCategory);
            this.pnlFilter.Controls.Add(this.lblFilterType);
            this.pnlFilter.Controls.Add(this.cmbFilterType);
            this.pnlFilter.Controls.Add(this.lblFilterStatus);
            this.pnlFilter.Controls.Add(this.cmbFilterStatus);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.btnClearFilter);

            // Add to pnlGrid
            this.pnlGrid.Controls.Add(this.dgvInventory);

            // Add to Form
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlGrid);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorrowed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
    }
}
