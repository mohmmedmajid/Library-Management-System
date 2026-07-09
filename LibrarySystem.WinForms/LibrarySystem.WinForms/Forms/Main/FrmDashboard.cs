using LibrarySystem.WinForms.Helpers;
using LibrarySystem.WinForms.Models.Core;
using LibrarySystem.WinForms.Models.Sales;
using LibrarySystem.WinForms.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Main
{
    public partial class FrmDashboard : Form
    {
        private LoadingSpinnerControl spinner;

        public FrmDashboard()
        {
            InitializeComponent();

            // Spinner في الكود مباشرة
            spinner = new LoadingSpinnerControl();
            spinner.Location = new Point(750, 15);
            spinner.Size = new Size(45, 45);
            this.Controls.Add(spinner);
        }

        private async void FrmDashboard_Load(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }

        private async System.Threading.Tasks.Task LoadDashboardData()
        {
            try
            {
                spinner.Start();
                btnRefresh.Enabled = false;

                var products = await ApiHelper.GetAsync<List<Product>>("products");
                lblProductsCount.Text = products?.Count.ToString() ?? "0";

                var customers = await ApiHelper.GetAsync<List<Customer>>("customers");
                lblCustomersCount.Text = customers?.Count.ToString() ?? "0";

                var lowStock = products?.Where(p => p.QuantityInStock < 5).ToList();
                lblLowStockCount.Text = lowStock?.Count.ToString() ?? "0";

                var borrowings = await ApiHelper.GetAsync<List<BorrowingTransaction>>("borrowingtransactions");
                var active = borrowings?.Where(b => b.Status == "Borrowed").ToList();
                lblBorrowingsCount.Text = active?.Count.ToString() ?? "0";
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error loading dashboard: " + ex.Message);
            }
            finally
            {
                spinner.Stop();
                btnRefresh.Enabled = true;
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadDashboardData();
        }
    }
}