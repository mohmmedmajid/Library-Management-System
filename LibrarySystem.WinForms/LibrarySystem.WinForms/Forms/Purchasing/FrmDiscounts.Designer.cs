using LibrarySystem.WinForms.UserControls;

namespace LibrarySystem.WinForms.Forms.Purchasing
{
    partial class FrmDiscounts
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblStatTotal = new System.Windows.Forms.Label();
            this.lblStatActive = new System.Windows.Forms.Label();
            this.lblStatExpired = new System.Windows.Forms.Label();
            this.dgvDiscounts = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.spinner = new LoadingSpinnerControl();

            // Columns
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colApplicableOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsageCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.pnlTop.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 60;
            this.pnlTop.Controls.Add(this.spinner);
            this.pnlTop.Controls.Add(this.lblTitle);

            this.lblTitle.Text = "🏷️  Discounts Management";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);

            this.spinner.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.spinner.Size = new System.Drawing.Size(40, 40);
            this.spinner.Location = new System.Drawing.Point(940, 10);

            // ── pnlStats ──
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height = 55;
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlStats.Controls.Add(this.lblStatExpired);
            this.pnlStats.Controls.Add(this.lblStatActive);
            this.pnlStats.Controls.Add(this.lblStatTotal);

            this.lblStatTotal.AutoSize = true;
            this.lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblStatTotal.Location = new System.Drawing.Point(10, 15);
            this.lblStatTotal.Text = "🏷️  Total Discounts: --";

            this.lblStatActive.AutoSize = true;
            this.lblStatActive.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatActive.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblStatActive.Location = new System.Drawing.Point(260, 15);
            this.lblStatActive.Text = "✅  Active: --";

            this.lblStatExpired.AutoSize = true;
            this.lblStatExpired.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.lblStatExpired.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.lblStatExpired.Location = new System.Drawing.Point(460, 15);
            this.lblStatExpired.Text = "⚠️  Expired: --";

            // ── pnlSearch ──
            this.pnlSearch.BackColor = System.Drawing.Color.White;
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Height = 50;
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlSearch.Controls.Add(this.cmbFilter);
            this.pnlSearch.Controls.Add(this.lblFilter);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearch);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSearch.Location = new System.Drawing.Point(10, 16);
            this.lblSearch.Text = "Search:";

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.txtSearch.Location = new System.Drawing.Point(65, 12);
            this.txtSearch.Size = new System.Drawing.Size(280, 26);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFilter.Location = new System.Drawing.Point(370, 16);
            this.lblFilter.Text = "Status:";

            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cmbFilter.Location = new System.Drawing.Point(420, 12);
            this.cmbFilter.Size = new System.Drawing.Size(120, 25);
            this.cmbFilter.Items.AddRange(new object[] { "All", "Active", "Inactive" });
            this.cmbFilter.SelectedIndex = 0;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);

            // ── pnlButtons ──
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Height = 48;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(10, 8);
            this.btnAdd.Size = new System.Drawing.Size(110, 32);
            this.btnAdd.Text = "➕  Add New";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(130, 8);
            this.btnEdit.Size = new System.Drawing.Size(100, 32);
            this.btnEdit.Text = "✏️  Edit";
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Enabled = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(240, 8);
            this.btnDelete.Size = new System.Drawing.Size(100, 32);
            this.btnDelete.Text = "🗑️  Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(350, 8);
            this.btnRefresh.Size = new System.Drawing.Size(100, 32);
            this.btnRefresh.Text = "🔄  Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── dgvDiscounts ──
            this.dgvDiscounts.AllowUserToAddRows = false;
            this.dgvDiscounts.AllowUserToDeleteRows = false;
            this.dgvDiscounts.ReadOnly = true;
            this.dgvDiscounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiscounts.MultiSelect = false;
            this.dgvDiscounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiscounts.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvDiscounts.RowHeadersVisible = false;
            this.dgvDiscounts.BackgroundColor = System.Drawing.Color.White;
            this.dgvDiscounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDiscounts.ColumnHeadersHeight = 36;
            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDiscounts.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvDiscounts.EnableHeadersVisualStyles = false;
            this.dgvDiscounts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 252);
            this.dgvDiscounts.RowTemplate.Height = 32;
            this.dgvDiscounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounts_CellClick);
            this.dgvDiscounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiscounts_CellDoubleClick);

            // Columns
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.FillWeight = 5;
            this.colID.MinimumWidth = 45;

            this.colName.HeaderText = "Discount Name";
            this.colName.Name = "colName";
            this.colName.FillWeight = 18;

            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.FillWeight = 12;

            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.FillWeight = 9;
            this.colValue.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colMinPurchase.HeaderText = "Min Purchase";
            this.colMinPurchase.Name = "colMinPurchase";
            this.colMinPurchase.FillWeight = 11;
            this.colMinPurchase.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colMaxDiscount.HeaderText = "Max Discount";
            this.colMaxDiscount.Name = "colMaxDiscount";
            this.colMaxDiscount.FillWeight = 11;
            this.colMaxDiscount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;

            this.colApplicableOn.HeaderText = "Applicable On";
            this.colApplicableOn.Name = "colApplicableOn";
            this.colApplicableOn.FillWeight = 11;

            this.colStartDate.HeaderText = "Start Date";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.FillWeight = 10;
            this.colStartDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colEndDate.HeaderText = "End Date";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.FillWeight = 10;
            this.colEndDate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colUsageCount.HeaderText = "Usage Count";
            this.colUsageCount.Name = "colUsageCount";
            this.colUsageCount.FillWeight = 8;
            this.colUsageCount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.FillWeight = 8;
            this.colStatus.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;

            this.dgvDiscounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID, this.colName, this.colType, this.colValue,
                this.colMinPurchase, this.colMaxDiscount, this.colApplicableOn,
                this.colStartDate, this.colEndDate, this.colUsageCount, this.colStatus
            });

            // ── pnlBottom ──
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 30;
            this.pnlBottom.Controls.Add(this.lblCount);

            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblCount.Location = new System.Drawing.Point(10, 8);
            this.lblCount.Text = "Total: 0 discount(s)";

            // ── FrmDiscounts ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 640);
            this.Controls.Add(this.dgvDiscounts);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.Name = "FrmDiscounts";
            this.Text = "Discounts Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDiscounts_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiscounts)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblStatTotal;
        private System.Windows.Forms.Label lblStatActive;
        private System.Windows.Forms.Label lblStatExpired;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvDiscounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colApplicableOn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsageCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblCount;
        private LoadingSpinnerControl spinner;
    }
}