using API_1.Data;
using API_1.Repositories;
using API_1.Repositories.Interfaces;
using API_1.Services;
using API_1.Services.Interfaces;
using API_1.Models;
using API.Application.Services.Interfaces;
using API.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// ===================================
// Add services to the container
// ===================================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;

        options.JsonSerializerOptions.WriteIndented = true;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSingleton<DatabaseHelper>();

//1
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISystemSettingRepository, SystemSettingRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryMovementRepository, InventoryMovementRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();

//2
builder.Services.AddScoped<IInvoiceTypeRepository, InvoiceTypeRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
builder.Services.AddScoped<ICustomerTransactionRepository, CustomerTransactionRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBarcodeRepository, BarcodeRepository>();
builder.Services.AddScoped<IBorrowingTransactionRepository, BorrowingTransactionRepository>();
builder.Services.AddScoped<IBorrowingDetailRepository, BorrowingDetailRepository>();
builder.Services.AddScoped<IReturnTransactionRepository, ReturnTransactionRepository>();
builder.Services.AddScoped<ILateFeeRepository, LateFeeRepository>();
builder.Services.AddScoped<ISalesRepresentativeRepository, SalesRepresentativeRepository>();
builder.Services.AddScoped<IRepCommissionRepository, RepCommissionRepository>();

//3
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierTransactionRepository, SupplierTransactionRepository>();
builder.Services.AddScoped<IExpenseCategoryRepository, ExpenseCategoryRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IRevenueCategoryRepository, RevenueCategoryRepository>();
builder.Services.AddScoped<IOtherRevenueRepository, OtherRevenueRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<IPromotionalOfferRepository, PromotionalOfferRepository>();
builder.Services.AddScoped<IDiscountUsageLogRepository, DiscountUsageLogRepository>();

//4
builder.Services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();
builder.Services.AddScoped<IChartOfAccountRepository, ChartOfAccountRepository>();
builder.Services.AddScoped<IAccountBalanceRepository, AccountBalanceRepository>();
builder.Services.AddScoped<ICostCenterRepository, CostCenterRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IJournalEntryRepository, JournalEntryRepository>();
builder.Services.AddScoped<IJournalEntryDetailRepository, JournalEntryDetailRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISalaryComponentRepository, SalaryComponentRepository>();
builder.Services.AddScoped<IEmployeeSalaryComponentRepository, EmployeeSalaryComponentRepository>();
builder.Services.AddScoped<IPayrollRepository, PayrollRepository>();
builder.Services.AddScoped<IPayrollDetailRepository, PayrollDetailRepository>();
builder.Services.AddScoped<IEmployeeAdvanceRepository, EmployeeAdvanceRepository>();
builder.Services.AddScoped<IBonusRepository, BonusRepository>();
builder.Services.AddScoped<ILateFeeRuleRepository, LateFeeRuleRepository>();

//5
builder.Services.AddScoped<ITaxTypeRepository, TaxTypeRepository>();
builder.Services.AddScoped<IInvoiceTaxRepository, InvoiceTaxRepository>();
builder.Services.AddScoped<ITaxDeclarationRepository, TaxDeclarationRepository>();
builder.Services.AddScoped<IFixedAssetCategoryRepository, FixedAssetCategoryRepository>();
builder.Services.AddScoped<IFixedAssetRepository, FixedAssetRepository>();
builder.Services.AddScoped<IAssetDepreciationRepository, AssetDepreciationRepository>();
builder.Services.AddScoped<ILoginAttemptRepository, LoginAttemptRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IMessageTemplateRepository, MessageTemplateRepository>();

//


//1
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISystemSettingService, SystemSettingService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IInventoryMovementService, InventoryMovementService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

//2
builder.Services.AddScoped<IInvoiceTypeService, InvoiceTypeService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();
builder.Services.AddScoped<ICustomerTransactionService, CustomerTransactionService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBarcodeService, BarcodeService>();
builder.Services.AddScoped<IBorrowingTransactionService, BorrowingTransactionService>();
builder.Services.AddScoped<IBorrowingDetailService, BorrowingDetailService>();
builder.Services.AddScoped<IReturnTransactionService, ReturnTransactionService>();
builder.Services.AddScoped<ILateFeeService, LateFeeService>();
builder.Services.AddScoped<ISalesRepresentativeService, SalesRepresentativeService>();
builder.Services.AddScoped<IRepCommissionService, RepCommissionService>();

//3
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ISupplierTransactionService, SupplierTransactionService>();
builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IRevenueCategoryService, RevenueCategoryService>();
builder.Services.AddScoped<IOtherRevenueService, OtherRevenueService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IPromotionalOfferService, PromotionalOfferService>();
builder.Services.AddScoped<IDiscountUsageLogService, DiscountUsageLogService>();

//4
builder.Services.AddScoped<IAccountTypeService, AccountTypeService>();
builder.Services.AddScoped<IChartOfAccountService, ChartOfAccountService>();
builder.Services.AddScoped<IAccountBalanceService, AccountBalanceService>();
builder.Services.AddScoped<ICostCenterService, CostCenterService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IJournalEntryService, JournalEntryService>();
builder.Services.AddScoped<IJournalEntryDetailService, JournalEntryDetailService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<ISalaryComponentService, SalaryComponentService>();
builder.Services.AddScoped<IEmployeeSalaryComponentService, EmployeeSalaryComponentService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();
builder.Services.AddScoped<IPayrollDetailService, PayrollDetailService>();
builder.Services.AddScoped<IEmployeeAdvanceService, EmployeeAdvanceService>();
builder.Services.AddScoped<IBonusService, BonusService>();
builder.Services.AddScoped<ILateFeeRuleService, LateFeeRuleService>();

//5
builder.Services.AddScoped<ITaxTypeService, TaxTypeService>();
builder.Services.AddScoped<IInvoiceTaxService, InvoiceTaxService>();
builder.Services.AddScoped<ITaxDeclarationService, TaxDeclarationService>();
builder.Services.AddScoped<IFixedAssetCategoryService, FixedAssetCategoryService>();
builder.Services.AddScoped<IFixedAssetService, FixedAssetService>();
builder.Services.AddScoped<IAssetDepreciationService, AssetDepreciationService>();
builder.Services.AddScoped<ILoginAttemptService, LoginAttemptService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IMessageTemplateService, MessageTemplateService>();

// 6
builder.Services.AddScoped<ISaleReturnRepository, SaleReturnRepository>();
builder.Services.AddScoped<IExchangeRepository, ExchangeRepository>();
builder.Services.AddScoped<IInvoiceSearchRepository, InvoiceSearchRepository>();
builder.Services.AddScoped<ISaleReturnService, SaleReturnService>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();
builder.Services.AddScoped<IAllInvoicesService, AllInvoicesService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();