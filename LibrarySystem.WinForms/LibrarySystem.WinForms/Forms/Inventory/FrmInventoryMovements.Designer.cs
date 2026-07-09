namespace LibrarySystem.WinForms.Forms.Inventory
{
    partial class FrmInventoryMovements
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvMovements = new System.Windows.Forms.DataGridView();
            this.colMovementID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMovementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReferenceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).BeginInit();
            this.SuspendLayout();

            // ── Form ──
            this.Text = "Inventory Movements";
            this.Size = new System.Drawing.Size(1100, 720);
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Load += new System.EventHandler(this.FrmInventoryMovements_Load);

            // ── pnlTop ──
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);

            // lblTitle
            this.lblTitle.Text = "📋 Inventory Movements";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Size = new System.Drawing.Size(310, 35);

            // lblCount
            this.lblCount.Text = "Total: 0";
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblCount.ForeColor = System.Drawing.Color.Gray;
            this.lblCount.Location = new System.Drawing.Point(340, 22);
            this.lblCount.Size = new System.Drawing.Size(70, 25);

            // btnRefresh
            this.btnRefresh.Text = "↻ Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(985, 15);
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlFilter ──
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(10, 75);
            this.pnlFilter.Size = new System.Drawing.Size(1080, 60);

            // lblFilterType
            this.lblFilterType.Text = "Type:";
            this.lblFilterType.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFilterType.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFilterType.Location = new System.Drawing.Point(10, 18);
            this.lblFilterType.Size = new System.Drawing.Size(40, 22);

            // cmbFilterType
            this.cmbFilterType.Location = new System.Drawing.Point(55, 15);
            this.cmbFilterType.Size = new System.Drawing.Size(160, 28);
            this.cmbFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.Cursor = System.Windows.Forms.Cursors.Hand;

            // lblFrom
            this.lblFrom.Text = "From:";
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblFrom.Location = new System.Drawing.Point(235, 18);
            this.lblFrom.Size = new System.Drawing.Size(40, 22);

            // dtpFrom
            this.dtpFrom.Location = new System.Drawing.Point(280, 15);
            this.dtpFrom.Size = new System.Drawing.Size(160, 28);
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.MinDate = new System.DateTime(1990, 1, 1);
            this.dtpFrom.MaxDate = System.DateTime.Today;

            // lblTo
            this.lblTo.Text = "To:";
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTo.Location = new System.Drawing.Point(455, 18);
            this.lblTo.Size = new System.Drawing.Size(25, 22);

            // dtpTo
            this.dtpTo.Location = new System.Drawing.Point(485, 15);
            this.dtpTo.Size = new System.Drawing.Size(160, 28);
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.MinDate = new System.DateTime(1990, 1, 1);
            this.dtpTo.MaxDate = System.DateTime.Today;

            // btnFilter
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.Location = new System.Drawing.Point(665, 13);
            this.btnFilter.Size = new System.Drawing.Size(90, 32);
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);

            // btnClearFilter
            this.btnClearFilter.Text = "✕ Clear";
            this.btnClearFilter.Location = new System.Drawing.Point(765, 13);
            this.btnClearFilter.Size = new System.Drawing.Size(80, 32);
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.btnClearFilter.ForeColor = System.Drawing.Color.White;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnClearFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);

            // ── pnlGrid ──
            this.pnlGrid.BackColor = System.Drawing.Color.White;
            this.pnlGrid.Location = new System.Drawing.Point(10, 145);
            this.pnlGrid.Size = new System.Drawing.Size(1080, 560);

            // ── dgvMovements ──
            this.dgvMovements.Location = new System.Drawing.Point(10, 10);
            this.dgvMovements.Size = new System.Drawing.Size(1060, 540);
            this.dgvMovements.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMovements.RowHeadersVisible = false;
            this.dgvMovements.AllowUserToAddRows = false;
            this.dgvMovements.AllowUserToDeleteRows = false;
            this.dgvMovements.ReadOnly = true;
            this.dgvMovements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovements.MultiSelect = false;
            this.dgvMovements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovements.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvMovements.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.dgvMovements.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMovements.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            this.dgvMovements.ColumnHeadersHeight = 40;
            this.dgvMovements.RowTemplate.Height = 35;
            this.dgvMovements.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvMovements.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovements_CellFormatting);

            // ── Columns ──
            this.colMovementID.Name = "colMovementID";
            this.colMovementID.HeaderText = "ID";
            this.colMovementID.Visible = false;

            this.colDate.Name = "colDate";
            this.colDate.HeaderText = "Date";
            this.colDate.FillWeight = 14;

            this.colProductName.Name = "colProductName";
            this.colProductName.HeaderText = "Product";
            this.colProductName.FillWeight = 22;

            this.colMovementType.Name = "colMovementType";
            this.colMovementType.HeaderText = "Type";
            this.colMovementType.FillWeight = 12;

            this.colQuantity.Name = "colQuantity";
            this.colQuantity.HeaderText = "Qty";
            this.colQuantity.FillWeight = 8;

            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.FillWeight = 12;

            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.HeaderText = "Total";
            this.colTotalAmount.FillWeight = 12;

            this.colReferenceType.Name = "colReferenceType";
            this.colReferenceType.HeaderText = "Ref Type";
            this.colReferenceType.FillWeight = 10;

            this.colNotes.Name = "colNotes";
            this.colNotes.HeaderText = "Notes";
            this.colNotes.FillWeight = 10;

            this.dgvMovements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMovementID,
                this.colDate,
                this.colProductName,
                this.colMovementType,
                this.colQuantity,
                this.colUnitPrice,
                this.colTotalAmount,
                this.colReferenceType,
                this.colNotes
            });

            // ── Add Controls ──
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblCount);
            this.pnlTop.Controls.Add(this.btnRefresh);

            this.pnlFilter.Controls.Add(this.lblFilterType);
            this.pnlFilter.Controls.Add(this.cmbFilterType);
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.btnClearFilter);

            this.pnlGrid.Controls.Add(this.dgvMovements);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlGrid);

            this.pnlTop.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovements)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvMovements;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovementID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMovementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReferenceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNotes;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
    }
}