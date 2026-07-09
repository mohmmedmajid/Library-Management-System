namespace LibrarySystem.WinForms.Forms.Main
{
    partial class FrmDashboard
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.pnlCustomers = new System.Windows.Forms.Panel();
            this.pnlLowStock = new System.Windows.Forms.Panel();
            this.pnlBorrowings = new System.Windows.Forms.Panel();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.lblProductsCount = new System.Windows.Forms.Label();
            this.lblCustomersTitle = new System.Windows.Forms.Label();
            this.lblCustomersCount = new System.Windows.Forms.Label();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.lblBorrowingsTitle = new System.Windows.Forms.Label();
            this.lblBorrowingsCount = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Form
            this.Text = "Dashboard";
            this.Size = new System.Drawing.Size(960, 680);
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.Load += new System.EventHandler(this.FrmDashboard_Load);

            // lblTitle
            this.lblTitle.Text = "Dashboard";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 40, 60);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);

            // btnRefresh
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(850, 20);
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // pnlProducts
            this.pnlProducts.BackColor = System.Drawing.Color.FromArgb(30, 100, 180);
            this.pnlProducts.Location = new System.Drawing.Point(20, 80);
            this.pnlProducts.Size = new System.Drawing.Size(210, 120);

            // lblProductsTitle
            this.lblProductsTitle.Text = "Total Products";
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.lblProductsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblProductsTitle.Size = new System.Drawing.Size(180, 25);

            // lblProductsCount
            this.lblProductsCount.Text = "0";
            this.lblProductsCount.Font = new System.Drawing.Font("Segoe UI", 28f, System.Drawing.FontStyle.Bold);
            this.lblProductsCount.ForeColor = System.Drawing.Color.White;
            this.lblProductsCount.Location = new System.Drawing.Point(15, 50);
            this.lblProductsCount.Size = new System.Drawing.Size(180, 55);

            // pnlCustomers
            this.pnlCustomers.BackColor = System.Drawing.Color.FromArgb(40, 160, 100);
            this.pnlCustomers.Location = new System.Drawing.Point(250, 80);
            this.pnlCustomers.Size = new System.Drawing.Size(210, 120);

            // lblCustomersTitle
            this.lblCustomersTitle.Text = "Total Customers";
            this.lblCustomersTitle.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.lblCustomersTitle.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.lblCustomersTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCustomersTitle.Size = new System.Drawing.Size(180, 25);

            // lblCustomersCount
            this.lblCustomersCount.Text = "0";
            this.lblCustomersCount.Font = new System.Drawing.Font("Segoe UI", 28f, System.Drawing.FontStyle.Bold);
            this.lblCustomersCount.ForeColor = System.Drawing.Color.White;
            this.lblCustomersCount.Location = new System.Drawing.Point(15, 50);
            this.lblCustomersCount.Size = new System.Drawing.Size(180, 55);

            // pnlLowStock
            this.pnlLowStock.BackColor = System.Drawing.Color.FromArgb(200, 100, 30);
            this.pnlLowStock.Location = new System.Drawing.Point(480, 80);
            this.pnlLowStock.Size = new System.Drawing.Size(210, 120);

            // lblLowStockTitle
            this.lblLowStockTitle.Text = "Low Stock";
            this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.lblLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.lblLowStockTitle.Location = new System.Drawing.Point(15, 15);
            this.lblLowStockTitle.Size = new System.Drawing.Size(180, 25);

            // lblLowStockCount
            this.lblLowStockCount.Text = "0";
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 28f, System.Drawing.FontStyle.Bold);
            this.lblLowStockCount.ForeColor = System.Drawing.Color.White;
            this.lblLowStockCount.Location = new System.Drawing.Point(15, 50);
            this.lblLowStockCount.Size = new System.Drawing.Size(180, 55);

            // pnlBorrowings
            this.pnlBorrowings.BackColor = System.Drawing.Color.FromArgb(150, 50, 150);
            this.pnlBorrowings.Location = new System.Drawing.Point(710, 80);
            this.pnlBorrowings.Size = new System.Drawing.Size(210, 120);

            // lblBorrowingsTitle
            this.lblBorrowingsTitle.Text = "Active Borrowings";
            this.lblBorrowingsTitle.Font = new System.Drawing.Font("Segoe UI", 10f);
            this.lblBorrowingsTitle.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.lblBorrowingsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBorrowingsTitle.Size = new System.Drawing.Size(180, 25);

            // lblBorrowingsCount
            this.lblBorrowingsCount.Text = "0";
            this.lblBorrowingsCount.Font = new System.Drawing.Font("Segoe UI", 28f, System.Drawing.FontStyle.Bold);
            this.lblBorrowingsCount.ForeColor = System.Drawing.Color.White;
            this.lblBorrowingsCount.Location = new System.Drawing.Point(15, 50);
            this.lblBorrowingsCount.Size = new System.Drawing.Size(180, 55);

            // Add to Panels
            this.pnlProducts.Controls.Add(this.lblProductsTitle);
            this.pnlProducts.Controls.Add(this.lblProductsCount);
            this.pnlCustomers.Controls.Add(this.lblCustomersTitle);
            this.pnlCustomers.Controls.Add(this.lblCustomersCount);
            this.pnlLowStock.Controls.Add(this.lblLowStockTitle);
            this.pnlLowStock.Controls.Add(this.lblLowStockCount);
            this.pnlBorrowings.Controls.Add(this.lblBorrowingsTitle);
            this.pnlBorrowings.Controls.Add(this.lblBorrowingsCount);

            // Add to Form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pnlProducts);
            this.Controls.Add(this.pnlCustomers);
            this.Controls.Add(this.pnlLowStock);
            this.Controls.Add(this.pnlBorrowings);

            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel pnlCustomers;
        private System.Windows.Forms.Panel pnlLowStock;
        private System.Windows.Forms.Panel pnlBorrowings;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblProductsCount;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Label lblCustomersCount;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblBorrowingsTitle;
        private System.Windows.Forms.Label lblBorrowingsCount;
    }
}