namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmPromotionalOffers
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblStatActive = new System.Windows.Forms.Label();
            this.lblStatExpired = new System.Windows.Forms.Label();
            this.lblStatExpiringSoon = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.dgvOffers = new System.Windows.Forms.DataGridView();
            this.spinner = new LibrarySystem.WinForms.UserControls.LoadingSpinnerControl();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBuyProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGetProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Promotional Offers Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // pnlStats
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height = 45;
            this.pnlStats.Controls.Add(this.lblStatExpiringSoon);
            this.pnlStats.Controls.Add(this.lblStatExpired);
            this.pnlStats.Controls.Add(this.lblStatActive);
            this.pnlStats.Controls.Add(this.lblStatTotal);

            // lblStatTotal
            this.lblStatTotal.Text = "Total: 0";
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblStatTotal.Location = new System.Drawing.Point(15, 13);
            this.lblStatTotal.AutoSize = true;

            // lblStatActive
            this.lblStatActive.Text = "Active: 0";
            this.lblStatActive.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatActive.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblStatActive.Location = new System.Drawing.Point(180, 13);
            this.lblStatActive.AutoSize = true;

            // lblStatExpired
            this.lblStatExpired.Text = "Expired: 0";
            this.lblStatExpired.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatExpired.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblStatExpired.Location = new System.Drawing.Point(340, 13);
            this.lblStatExpired.AutoSize = true;

            // lblStatExpiringSoon
            this.lblStatExpiringSoon.Text = "Expiring Soon: 0";
            this.lblStatExpiringSoon.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatExpiringSoon.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.lblStatExpiringSoon.Location = new System.Drawing.Point(500, 13);
            this.lblStatExpiringSoon.AutoSize = true;

            // pnlToolbar
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 55;
            this.pnlToolbar.Controls.Add(this.btnAdd);
            this.pnlToolbar.Controls.Add(this.btnEdit);
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.lblSearch);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.lblFilter);
            this.pnlToolbar.Controls.Add(this.cmbFilter);
            this.pnlToolbar.Controls.Add(this.spinner);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 10);
            this.btnAdd.Size = new System.Drawing.Size(100, 34);
            this.btnAdd.Text = "Add";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(118, 10);
            this.btnEdit.Size = new System.Drawing.Size(100, 34);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(226, 10);
            this.btnDelete.Size = new System.Drawing.Size(100, 34);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(334, 10);
            this.btnRefresh.Size = new System.Drawing.Size(100, 34);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblSearch
            this.lblSearch.Text = "Search:";
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblSearch.Location = new System.Drawing.Point(450, 18);
            this.lblSearch.AutoSize = true;

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.Location = new System.Drawing.Point(505, 13);
            this.txtSearch.Size = new System.Drawing.Size(180, 28);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // lblFilter
            this.lblFilter.Text = "Filter:";
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblFilter.Location = new System.Drawing.Point(698, 18);
            this.lblFilter.AutoSize = true;

            // cmbFilter
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbFilter.Location = new System.Drawing.Point(743, 13);
            this.cmbFilter.Size = new System.Drawing.Size(130, 28);
            this.cmbFilter.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);

            // spinner
            this.spinner.Location = new System.Drawing.Point(885, 10);
            this.spinner.Size = new System.Drawing.Size(35, 35);

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 30;
            this.pnlBottom.Controls.Add(this.lblCount);

            // lblCount
            this.lblCount.Text = "Total: 0 offer(s)";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblCount.Location = new System.Drawing.Point(10, 7);
            this.lblCount.AutoSize = true;

            // dgvOffers
            this.dgvOffers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOffers.BackgroundColor = System.Drawing.Color.White;
            this.dgvOffers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOffers.RowHeadersVisible = false;
            this.dgvOffers.AllowUserToAddRows = false;
            this.dgvOffers.AllowUserToDeleteRows = false;
            this.dgvOffers.ReadOnly = true;
            this.dgvOffers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOffers.MultiSelect = false;
            this.dgvOffers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOffers.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvOffers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvOffers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvOffers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvOffers.ColumnHeadersHeight = 36;
            this.dgvOffers.EnableHeadersVisualStyles = false;
            this.dgvOffers.RowTemplate.Height = 32;
            this.dgvOffers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.dgvOffers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOffers_CellClick);
            this.dgvOffers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOffers_CellDoubleClick);

            // Columns
            this.colID.Name = "colID";
            this.colID.HeaderText = "ID";
            this.colID.FillWeight = 30;

            this.colName.Name = "colName";
            this.colName.HeaderText = "Offer Name";
            this.colName.FillWeight = 100;

            this.colType.Name = "colType";
            this.colType.HeaderText = "Type";
            this.colType.FillWeight = 60;

            this.colValue.Name = "colValue";
            this.colValue.HeaderText = "Value";
            this.colValue.FillWeight = 90;

            this.colBuyProduct.Name = "colBuyProduct";
            this.colBuyProduct.HeaderText = "Buy Product";
            this.colBuyProduct.FillWeight = 100;

            this.colGetProduct.Name = "colGetProduct";
            this.colGetProduct.HeaderText = "Get Product";
            this.colGetProduct.FillWeight = 100;

            this.colStartDate.Name = "colStartDate";
            this.colStartDate.HeaderText = "Start Date";
            this.colStartDate.FillWeight = 70;

            this.colEndDate.Name = "colEndDate";
            this.colEndDate.HeaderText = "End Date";
            this.colEndDate.FillWeight = 70;

            this.colStatus.Name = "colStatus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.FillWeight = 55;

            this.dgvOffers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colID, this.colName, this.colType, this.colValue,
                this.colBuyProduct, this.colGetProduct, this.colStartDate, this.colEndDate,
                this.colStatus
            });

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor = System.Drawing.Color.White;
            this.Text = "Promotional Offers Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPromotionalOffers_Load);

            this.Controls.Add(this.dgvOffers);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);

            this.pnlTop.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOffers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatActive;
        private System.Windows.Forms.Label lblStatExpired;
        private System.Windows.Forms.Label lblStatExpiringSoon;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFilter;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.DataGridView dgvOffers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBuyProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGetProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}