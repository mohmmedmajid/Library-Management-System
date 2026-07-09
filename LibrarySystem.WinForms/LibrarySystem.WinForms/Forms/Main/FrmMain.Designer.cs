using System;
using System.Drawing;
using System.Windows.Forms;

namespace LibrarySystem.WinForms.Forms.Main
{
    partial class FrmMain
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
            this.pnlSidebar = new Panel();
            this.pnlSidebarTop = new Panel();
            this.pnlHeader = new Panel();
            this.pnlContent = new Panel();
            this.pnlUserInfo = new Panel();
            this.lblAppName = new Label();
            this.lblAppSub = new Label();
            this.lblWelcome = new Label();
            this.lblRole = new Label();
            this.lblDate = new Label();
            this.lblUserIcon = new Label();
            this.btnDashboard = new Button();
            this.lblGroupMain = new Label();
            this.btnUsers = new Button();
            this.btnRoles = new Button();
            this.btnSettings = new Button();
            this.btnPaymentMethods = new Button();
            this.btnAuditLog = new Button();
            this.lblGroupInventory = new Label();
            this.btnCategories = new Button();
            this.btnProducts = new Button();
            this.btnBooks = new Button();
            this.btnInventory = new Button();
            this.btnInventoryMovements = new Button();
            this.lblGroupSales = new Label();
            this.btnCustomers = new Button();
            this.btnSaleInvoice = new Button();
            this.btnAllInvoices = new Button();
            this.btnBorrowInvoice = new Button();
            this.btnLateFees = new Button();
            this.btnReturnInvoice = new Button();
            this.btnSaleReturn = new Button();
            this.btnSalesReps = new Button();
            this.btnRepCommissions = new Button();
            this.lblGroupPurchasing = new Label();
            this.btnSuppliers = new Button();
            this.btnExpenses = new Button();
            this.btnSupplierTransactions = new Button();
            this.btnPurchaseInvoice = new Button();
            this.btnExchangeInvoice = new Button();
            this.btnExpenseCategories = new Button();
            this.btnDiscounts = new Button();
            this.btnCoupons = new Button();
            this.btnPromotionalOffers = new Button();

            this.lblGroupAccounting = new Label();
            this.btnAccountTypes = new Button();
            this.btnChartOfAccounts = new Button();
            this.btnAccountBalances = new Button();
            this.btnJournalEntry = new Button();
            this.btnCostCenters = new Button();
            this.btnTrialBalance = new Button();

            this.lblGroupHR = new Label();
            this.btnDepartments = new Button();
            this.btnEmployees = new Button();
            this.btnSalaryComponents = new Button();
            this.btnPayroll = new Button();
            this.btnEmployeeAdvances = new Button();
            this.btnBonuses = new Button();
            this.btnLateFeeRules = new Button();

            this.lblGroupAdvanced = new Label();
            this.btnTaxTypes = new Button();
            this.btnTaxDeclarations = new Button();
            this.btnFixedAssetCategories = new Button();
            this.btnFixedAssets = new Button();
            this.btnAssetDepreciation = new Button();
            this.btnMessageTemplates = new Button();

            this.lblGroupReports = new Label();
            this.btnSalesReports = new Button();
            this.btnInventoryReports = new Button();
            this.btnBorrowReports = new Button();
            this.btnCustomerReports = new Button();
            this.btnSupplierReports = new Button();
            this.btnHRReports = new Button();
            this.btnFinancialReports = new Button();
            this.btnTaxReports = new Button();

            this.pnlLogout = new Panel();
            this.btnLogout = new Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // Form
            this.Text = "Library System";
            this.Size = new Size(1280, 800);
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Font = new Font("Segoe UI", 10f);
            this.Load += new EventHandler(this.FrmMain_Load);

            // pnlSidebar
            this.pnlSidebar.BackColor = Color.FromArgb(22, 32, 50);
            this.pnlSidebar.Location = new Point(0, 0);
            this.pnlSidebar.Size = new Size(240, 2780);
            this.pnlSidebar.AutoScroll = false;
            this.pnlSidebar.HorizontalScroll.Maximum = 0;
            this.pnlSidebar.HorizontalScroll.Visible = false;
            this.pnlSidebar.VerticalScroll.Maximum = 0;
            this.pnlSidebar.VerticalScroll.Visible = false;
            this.pnlSidebar.AutoScroll = true;

            // pnlSidebarTop
            this.pnlSidebarTop.BackColor = Color.FromArgb(15, 22, 38);
            this.pnlSidebarTop.Location = new Point(0, 0);
            this.pnlSidebarTop.Size = new Size(240, 80);

            // lblAppName
            this.lblAppName.Text = "LibrarySystem";
            this.lblAppName.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            this.lblAppName.ForeColor = Color.White;
            this.lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAppName.Location = new Point(0, 12);
            this.lblAppName.Size = new Size(240, 32);

            // lblAppSub
            this.lblAppSub.Text = "Management System";
            this.lblAppSub.Font = new Font("Segoe UI", 8f);
            this.lblAppSub.ForeColor = Color.FromArgb(100, 120, 160);
            this.lblAppSub.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAppSub.Location = new Point(0, 46);
            this.lblAppSub.Size = new Size(240, 20);

            // pnlUserInfo
            this.pnlUserInfo.BackColor = Color.FromArgb(18, 27, 44);
            this.pnlUserInfo.Location = new Point(0, 80);
            this.pnlUserInfo.Size = new Size(240, 70);

            // lblUserIcon
            this.lblUserIcon.Text = "👤";
            this.lblUserIcon.Font = new Font("Segoe UI", 20f);
            this.lblUserIcon.ForeColor = Color.FromArgb(100, 150, 220);
            this.lblUserIcon.Location = new Point(15, 12);
            this.lblUserIcon.Size = new Size(45, 45);

            // lblWelcome
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(65, 18);
            this.lblWelcome.Size = new Size(170, 20);

            // lblRole
            this.lblRole.Text = "Role";
            this.lblRole.Font = new Font("Segoe UI", 8f);
            this.lblRole.ForeColor = Color.FromArgb(100, 150, 220);
            this.lblRole.Location = new Point(65, 40);
            this.lblRole.Size = new Size(170, 18);

            // btnDashboard
            this.btnDashboard.Text = "   🏠   Dashboard";
            this.btnDashboard.Location = new Point(0, 160);
            this.btnDashboard.Size = new Size(240, 42);
            this.btnDashboard.Click += new EventHandler(this.btnDashboard_Click);

            // lblGroupMain
            this.lblGroupMain.Text = "  MAIN";
            this.lblGroupMain.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupMain.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupMain.Location = new Point(15, 212);
            this.lblGroupMain.Size = new Size(210, 22);

            // btnUsers
            this.btnUsers.Text = "   👤   Users";
            this.btnUsers.Location = new Point(0, 234);
            this.btnUsers.Size = new Size(240, 40);
            this.btnUsers.Click += new EventHandler(this.btnUsers_Click);

            // btnRoles
            this.btnRoles.Text = "   🔑   Roles";
            this.btnRoles.Location = new Point(0, 274);
            this.btnRoles.Size = new Size(240, 40);
            this.btnRoles.Click += new EventHandler(this.btnRoles_Click);

            // btnSettings
            this.btnSettings.Text = "   ⚙   Settings";
            this.btnSettings.Location = new Point(0, 314);
            this.btnSettings.Size = new Size(240, 40);
            this.btnSettings.Click += new EventHandler(this.btnSettings_Click);

            // btnPaymentMethods
            this.btnPaymentMethods.Text = "   💳   Payment Methods";
            this.btnPaymentMethods.Location = new Point(0, 354);
            this.btnPaymentMethods.Size = new Size(240, 40);
            this.btnPaymentMethods.Click += new EventHandler(this.btnPaymentMethods_Click);

            // btnAuditLog
            this.btnAuditLog.Text = "   📋   Audit Log";
            this.btnAuditLog.Location = new Point(0, 394);
            this.btnAuditLog.Size = new Size(240, 40);
            this.btnAuditLog.Click += new EventHandler(this.btnAuditLog_Click);

            // lblGroupInventory
            this.lblGroupInventory.Text = "  INVENTORY";
            this.lblGroupInventory.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupInventory.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupInventory.Location = new Point(15, 444);
            this.lblGroupInventory.Size = new Size(210, 22);

            // btnCategories
            this.btnCategories.Text = "   📁   Categories";
            this.btnCategories.Location = new Point(0, 466);
            this.btnCategories.Size = new Size(240, 40);
            this.btnCategories.Click += new EventHandler(this.btnCategories_Click);

            // btnProducts
            this.btnProducts.Text = "   📦   Products";
            this.btnProducts.Location = new Point(0, 506);
            this.btnProducts.Size = new Size(240, 40);
            this.btnProducts.Click += new EventHandler(this.btnProducts_Click);

            // btnBooks
            this.btnBooks.Text = "   📚   Books";
            this.btnBooks.Location = new Point(0, 546);
            this.btnBooks.Size = new Size(240, 40);
            this.btnBooks.Click += new EventHandler(this.btnBooks_Click);

            // btnInventory
            this.btnInventory.Text = "   🏭   Inventory";
            this.btnInventory.Location = new Point(0, 586);
            this.btnInventory.Size = new Size(240, 40);
            this.btnInventory.Click += new EventHandler(this.btnInventory_Click);

            // btnInventoryMovements
            this.btnInventoryMovements.Text = "   📋   Inv. Movements";
            this.btnInventoryMovements.Location = new Point(0, 626);
            this.btnInventoryMovements.Size = new Size(240, 40);
            this.btnInventoryMovements.Click += new EventHandler(this.btnInventoryMovements_Click);

            // lblGroupSales
            this.lblGroupSales.Text = "  SALES";
            this.lblGroupSales.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupSales.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupSales.Location = new Point(15, 676);
            this.lblGroupSales.Size = new Size(210, 22);

            // btnCustomers
            this.btnCustomers.Text = "   👥   Customers";
            this.btnCustomers.Location = new Point(0, 698);
            this.btnCustomers.Size = new Size(240, 40);
            this.btnCustomers.Click += new EventHandler(this.btnCustomers_Click);

            // btnSaleInvoice
            this.btnSaleInvoice.Text = "   🧾   Sale Invoice";
            this.btnSaleInvoice.Location = new Point(0, 738);
            this.btnSaleInvoice.Size = new Size(240, 40);
            this.btnSaleInvoice.Click += new EventHandler(this.btnSaleInvoice_Click);

            // btnAllInvoices
            this.btnAllInvoices.Text = "   🧾   All Invoices";
            this.btnAllInvoices.Location = new Point(0, 778);
            this.btnAllInvoices.Size = new Size(240, 40);
            this.btnAllInvoices.Click += new EventHandler(this.btnAllInvoices_Click);

            // btnBorrowInvoice
            this.btnBorrowInvoice.Text = "   📖   Borrow Invoice";
            this.btnBorrowInvoice.Location = new Point(0, 818);
            this.btnBorrowInvoice.Size = new Size(240, 40);
            this.btnBorrowInvoice.Click += new EventHandler(this.btnBorrowInvoice_Click);

            // btnLateFees
            this.btnLateFees.Text = "   ⏰   Late Fees";
            this.btnLateFees.Location = new Point(0, 858);
            this.btnLateFees.Size = new Size(240, 40);
            this.btnLateFees.Click += new EventHandler(this.btnLateFees_Click);

            // btnReturnInvoice
            this.btnReturnInvoice.Text = "   ↩️   Return Invoice";
            this.btnReturnInvoice.Location = new Point(0, 898);
            this.btnReturnInvoice.Size = new Size(240, 40);
            this.btnReturnInvoice.Click += new EventHandler(this.btnReturnInvoice_Click);

            // btnSaleReturn
            this.btnSaleReturn.Text = "   ↩️   Sale Return";
            this.btnSaleReturn.Location = new Point(0, 938);
            this.btnSaleReturn.Size = new Size(240, 40);
            this.btnSaleReturn.Click += new EventHandler(this.btnSaleReturn_Click);

            // btnSalesReps
            this.btnSalesReps.Text = "   💼   Sales Reps";
            this.btnSalesReps.Location = new Point(0, 978);
            this.btnSalesReps.Size = new Size(240, 40);
            this.btnSalesReps.Click += new EventHandler(this.btnSalesReps_Click);

            // btnRepCommissions
            this.btnRepCommissions.Text = "   💲   Rep Commissions";
            this.btnRepCommissions.Location = new Point(0, 1018);
            this.btnRepCommissions.Size = new Size(240, 40);
            this.btnRepCommissions.Click += new EventHandler(this.btnRepCommissions_Click);

            // lblGroupPurchasing
            this.lblGroupPurchasing.Text = "  PURCHASING";
            this.lblGroupPurchasing.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupPurchasing.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupPurchasing.Location = new Point(15, 1068);
            this.lblGroupPurchasing.Size = new Size(210, 22);

            // btnSuppliers
            this.btnSuppliers.Text = "   🚚   Suppliers";
            this.btnSuppliers.Location = new Point(0, 1090);
            this.btnSuppliers.Size = new Size(240, 40);
            this.btnSuppliers.Click += new EventHandler(this.btnSuppliers_Click);

            // btnSupplierTransactions
            this.btnSupplierTransactions.Text = "   🔄   Supplier Transactions";
            this.btnSupplierTransactions.Location = new Point(0, 1130);
            this.btnSupplierTransactions.Size = new Size(240, 40);
            this.btnSupplierTransactions.Click += new EventHandler(this.btnSupplierTransactions_Click);

            // btnPurchaseInvoice
            this.btnPurchaseInvoice.Text = "   🧾   Purchase Invoice";
            this.btnPurchaseInvoice.Location = new Point(0, 1170);
            this.btnPurchaseInvoice.Size = new Size(240, 40);
            this.btnPurchaseInvoice.Click += new EventHandler(this.btnPurchaseInvoice_Click);

            // btnExchangeInvoice
            this.btnExchangeInvoice.Text = "   🔄   Exchange Invoice";
            this.btnExchangeInvoice.Location = new Point(0, 1210);
            this.btnExchangeInvoice.Size = new Size(240, 40);
            this.btnExchangeInvoice.Click += new EventHandler(this.btnExchangeInvoice_Click);

            // btnExpenseCategories
            this.btnExpenseCategories.Text = "   🗂   Expense Categories";
            this.btnExpenseCategories.Location = new Point(0, 1250);
            this.btnExpenseCategories.Size = new Size(240, 40);
            this.btnExpenseCategories.Click += new EventHandler(this.btnExpenseCategories_Click);

            // btnExpenses
            this.btnExpenses.Text = "   💰   Expenses";
            this.btnExpenses.Location = new Point(0, 1290);
            this.btnExpenses.Size = new Size(240, 40);
            this.btnExpenses.Click += new EventHandler(this.btnExpenses_Click);

            // btnDiscounts
            this.btnDiscounts.Text = "   🏷   Discounts";
            this.btnDiscounts.Location = new Point(0, 1330);
            this.btnDiscounts.Size = new Size(240, 40);
            this.btnDiscounts.Click += new EventHandler(this.btnDiscounts_Click);

            // btnCoupons
            this.btnCoupons.Text = "   🎟   Coupons";
            this.btnCoupons.Location = new Point(0, 1370);
            this.btnCoupons.Size = new Size(240, 40);
            this.btnCoupons.Click += new EventHandler(this.btnCoupons_Click);

            // btnPromotionalOffers
            this.btnPromotionalOffers.Text = "   🎁   Promotional Offers";
            this.btnPromotionalOffers.Location = new Point(0, 1410);
            this.btnPromotionalOffers.Size = new Size(240, 40);
            this.btnPromotionalOffers.Click += new EventHandler(this.btnPromotionalOffers_Click);

            // lblGroupAccounting
            this.lblGroupAccounting.Text = "  ACCOUNTING";
            this.lblGroupAccounting.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupAccounting.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupAccounting.Location = new Point(15, 1460);
            this.lblGroupAccounting.Size = new Size(210, 22);

            // btnAccountTypes
            this.btnAccountTypes.Text = "   📊   Account Types";
            this.btnAccountTypes.Location = new Point(0, 1482);
            this.btnAccountTypes.Size = new Size(240, 40);
            this.btnAccountTypes.Click += new EventHandler(this.btnAccountTypes_Click);

            // btnChartOfAccounts
            this.btnChartOfAccounts.Text = "   📊   Chart of Accounts";
            this.btnChartOfAccounts.Location = new Point(0, 1522);
            this.btnChartOfAccounts.Size = new Size(240, 40);
            this.btnChartOfAccounts.Click += new EventHandler(this.btnChartOfAccounts_Click);

            // btnAccountBalances
            this.btnAccountBalances.Text = "   💹   Account Balances";
            this.btnAccountBalances.Location = new Point(0, 1562);
            this.btnAccountBalances.Size = new Size(240, 40);
            this.btnAccountBalances.Click += new EventHandler(this.btnAccountBalances_Click);

            // btnJournalEntry
            this.btnJournalEntry.Text = "   📝   Journal Entry";
            this.btnJournalEntry.Location = new Point(0, 1602);
            this.btnJournalEntry.Size = new Size(240, 40);
            this.btnJournalEntry.Click += new EventHandler(this.btnJournalEntry_Click);

            // btnCostCenters
            this.btnCostCenters.Text = "   🏷   Cost Centers";
            this.btnCostCenters.Location = new Point(0, 1642);
            this.btnCostCenters.Size = new Size(240, 40);
            this.btnCostCenters.Click += new EventHandler(this.btnCostCenters_Click);

            // btnTrialBalance
            this.btnTrialBalance.Text = "   ⚖   Trial Balance";
            this.btnTrialBalance.Location = new Point(0, 1682);
            this.btnTrialBalance.Size = new Size(240, 40);
            this.btnTrialBalance.Click += new EventHandler(this.btnTrialBalance_Click);

            // lblGroupHR
            this.lblGroupHR.Text = "  HR";
            this.lblGroupHR.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupHR.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupHR.Location = new Point(15, 1732);
            this.lblGroupHR.Size = new Size(210, 22);

            // btnDepartments
            this.btnDepartments.Text = "   🏛   Departments";
            this.btnDepartments.Location = new Point(0, 1754);
            this.btnDepartments.Size = new Size(240, 40);
            this.btnDepartments.Click += new EventHandler(this.btnDepartments_Click);

            // btnEmployees
            this.btnEmployees.Text = "   👨   Employees";
            this.btnEmployees.Location = new Point(0, 1794);
            this.btnEmployees.Size = new Size(240, 40);
            this.btnEmployees.Click += new EventHandler(this.btnEmployees_Click);

            // btnSalaryComponents
            this.btnSalaryComponents.Text = "   💵   Salary Components";
            this.btnSalaryComponents.Location = new Point(0, 1834);
            this.btnSalaryComponents.Size = new Size(240, 40);
            this.btnSalaryComponents.Click += new EventHandler(this.btnSalaryComponents_Click);

            // btnPayroll
            this.btnPayroll.Text = "   💵   Payroll";
            this.btnPayroll.Location = new Point(0, 1874);
            this.btnPayroll.Size = new Size(240, 40);
            this.btnPayroll.Click += new EventHandler(this.btnPayroll_Click);

            // btnEmployeeAdvances
            this.btnEmployeeAdvances.Text = "   💸   Employee Advances";
            this.btnEmployeeAdvances.Location = new Point(0, 1914);
            this.btnEmployeeAdvances.Size = new Size(240, 40);
            this.btnEmployeeAdvances.Click += new EventHandler(this.btnEmployeeAdvances_Click);

            // btnBonuses
            this.btnBonuses.Text = "   🎁   Bonuses";
            this.btnBonuses.Location = new Point(0, 1954);
            this.btnBonuses.Size = new Size(240, 40);
            this.btnBonuses.Click += new EventHandler(this.btnBonuses_Click);

            // btnLateFeeRules
            this.btnLateFeeRules.Text = "   ⏰   Late Fee Rules";
            this.btnLateFeeRules.Location = new Point(0, 1994);
            this.btnLateFeeRules.Size = new Size(240, 40);
            this.btnLateFeeRules.Click += new EventHandler(this.btnLateFeeRules_Click);

            // lblGroupAdvanced
            this.lblGroupAdvanced.Text = "  ADVANCED";
            this.lblGroupAdvanced.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupAdvanced.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupAdvanced.Location = new Point(15, 2044);
            this.lblGroupAdvanced.Size = new Size(210, 22);

            // btnTaxTypes
            this.btnTaxTypes.Text = "   🧾   Tax Types";
            this.btnTaxTypes.Location = new Point(0, 2066);
            this.btnTaxTypes.Size = new Size(240, 40);
            this.btnTaxTypes.Click += new EventHandler(this.btnTaxTypes_Click);

            // btnTaxDeclarations
            this.btnTaxDeclarations.Text = "   🧾   Tax Declarations";
            this.btnTaxDeclarations.Location = new Point(0, 2106);
            this.btnTaxDeclarations.Size = new Size(240, 40);
            this.btnTaxDeclarations.Click += new EventHandler(this.btnTaxDeclarations_Click);

            // btnFixedAssetCategories
            this.btnFixedAssetCategories.Text = "   🏢   Fixed Asset Categories";
            this.btnFixedAssetCategories.Location = new Point(0, 2146);
            this.btnFixedAssetCategories.Size = new Size(240, 40);
            this.btnFixedAssetCategories.Click += new EventHandler(this.btnFixedAssetCategories_Click);

            // btnFixedAssets
            this.btnFixedAssets.Text = "   🏢   Fixed Assets";
            this.btnFixedAssets.Location = new Point(0, 2186);
            this.btnFixedAssets.Size = new Size(240, 40);
            this.btnFixedAssets.Click += new EventHandler(this.btnFixedAssets_Click);

            // btnAssetDepreciation
            this.btnAssetDepreciation.Text = "   📉   Asset Depreciation";
            this.btnAssetDepreciation.Location = new Point(0, 2226);
            this.btnAssetDepreciation.Size = new Size(240, 40);
            this.btnAssetDepreciation.Click += new EventHandler(this.btnAssetDepreciation_Click);

            // btnMessageTemplates
            this.btnMessageTemplates.Text = "   💬   Message Templates";
            this.btnMessageTemplates.Location = new Point(0, 2266);
            this.btnMessageTemplates.Size = new Size(240, 40);
            this.btnMessageTemplates.Click += new EventHandler(this.btnMessageTemplates_Click);

            // lblGroupReports
            this.lblGroupReports.Text = "  REPORTS";
            this.lblGroupReports.ForeColor = Color.FromArgb(80, 100, 140);
            this.lblGroupReports.Font = new Font("Segoe UI", 7.5f, FontStyle.Bold);
            this.lblGroupReports.Location = new Point(15, 2316);
            this.lblGroupReports.Size = new Size(210, 22);

            // btnSalesReports
            this.btnSalesReports.Text = "   📈   Sales Reports";
            this.btnSalesReports.Location = new Point(0, 2338);
            this.btnSalesReports.Size = new Size(240, 40);
            this.btnSalesReports.Click += new EventHandler(this.btnSalesReports_Click);

            // btnInventoryReports
            this.btnInventoryReports.Text = "   📈   Inventory Reports";
            this.btnInventoryReports.Location = new Point(0, 2378);
            this.btnInventoryReports.Size = new Size(240, 40);
            this.btnInventoryReports.Click += new EventHandler(this.btnInventoryReports_Click);

            // btnBorrowReports
            this.btnBorrowReports.Text = "   📈   Borrow Reports";
            this.btnBorrowReports.Location = new Point(0, 2418);
            this.btnBorrowReports.Size = new Size(240, 40);
            this.btnBorrowReports.Click += new EventHandler(this.btnBorrowReports_Click);

            // btnCustomerReports
            this.btnCustomerReports.Text = "   📈   Customer Reports";
            this.btnCustomerReports.Location = new Point(0, 2458);
            this.btnCustomerReports.Size = new Size(240, 40);
            this.btnCustomerReports.Click += new EventHandler(this.btnCustomerReports_Click);

            // btnSupplierReports
            this.btnSupplierReports.Text = "   📈   Supplier Reports";
            this.btnSupplierReports.Location = new Point(0, 2498);
            this.btnSupplierReports.Size = new Size(240, 40);
            this.btnSupplierReports.Click += new EventHandler(this.btnSupplierReports_Click);

            // btnHRReports
            this.btnHRReports.Text = "   📈   HR Reports";
            this.btnHRReports.Location = new Point(0, 2538);
            this.btnHRReports.Size = new Size(240, 40);
            this.btnHRReports.Click += new EventHandler(this.btnHRReports_Click);

            // btnFinancialReports
            this.btnFinancialReports.Text = "   📈   Financial Reports";
            this.btnFinancialReports.Location = new Point(0, 2578);
            this.btnFinancialReports.Size = new Size(240, 40);
            this.btnFinancialReports.Click += new EventHandler(this.btnFinancialReports_Click);

            // btnTaxReports
            this.btnTaxReports.Text = "   📈   Tax Reports";
            this.btnTaxReports.Location = new Point(0, 2618);
            this.btnTaxReports.Size = new Size(240, 40);
            this.btnTaxReports.Click += new EventHandler(this.btnTaxReports_Click);

            // pnlLogout
            this.pnlLogout.BackColor = Color.FromArgb(15, 22, 38);
            this.pnlLogout.Location = new Point(0, 2668);
            this.pnlLogout.Size = new Size(240, 50);

            // btnLogout
            this.btnLogout.Text = "   🚪   Logout";
            this.btnLogout.Location = new Point(0, 0);
            this.btnLogout.Size = new Size(240, 50);
            this.btnLogout.ForeColor = Color.FromArgb(255, 120, 120);
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            // pnlHeader
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Location = new Point(240, 0);
            this.pnlHeader.Size = new Size(1040, 65);

            // lblDate
            this.lblDate.Text = "";
            this.lblDate.Font = new Font("Segoe UI", 9f);
            this.lblDate.ForeColor = Color.FromArgb(120, 130, 150);
            this.lblDate.TextAlign = ContentAlignment.MiddleRight;
            this.lblDate.Location = new Point(700, 20);
            this.lblDate.Size = new Size(320, 25);

            // pnlContent
            this.pnlContent.BackColor = Color.FromArgb(240, 242, 245);
            this.pnlContent.Location = new Point(240, 65);
            this.pnlContent.Size = new Size(1040, 735);

            // Add Controls
            this.pnlSidebarTop.Controls.Add(this.lblAppName);
            this.pnlSidebarTop.Controls.Add(this.lblAppSub);

            this.pnlUserInfo.Controls.Add(this.lblUserIcon);
            this.pnlUserInfo.Controls.Add(this.lblWelcome);
            this.pnlUserInfo.Controls.Add(this.lblRole);

            this.pnlLogout.Controls.Add(this.btnLogout);

            this.pnlSidebar.Controls.Add(this.pnlSidebarTop);
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.lblGroupMain);
            this.pnlSidebar.Controls.Add(this.btnUsers);
            this.pnlSidebar.Controls.Add(this.btnRoles);
            this.pnlSidebar.Controls.Add(this.btnSettings);
            this.pnlSidebar.Controls.Add(this.btnPaymentMethods);
            this.pnlSidebar.Controls.Add(this.btnAuditLog);
            this.pnlSidebar.Controls.Add(this.lblGroupInventory);
            this.pnlSidebar.Controls.Add(this.btnCategories);
            this.pnlSidebar.Controls.Add(this.btnProducts);
            this.pnlSidebar.Controls.Add(this.btnBooks);
            this.pnlSidebar.Controls.Add(this.btnInventory);
            this.pnlSidebar.Controls.Add(this.btnInventoryMovements);
            this.pnlSidebar.Controls.Add(this.lblGroupSales);
            this.pnlSidebar.Controls.Add(this.btnCustomers);
            this.pnlSidebar.Controls.Add(this.btnSaleInvoice);
            this.pnlSidebar.Controls.Add(this.btnAllInvoices);
            this.pnlSidebar.Controls.Add(this.btnBorrowInvoice);
            this.pnlSidebar.Controls.Add(this.btnLateFees);
            this.pnlSidebar.Controls.Add(this.btnReturnInvoice);
            this.pnlSidebar.Controls.Add(this.btnSaleReturn);
            this.pnlSidebar.Controls.Add(this.btnSalesReps);
            this.pnlSidebar.Controls.Add(this.btnRepCommissions);
            this.pnlSidebar.Controls.Add(this.lblGroupPurchasing);
            this.pnlSidebar.Controls.Add(this.btnSuppliers);
            this.pnlSidebar.Controls.Add(this.btnSupplierTransactions);
            this.pnlSidebar.Controls.Add(this.btnPurchaseInvoice);
            this.pnlSidebar.Controls.Add(this.btnExchangeInvoice);
            this.pnlSidebar.Controls.Add(this.btnExpenseCategories);
            this.pnlSidebar.Controls.Add(this.btnExpenses);
            this.pnlSidebar.Controls.Add(this.btnDiscounts);
            this.pnlSidebar.Controls.Add(this.btnCoupons);
            this.pnlSidebar.Controls.Add(this.btnPromotionalOffers);

            this.pnlSidebar.Controls.Add(this.lblGroupAccounting);
            this.pnlSidebar.Controls.Add(this.btnAccountTypes);
            this.pnlSidebar.Controls.Add(this.btnChartOfAccounts);
            this.pnlSidebar.Controls.Add(this.btnAccountBalances);
            this.pnlSidebar.Controls.Add(this.btnJournalEntry);
            this.pnlSidebar.Controls.Add(this.btnCostCenters);
            this.pnlSidebar.Controls.Add(this.btnTrialBalance);

            this.pnlSidebar.Controls.Add(this.lblGroupHR);
            this.pnlSidebar.Controls.Add(this.btnDepartments);
            this.pnlSidebar.Controls.Add(this.btnEmployees);
            this.pnlSidebar.Controls.Add(this.btnSalaryComponents);
            this.pnlSidebar.Controls.Add(this.btnPayroll);
            this.pnlSidebar.Controls.Add(this.btnEmployeeAdvances);
            this.pnlSidebar.Controls.Add(this.btnBonuses);
            this.pnlSidebar.Controls.Add(this.btnLateFeeRules);

            this.pnlSidebar.Controls.Add(this.lblGroupAdvanced);
            this.pnlSidebar.Controls.Add(this.btnTaxTypes);
            this.pnlSidebar.Controls.Add(this.btnTaxDeclarations);
            this.pnlSidebar.Controls.Add(this.btnFixedAssetCategories);
            this.pnlSidebar.Controls.Add(this.btnFixedAssets);
            this.pnlSidebar.Controls.Add(this.btnAssetDepreciation);
            this.pnlSidebar.Controls.Add(this.btnMessageTemplates);

            this.pnlSidebar.Controls.Add(this.lblGroupReports);
            this.pnlSidebar.Controls.Add(this.btnSalesReports);
            this.pnlSidebar.Controls.Add(this.btnInventoryReports);
            this.pnlSidebar.Controls.Add(this.btnBorrowReports);
            this.pnlSidebar.Controls.Add(this.btnCustomerReports);
            this.pnlSidebar.Controls.Add(this.btnSupplierReports);
            this.pnlSidebar.Controls.Add(this.btnHRReports);
            this.pnlSidebar.Controls.Add(this.btnFinancialReports);
            this.pnlSidebar.Controls.Add(this.btnTaxReports);

            this.pnlSidebar.Controls.Add(this.pnlLogout);

            this.pnlHeader.Controls.Add(this.lblDate);

            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlContent);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlSidebar;
        private Panel pnlSidebarTop;
        private Panel pnlHeader;
        private Panel pnlContent;
        private Panel pnlUserInfo;
        private Panel pnlLogout;
        private Label lblAppName;
        private Label lblAppSub;
        private Label lblWelcome;
        private Label lblRole;
        private Label lblDate;
        private Label lblUserIcon;
        private Button btnDashboard;
        private Label lblGroupMain;
        private Button btnUsers;
        private Button btnRoles;
        private Button btnSettings;
        private Button btnPaymentMethods;
        private Button btnAuditLog;
        private Label lblGroupInventory;
        private Button btnCategories;
        private Button btnProducts;
        private Button btnBooks;
        private Button btnInventory;
        private Button btnInventoryMovements;
        private Label lblGroupSales;
        private Button btnCustomers;
        private Button btnSaleInvoice;
        private Button btnAllInvoices;
        private Button btnBorrowInvoice;
        private Button btnLateFees;
        private Button btnReturnInvoice;
        private Button btnSaleReturn;
        private Button btnSalesReps;
        private Button btnRepCommissions;
        private Label lblGroupPurchasing;
        private Button btnSuppliers;
        private Button btnExpenses;
        private Button btnSupplierTransactions;
        private Button btnPurchaseInvoice;
        private Button btnExchangeInvoice;
        private Button btnExpenseCategories;
        private Button btnDiscounts;
        private Button btnCoupons;
        private Button btnPromotionalOffers;

        private Label lblGroupAccounting;
        private Button btnAccountTypes;
        private Button btnChartOfAccounts;
        private Button btnAccountBalances;
        private Button btnJournalEntry;
        private Button btnCostCenters;
        private Button btnTrialBalance;

        private Label lblGroupHR;
        private Button btnDepartments;
        private Button btnEmployees;
        private Button btnSalaryComponents;
        private Button btnPayroll;
        private Button btnEmployeeAdvances;
        private Button btnBonuses;
        private Button btnLateFeeRules;

        private Label lblGroupAdvanced;
        private Button btnTaxTypes;
        private Button btnTaxDeclarations;
        private Button btnFixedAssetCategories;
        private Button btnFixedAssets;
        private Button btnAssetDepreciation;
        private Button btnMessageTemplates;

        private Label lblGroupReports;
        private Button btnSalesReports;
        private Button btnInventoryReports;
        private Button btnBorrowReports;
        private Button btnCustomerReports;
        private Button btnSupplierReports;
        private Button btnHRReports;
        private Button btnFinancialReports;
        private Button btnTaxReports;

        private Button btnLogout;
    }
}