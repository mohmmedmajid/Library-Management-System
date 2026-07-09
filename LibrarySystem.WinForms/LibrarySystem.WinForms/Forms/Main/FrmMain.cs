using LibrarySystem.WinForms.Forms.Auth;
using LibrarySystem.WinForms.Forms.Inventory;
using LibrarySystem.WinForms.Forms.Purchasing;
using LibrarySystem.WinForms.Forms.Sales;
using LibrarySystem.WinForms.Forms.Accounting;
using LibrarySystem.WinForms.Forms.HR;
using LibrarySystem.WinForms.Forms.Advanced;
using LibrarySystem.WinForms.Forms.Reports;
using LibrarySystem.WinForms.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Main
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome,  " + SessionManager.FullName;
            lblRole.Text = SessionManager.Role;
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");

            HideSidebarScrollbar();
            StyleSidebarButtons();
            ApplyRolePermissions();
            RearrangeSidebar();

            this.Resize += new EventHandler(FrmMain_Resize);
            FrmMain_Resize(null, null);

            OpenForm(new FrmDashboard());
        }

        private void HideSidebarScrollbar()
        {
            pnlSidebar.AutoScroll = false;
            pnlSidebar.HorizontalScroll.Maximum = 0;
            pnlSidebar.HorizontalScroll.Visible = false;
            pnlSidebar.VerticalScroll.Maximum = 0;
            pnlSidebar.VerticalScroll.Visible = false;
            pnlSidebar.AutoScroll = true;
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            pnlSidebar.Height = this.ClientSize.Height;
            pnlHeader.Width = this.ClientSize.Width - 240;
            pnlContent.Width = this.ClientSize.Width - 240;
            pnlContent.Height = this.ClientSize.Height - 65;
        }

        private void StyleSidebarButtons()
        {
            Button[] buttons = {
    btnDashboard, btnUsers, btnRoles, btnSettings,
    btnPaymentMethods, btnAuditLog, btnCategories,
    btnProducts, btnBooks, btnInventory, btnInventoryMovements,
    btnCustomers, btnSaleInvoice, btnAllInvoices, btnBorrowInvoice, btnLateFees,
    btnReturnInvoice, btnSaleReturn, btnSalesReps, btnRepCommissions,
    btnSuppliers, btnSupplierTransactions, btnPurchaseInvoice, btnExchangeInvoice,
    btnExpenseCategories, btnExpenses, btnDiscounts, btnCoupons,
    btnPromotionalOffers,
    btnAccountTypes, btnChartOfAccounts, btnAccountBalances,
    btnJournalEntry, btnCostCenters, btnTrialBalance,
    btnDepartments, btnEmployees, btnSalaryComponents, btnPayroll,
    btnEmployeeAdvances, btnBonuses, btnLateFeeRules,
    btnTaxTypes, btnTaxDeclarations, btnFixedAssetCategories, btnFixedAssets,
    btnAssetDepreciation, btnMessageTemplates,
    btnSalesReports, btnInventoryReports, btnBorrowReports, btnCustomerReports,
    btnSupplierReports, btnHRReports, btnFinancialReports, btnTaxReports,
    btnLogout
};

            foreach (var btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 65, 90);
                btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 80, 110);
                btn.ForeColor = Color.FromArgb(200, 210, 230);
                btn.BackColor = Color.Transparent;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Font = new Font("Segoe UI", 9.5f);
                btn.Cursor = Cursors.Hand;
                btn.Padding = new Padding(15, 0, 0, 0);
            }

            btnLogout.ForeColor = Color.FromArgb(255, 120, 120);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 40, 40);
        }

        private void ApplyRolePermissions()
        {
            if (SessionManager.Role == "Admin")
            {
                btnUsers.Visible = true;
                btnRoles.Visible = true;
                btnAuditLog.Visible = true;
                btnSettings.Visible = true;
                btnChartOfAccounts.Visible = true;
                btnJournalEntry.Visible = true;
                btnTaxTypes.Visible = true;
                btnFixedAssets.Visible = true;
                btnPayroll.Visible = true;
                btnExpenses.Visible = true;
                btnSalesReps.Visible = true;
                btnRepCommissions.Visible = true;
                btnSuppliers.Visible = true;
                btnSupplierTransactions.Visible = true;
                btnPurchaseInvoice.Visible = true;
                btnExchangeInvoice.Visible = true;
                btnExpenseCategories.Visible = true;
                btnDiscounts.Visible = true;
                btnCoupons.Visible = true;
                btnPromotionalOffers.Visible = true;
                btnAllInvoices.Visible = true;
                btnSaleReturn.Visible = true;
                lblGroupMain.Visible = true;
                lblGroupAccounting.Visible = true;
                lblGroupAdvanced.Visible = true;
                lblGroupPurchasing.Visible = true;
                lblGroupHR.Visible = true;

                btnAccountTypes.Visible = true;
                btnAccountBalances.Visible = true;
                btnCostCenters.Visible = true;
                btnTrialBalance.Visible = true;

                btnDepartments.Visible = true;
                btnSalaryComponents.Visible = true;
                btnEmployeeAdvances.Visible = true;
                btnBonuses.Visible = true;
                btnLateFeeRules.Visible = true;

                btnTaxDeclarations.Visible = true;
                btnFixedAssetCategories.Visible = true;
                btnAssetDepreciation.Visible = true;
                btnMessageTemplates.Visible = true;
            }
            else if (SessionManager.Role == "Cashier")
            {
                btnUsers.Visible = false;
                btnRoles.Visible = false;
                btnAuditLog.Visible = false;
                btnSettings.Visible = false;
                btnChartOfAccounts.Visible = false;
                btnJournalEntry.Visible = false;
                btnTaxTypes.Visible = false;
                btnFixedAssets.Visible = false;
                btnPayroll.Visible = false;
                btnSalesReps.Visible = false;
                btnRepCommissions.Visible = false;
                lblGroupMain.Visible = false;
                lblGroupAccounting.Visible = false;
                lblGroupAdvanced.Visible = false;
                lblGroupHR.Visible = false;

                btnSuppliers.Visible = false;
                btnSupplierTransactions.Visible = false;
                btnExpenses.Visible = false;
                btnExpenseCategories.Visible = false;
                btnPurchaseInvoice.Visible = false;
                btnExchangeInvoice.Visible = false;
                btnDiscounts.Visible = true;
                btnCoupons.Visible = true;
                btnPromotionalOffers.Visible = true;
                lblGroupPurchasing.Visible = true;

                btnAllInvoices.Visible = true;
                btnSaleReturn.Visible = true;

                btnAccountTypes.Visible = false;
                btnAccountBalances.Visible = false;
                btnCostCenters.Visible = false;
                btnTrialBalance.Visible = false;

                btnDepartments.Visible = false;
                btnSalaryComponents.Visible = false;
                btnEmployeeAdvances.Visible = false;
                btnBonuses.Visible = false;
                btnLateFeeRules.Visible = false;

                btnTaxDeclarations.Visible = false;
                btnFixedAssetCategories.Visible = false;
                btnAssetDepreciation.Visible = false;
                btnMessageTemplates.Visible = false;
            }
            else if (SessionManager.Role == "Observer")
            {
                btnUsers.Visible = false;
                btnRoles.Visible = false;
                btnSettings.Visible = false;
                btnChartOfAccounts.Visible = false;
                btnJournalEntry.Visible = false;
                btnTaxTypes.Visible = false;
                btnFixedAssets.Visible = false;
                btnPayroll.Visible = false;
                lblGroupAccounting.Visible = false;
                lblGroupAdvanced.Visible = false;
                lblGroupHR.Visible = false;

                btnSuppliers.Visible = true;
                btnSupplierTransactions.Visible = true;
                btnPurchaseInvoice.Visible = false;
                btnExchangeInvoice.Visible = false;
                btnExpenseCategories.Visible = false;
                btnExpenses.Visible = false;
                btnDiscounts.Visible = true;
                btnCoupons.Visible = true;
                btnPromotionalOffers.Visible = true;
                lblGroupPurchasing.Visible = true;

                btnAllInvoices.Visible = true;
                btnSaleReturn.Visible = false;

                btnAccountTypes.Visible = false;
                btnAccountBalances.Visible = false;
                btnCostCenters.Visible = false;
                btnTrialBalance.Visible = false;

                btnDepartments.Visible = false;
                btnSalaryComponents.Visible = false;
                btnEmployeeAdvances.Visible = false;
                btnBonuses.Visible = false;
                btnLateFeeRules.Visible = false;

                btnTaxDeclarations.Visible = false;
                btnFixedAssetCategories.Visible = false;
                btnAssetDepreciation.Visible = false;
                btnMessageTemplates.Visible = false;
            }
        }

        private void RearrangeSidebar()
        {
            int y = 160;

            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl == pnlSidebarTop) continue;
                if (ctrl == pnlUserInfo) continue;
                if (ctrl == pnlLogout) continue;

                if (ctrl.Visible)
                {
                    ctrl.Location = new Point(ctrl.Location.X, y);
                    y += ctrl.Height;
                }
            }

            pnlLogout.Location = new Point(0, y + 10);
        }

        private void OpenForm(Form form)
        {
            foreach (Control ctrl in pnlContent.Controls)
                ctrl.Dispose();
            pnlContent.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(form);
            form.Show();
        }

        // ─── Buttons ───

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDashboard());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmUsers());
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmRoles());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSettings());
        }

        private void btnPaymentMethods_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmPaymentMethods());
        }

        private void btnAuditLog_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAuditLog());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCategories());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmProducts());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBooks());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmInventory());
        }

        private void btnInventoryMovements_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmInventoryMovements());
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCustomers());
        }

        private void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSaleInvoice());
        }

        private void btnAllInvoices_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAllInvoices());
        }

        private void btnBorrowInvoice_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBorrowInvoice());
        }

        private void btnLateFees_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmLateFees());
        }

        private void btnReturnInvoice_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmReturnInvoice());
        }

        private void btnSaleReturn_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSaleReturn());
        }

        private void btnSalesReps_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSalesReps());
        }

        private void btnRepCommissions_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmRepCommissions());
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSuppliers());
        }
        private void btnSupplierTransactions_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSupplierTransactions());
        }

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmPurchaseInvoice());
        }

        private void btnExchangeInvoice_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmExchangeInvoice());
        }

        private void btnExpenseCategories_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmExpenseCategories());
        }

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDiscounts());
        }

        private void btnCoupons_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCoupons());
        }

        private void btnPromotionalOffers_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmPromotionalOffers());
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmExpenses());
        }

        // ─── Accounting ───

        private void btnAccountTypes_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAccountTypes());
        }

        private void btnChartOfAccounts_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmChartOfAccounts());
        }

        private void btnAccountBalances_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAccountBalances());
        }

        private void btnJournalEntry_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmJournalEntry());
        }

        private void btnCostCenters_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCostCenters());
        }

        private void btnTrialBalance_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmTrialBalance());
        }

        // ─── HR ───

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmDepartments());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmEmployees());
        }

        private void btnSalaryComponents_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSalaryComponents());
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmPayroll());
        }

        private void btnEmployeeAdvances_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmEmployeeAdvances());
        }

        private void btnBonuses_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBonuses());
        }

        private void btnLateFeeRules_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmLateFeeRules());
        }

        // ─── Advanced ───

        private void btnTaxTypes_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmTaxTypes());
        }

        private void btnTaxDeclarations_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmTaxDeclarations());
        }

        private void btnFixedAssetCategories_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmFixedAssetCategories());
        }

        private void btnFixedAssets_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmFixedAssets());
        }

        private void btnAssetDepreciation_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAssetDepreciation());
        }

        private void btnMessageTemplates_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmMessageTemplates());
        }

        // ─── Reports ───

        private void btnSalesReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSalesReports());
        }

        private void btnInventoryReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmInventoryReports());
        }

        private void btnBorrowReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBorrowReports());
        }

        private void btnCustomerReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCustomerReports());
        }

        private void btnSupplierReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmSupplierReports());
        }

        private void btnHRReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmHRReports());
        }

        private void btnFinancialReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmFinancialReports());
        }

        private void btnTaxReports_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmTaxReports());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ShowConfirm("Are you sure you want to logout?"))
            {
                SessionManager.Logout();
                var frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
        }
    }
}