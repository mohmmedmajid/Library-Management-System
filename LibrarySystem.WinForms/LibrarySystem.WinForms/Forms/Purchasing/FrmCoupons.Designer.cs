namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmCoupons
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
            this.lblStatPublic = new System.Windows.Forms.Label();
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
            this.dgvCoupons = new System.Windows.Forms.DataGridView();
            this.spinner = new LibrarySystem.WinForms.UserControls.LoadingSpinnerControl();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicableOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsageCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisibility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoupons)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 55;
            this.pnlTop.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Text = "Coupons Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            // pnlStats
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height = 45;
            this.pnlStats.Controls.Add(this.lblStatPublic);
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

            // lblStatPublic
            this.lblStatPublic.Text = "Public: 0";
            this.lblStatPublic.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblStatPublic.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblStatPublic.Location = new System.Drawing.Point(500, 13);
            this.lblStatPublic.AutoSize = true;

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
            this.lblCount.Text = "Total: 0 coupon(s)";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblCount.Location = new System.Drawing.Point(10, 7);
            this.lblCount.AutoSize = true;

            // dgvCoupons
            this.dgvCoupons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoupons.BackgroundColor = System.Drawing.Color.White;
            this.dgvCoupons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCoupons.RowHeadersVisible = false;
            this.dgvCoupons.AllowUserToAddRows = false;
            this.dgvCoupons.AllowUserToDeleteRows = false;
            this.dgvCoupons.ReadOnly = true;
            this.dgvCoupons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCoupons.MultiSelect = false;
            this.dgvCoupons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCoupons.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvCoupons.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvCoupons.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCoupons.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvCoupons.ColumnHeadersHeight = 36;
            this.dgvCoupons.EnableHeadersVisualStyles = false;
            this.dgvCoupons.RowTemplate.Height = 32;
            this.dgvCoupons.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            this.dgvCoupons.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoupons_CellClick);
            this.dgvCoupons.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCoupons_CellDoubleClick);

            // Columns
            this.colID.Name = "colID";
            this.colID.HeaderText = "ID";
            this.colID.FillWeight = 30;

            this.colCode.Name = "colCode";
            this.colCode.HeaderText = "Coupon Code";
            this.colCode.FillWeight = 80;

            this.colName.Name = "colName";
            this.colName.HeaderText = "Name";
            this.colName.FillWeight = 100;

            this.colType.Name = "colType";
            this.colType.HeaderText = "Type";
            this.colType.FillWeight = 70;

            this.colValue.Name = "colValue";
            this.colValue.HeaderText = "Value";
            this.colValue.FillWeight = 60;

            this.colMinPurchase.Name = "colMinPurchase";
            this.colMinPurchase.HeaderText = "Min Purchase";
            this.colMinPurchase.FillWeight = 70;

            this.colApplicableOn.Name = "colApplicableOn";
            this.colApplicableOn.HeaderText = "Applicable On";
            this.colApplicableOn.FillWeight = 70;

            this.colStartDate.Name = "colStartDate";
            this.colStartDate.HeaderText = "Start Date";
            this.colStartDate.FillWeight = 70;

            this.colEndDate.Name = "colEndDate";
            this.colEndDate.HeaderText = "End Date";
            this.colEndDate.FillWeight = 70;

            this.colUsageCount.Name = "colUsageCount";
            this.colUsageCount.HeaderText = "Used";
            this.colUsageCount.FillWeight = 40;

            this.colVisibility.Name = "colVisibility";
            this.colVisibility.HeaderText = "Visibility";
            this.colVisibility.FillWeight = 55;

            this.colStatus.Name = "colStatus";
            this.colStatus.HeaderText = "Status";
            this.colStatus.FillWeight = 55;

            this.dgvCoupons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colID, this.colCode, this.colName, this.colType, this.colValue,
                this.colMinPurchase, this.colApplicableOn, this.colStartDate, this.colEndDate,
                this.colUsageCount, this.colVisibility, this.colStatus
            });

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 620);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.BackColor = System.Drawing.Color.White;
            this.Text = "Coupons Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCoupons_Load);

            this.Controls.Add(this.dgvCoupons);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);

            this.pnlTop.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoupons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatActive;
        private System.Windows.Forms.Label lblStatExpired;
        private System.Windows.Forms.Label lblStatPublic;
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
        private System.Windows.Forms.DataGridView dgvCoupons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicableOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsageCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisibility;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}