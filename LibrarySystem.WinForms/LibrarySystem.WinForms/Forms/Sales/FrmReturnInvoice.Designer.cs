// ==================== FrmReturnInvoice.Designer.cs ====================
namespace LibrarySystem.WinForms.Forms.Sales
{
    partial class FrmReturnInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblBorrowCount = new System.Windows.Forms.Label();
            this.dgvBorrowings = new System.Windows.Forms.DataGridView();
            this.colBorrowingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorrowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBorrowDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLateDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowings)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 62);
            this.pnlHeader.TabIndex = 2;
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "↩  Return Invoice";
            //
            // lblSubtitle
            //
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(160, 200, 255);
            this.lblSubtitle.Location = new System.Drawing.Point(18, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(600, 18);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Click Return on a borrowing to process its return.";
            //
            // pnlSearch
            //
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.pnlSearch.Controls.Add(this.lblSearchTitle);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnRefresh);
            this.pnlSearch.Controls.Add(this.lblBorrowCount);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 62);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1000, 55);
            this.pnlSearch.TabIndex = 1;
            //
            // lblSearchTitle
            //
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblSearchTitle.Location = new System.Drawing.Point(12, 17);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(60, 22);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "Search:";
            //
            // txtSearch
            //
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(76, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(360, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Borrowing # or customer name...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // btnRefresh
            //
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(100, 110, 130);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(446, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(85, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "⟳  Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // lblBorrowCount
            //
            this.lblBorrowCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBorrowCount.ForeColor = System.Drawing.Color.Gray;
            this.lblBorrowCount.Location = new System.Drawing.Point(540, 17);
            this.lblBorrowCount.Name = "lblBorrowCount";
            this.lblBorrowCount.Size = new System.Drawing.Size(90, 22);
            this.lblBorrowCount.TabIndex = 3;
            this.lblBorrowCount.Text = "Records: 0";
            //
            // dgvBorrowings
            //
            this.dgvBorrowings.AllowUserToAddRows = false;
            this.dgvBorrowings.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.dgvBorrowings.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBorrowings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowings.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrowings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(22, 32, 50);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dgvBorrowings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBorrowings.ColumnHeadersHeight = 40;
            this.dgvBorrowings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrowings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBorrowingID,
            this.colBorrowNumber,
            this.colCustomer,
            this.colBorrowDate,
            this.colExpected,
            this.colTotalDays,
            this.colTotalAmount,
            this.colLateDays,
            this.colStatus,
            this.colView});
            this.dgvBorrowings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBorrowings.EnableHeadersVisualStyles = false;
            this.dgvBorrowings.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvBorrowings.GridColor = System.Drawing.Color.FromArgb(230, 232, 236);
            this.dgvBorrowings.Location = new System.Drawing.Point(0, 117);
            this.dgvBorrowings.MultiSelect = false;
            this.dgvBorrowings.Name = "dgvBorrowings";
            this.dgvBorrowings.ReadOnly = true;
            this.dgvBorrowings.RowHeadersVisible = false;
            this.dgvBorrowings.RowTemplate.Height = 36;
            this.dgvBorrowings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowings.Size = new System.Drawing.Size(1000, 483);
            this.dgvBorrowings.TabIndex = 0;
            //
            // colBorrowingID
            //
            this.colBorrowingID.HeaderText = "ID";
            this.colBorrowingID.Name = "colBorrowingID";
            this.colBorrowingID.ReadOnly = true;
            this.colBorrowingID.Visible = false;
            //
            // colBorrowNumber
            //
            this.colBorrowNumber.FillWeight = 13F;
            this.colBorrowNumber.HeaderText = "Borrow #";
            this.colBorrowNumber.Name = "colBorrowNumber";
            this.colBorrowNumber.ReadOnly = true;
            //
            // colCustomer
            //
            this.colCustomer.FillWeight = 18F;
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            //
            // colBorrowDate
            //
            this.colBorrowDate.FillWeight = 12F;
            this.colBorrowDate.HeaderText = "Borrow Date";
            this.colBorrowDate.Name = "colBorrowDate";
            this.colBorrowDate.ReadOnly = true;
            //
            // colExpected
            //
            this.colExpected.FillWeight = 12F;
            this.colExpected.HeaderText = "Due Date";
            this.colExpected.Name = "colExpected";
            this.colExpected.ReadOnly = true;
            //
            // colTotalDays
            //
            this.colTotalDays.FillWeight = 7F;
            this.colTotalDays.HeaderText = "Days";
            this.colTotalDays.Name = "colTotalDays";
            this.colTotalDays.ReadOnly = true;
            //
            // colTotalAmount
            //
            this.colTotalAmount.FillWeight = 11F;
            this.colTotalAmount.HeaderText = "Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            //
            // colLateDays
            //
            this.colLateDays.FillWeight = 7F;
            this.colLateDays.HeaderText = "Late";
            this.colLateDays.Name = "colLateDays";
            this.colLateDays.ReadOnly = true;
            //
            // colStatus
            //
            this.colStatus.FillWeight = 10F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            //
            // colView
            //
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.colView.DefaultCellStyle = dataGridViewCellStyle3;
            this.colView.FillWeight = 10F;
            this.colView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colView.HeaderText = "";
            this.colView.Name = "colView";
            this.colView.Text = "↩ Return";
            this.colView.UseColumnTextForButtonValue = true;
            //
            // FrmReturnInvoice
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 246);
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvBorrowings);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "FrmReturnInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Return Invoice";
            this.Load += new System.EventHandler(this.FrmReturnInvoice_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowings)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle, lblSubtitle;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearchTitle, lblBorrowCount;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvBorrowings;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBorrowingID, colBorrowNumber, colCustomer,
            colBorrowDate, colExpected, colTotalDays, colTotalAmount, colLateDays, colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colView;

        private LibrarySystem.WinForms.UserControls.LoadingSpinnerControl spinner;
    }
}