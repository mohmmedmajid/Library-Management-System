namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmLateFees
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
            System.Windows.Forms.DataGridViewCellStyle hdrStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle colViewStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();

            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblFeeCount = new System.Windows.Forms.Label();
            this.dgvLateFees = new System.Windows.Forms.DataGridView();
            this.colLateFeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorrowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLateDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewButtonColumn();

            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLateFees)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Size = new System.Drawing.Size(1100, 60);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTitle.Size = new System.Drawing.Size(280, 30);
            this.lblTitle.Text = "Late Fees";

            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblSubtitle.Location = new System.Drawing.Point(15, 38);
            this.lblSubtitle.Size = new System.Drawing.Size(500, 18);
            this.lblSubtitle.Text = "View, collect, or waive late fees for overdue returns.";

            // ── pnlLeft (now fills the whole client area) ──
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Location = new System.Drawing.Point(0, 60);
            this.pnlLeft.Size = new System.Drawing.Size(1100, 680);
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLeft.Controls.Add(this.pnlSearch);
            this.pnlLeft.Controls.Add(this.dgvLateFees);

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Size = new System.Drawing.Size(1100, 55);
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.cmbStatus);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Controls.Add(this.lblFeeCount);

            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblSearchTitle.Location = new System.Drawing.Point(10, 17);
            this.lblSearchTitle.Size = new System.Drawing.Size(60, 22);
            this.lblSearchTitle.Text = "Search:";

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(73, 14);
            this.txtSearch.Size = new System.Drawing.Size(220, 24);
            this.txtSearch.Text = "Borrowing # or customer name...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.cmbStatus.Location = new System.Drawing.Point(303, 14);
            this.cmbStatus.Size = new System.Drawing.Size(100, 24);
            this.cmbStatus.Items.AddRange(new object[] { "All", "Pending", "Paid", "Waived" });
            this.cmbStatus.SelectedIndex = 0;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(413, 13);
            this.btnRefresh.Size = new System.Drawing.Size(90, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.lblFeeCount.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblFeeCount.ForeColor = System.Drawing.Color.Gray;
            this.lblFeeCount.Location = new System.Drawing.Point(513, 17);
            this.lblFeeCount.Size = new System.Drawing.Size(100, 22);
            this.lblFeeCount.Text = "Records: 0";

            // dgvLateFees (now fills the rest of pnlLeft)
            altStyle1.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.dgvLateFees.AlternatingRowsDefaultCellStyle = altStyle1;
            hdrStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            hdrStyle1.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            hdrStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            hdrStyle1.ForeColor = System.Drawing.Color.White;
            this.dgvLateFees.ColumnHeadersDefaultCellStyle = hdrStyle1;
            this.dgvLateFees.AllowUserToAddRows = false;
            this.dgvLateFees.AllowUserToDeleteRows = false;
            this.dgvLateFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLateFees.BackgroundColor = System.Drawing.Color.White;
            this.dgvLateFees.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLateFees.ColumnHeadersHeight = 40;
            this.dgvLateFees.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.dgvLateFees.Location = new System.Drawing.Point(0, 55);
            this.dgvLateFees.MultiSelect = false;
            this.dgvLateFees.Name = "dgvLateFees";
            this.dgvLateFees.ReadOnly = true;
            this.dgvLateFees.RowHeadersVisible = false;
            this.dgvLateFees.RowTemplate.Height = 36;
            this.dgvLateFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLateFees.Size = new System.Drawing.Size(1100, 625);
            this.dgvLateFees.Anchor = ((System.Windows.Forms.AnchorStyles)(
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLateFees.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvLateFees_CellFormatting);
            this.dgvLateFees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLateFees_CellClick);

            this.colLateFeeID.Name = "colLateFeeID"; this.colLateFeeID.HeaderText = "ID"; this.colLateFeeID.Visible = false;
            this.colBorrowNumber.Name = "colBorrowNumber"; this.colBorrowNumber.HeaderText = "Borrow #"; this.colBorrowNumber.FillWeight = 15f;
            this.colCustomer.Name = "colCustomer"; this.colCustomer.HeaderText = "Customer"; this.colCustomer.FillWeight = 18f;
            this.colLateDays.Name = "colLateDays"; this.colLateDays.HeaderText = "Late Days"; this.colLateDays.FillWeight = 10f;
            this.colTotalFee.Name = "colTotalFee"; this.colTotalFee.HeaderText = "Total Fee"; this.colTotalFee.FillWeight = 11f;
            this.colPaid.Name = "colPaid"; this.colPaid.HeaderText = "Paid"; this.colPaid.FillWeight = 10f;
            this.colRemaining.Name = "colRemaining"; this.colRemaining.HeaderText = "Remaining"; this.colRemaining.FillWeight = 11f;
            this.colStatus.Name = "colStatus"; this.colStatus.HeaderText = "Status"; this.colStatus.FillWeight = 12f;

            colViewStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            colViewStyle.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colViewStyle.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            colViewStyle.ForeColor = System.Drawing.Color.White;
            colViewStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            colViewStyle.SelectionForeColor = System.Drawing.Color.White;
            this.colView.DefaultCellStyle = colViewStyle;
            this.colView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colView.HeaderText = "";
            this.colView.Name = "colView";
            this.colView.Text = "👁 View";
            this.colView.UseColumnTextForButtonValue = true;
            this.colView.FillWeight = 13f;

            this.dgvLateFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colLateFeeID, this.colBorrowNumber, this.colCustomer,
                this.colLateDays, this.colTotalFee, this.colPaid, this.colRemaining, this.colStatus, this.colView });

            // ── Form ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(7f, 15f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1100, 740);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlLeft);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLateFees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Late Fees";
            this.Load += new System.EventHandler(this.FrmLateFees_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLateFees)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchTitle, lblFeeCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvLateFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLateFeeID, colBorrowNumber, colCustomer,
            colLateDays, colTotalFee, colPaid, colRemaining, colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colView;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}