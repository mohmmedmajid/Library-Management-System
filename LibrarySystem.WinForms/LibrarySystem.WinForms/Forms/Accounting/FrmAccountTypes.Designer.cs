namespace LibrarySystem.WinForms.Forms.Accounting
{
    partial class FrmAccountTypes
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
            System.Windows.Forms.DataGridViewCellStyle colEditStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colDeleteStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle alternatingStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAccountTypes = new System.Windows.Forms.DataGridView();

            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeNameAr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNormalBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTypes)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnNew);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);
            this.pnlTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏷️ Account Types";

            // lblCount
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(350, 22);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 25);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Total: 0";

            // btnNew
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(890, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 36);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "+ New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(995, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // pnlGrid
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Controls.Add(this.dgvAccountTypes);
            this.pnlGrid.Location = new System.Drawing.Point(10, 75);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1080, 600);
            this.pnlGrid.TabIndex = 1;

            // dgvAccountTypes
            this.dgvAccountTypes.AllowUserToAddRows = false;
            this.dgvAccountTypes.AllowUserToDeleteRows = false;
            this.dgvAccountTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccountTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvAccountTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;

            alternatingStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvAccountTypes.AlternatingRowsDefaultCellStyle = alternatingStyle;

            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            headerStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccountTypes.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvAccountTypes.ColumnHeadersHeight = 42;

            this.dgvAccountTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colID,
                this.colTypeName,
                this.colTypeNameAr,
                this.colNormalBalance,
                this.colDisplayOrder,
                this.colDescription,
                this.colStatus,
                this.colEdit,
                this.colDelete
            });

            this.dgvAccountTypes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvAccountTypes.Location = new System.Drawing.Point(0, 0);
            this.dgvAccountTypes.MultiSelect = false;
            this.dgvAccountTypes.Name = "dgvAccountTypes";
            this.dgvAccountTypes.RowHeadersVisible = false;
            this.dgvAccountTypes.RowTemplate.Height = 38;
            this.dgvAccountTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccountTypes.Size = new System.Drawing.Size(1080, 590);
            this.dgvAccountTypes.TabIndex = 0;
            this.dgvAccountTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountTypes_CellClick);

            // Columns
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;

            this.colTypeName.FillWeight = 20F;
            this.colTypeName.HeaderText = "Type Name";
            this.colTypeName.Name = "colTypeName";

            this.colTypeNameAr.FillWeight = 20F;
            this.colTypeNameAr.HeaderText = "Arabic Name";
            this.colTypeNameAr.Name = "colTypeNameAr";

            this.colNormalBalance.FillWeight = 12F;
            this.colNormalBalance.HeaderText = "Normal Balance";
            this.colNormalBalance.Name = "colNormalBalance";

            this.colDisplayOrder.FillWeight = 8F;
            this.colDisplayOrder.HeaderText = "Order";
            this.colDisplayOrder.Name = "colDisplayOrder";

            this.colDescription.FillWeight = 28F;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";

            this.colStatus.FillWeight = 8F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";

            // colEdit
            colEditStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colEditStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colEditStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colEditStyle.ForeColor = System.Drawing.Color.White;
            colEditStyle.SelectionBackColor = System.Drawing.Color.FromArgb(20, 80, 160);
            colEditStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colEdit.DefaultCellStyle = colEditStyle;
            this.colEdit.FillWeight = 8F;
            this.colEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colEdit.HeaderText = "";
            this.colEdit.Name = "colEdit";

            // colDelete
            colDeleteStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colDeleteStyle.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            colDeleteStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            colDeleteStyle.ForeColor = System.Drawing.Color.White;
            colDeleteStyle.SelectionBackColor = System.Drawing.Color.FromArgb(170, 30, 30);
            colDeleteStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colDelete.DefaultCellStyle = colDeleteStyle;
            this.colDelete.FillWeight = 8F;
            this.colDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";

            // Form
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "FrmAccountTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Types";
            this.Load += new System.EventHandler(this.FrmAccountTypes_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccountTypes)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
        private LibrarySystem.WinForms.UserControls.SearchBoxControl searchBox;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvAccountTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeNameAr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNormalBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}