using API_1.DTOs.Expense;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseCategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;

        public ExpenseService(
            IExpenseRepository expenseRepository,
            IExpenseCategoryRepository categoryRepository,
            ISupplierRepository supplierRepository)
        {
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }

        public async Task<int> CreateAsync(CreateExpenseDTO dto)
        {
            await ValidateExpenseDTO(dto);

            var expense = new Expense
            {
                ExpenseCategoryID = dto.ExpenseCategoryID,
                ExpenseDate = dto.ExpenseDate,
                Amount = dto.Amount,
                PaymentMethodID = dto.PaymentMethodID,
                ReferenceNumber = dto.ReferenceNumber?.Trim(),
                Description = dto.Description?.Trim(),
                SupplierID = dto.SupplierID,
                ReceiptNumber = dto.ReceiptNumber?.Trim(),
                IsRecurring = dto.IsRecurring,
                RecurringPeriod = dto.RecurringPeriod?.Trim(),
                ApprovedBy = dto.ApprovedBy,
                Status = dto.Status?.Trim() ?? "Pending",
                CreatedBy = dto.CreatedBy
            };

            return await _expenseRepository.InsertAsync(expense);
        }

        public async Task<bool> UpdateAsync(UpdateExpenseDTO dto)
        {
            if (dto.ExpenseID <= 0)
                throw new ArgumentException("Invalid expense ID");

            await ValidateExpenseDTO(new CreateExpenseDTO
            {
                ExpenseCategoryID = dto.ExpenseCategoryID,
                Amount = dto.Amount,
                PaymentMethodID = dto.PaymentMethodID,
                ExpenseDate = dto.ExpenseDate
            });

            var existing = await _expenseRepository.GetByIdAsync(dto.ExpenseID);
            if (existing == null)
                throw new InvalidOperationException("Expense not found");

            if (existing.Status == "Cancelled")
                throw new InvalidOperationException("Cannot update a cancelled expense");

            var expense = new Expense
            {
                ExpenseID = dto.ExpenseID,
                ExpenseCategoryID = dto.ExpenseCategoryID,
                ExpenseDate = dto.ExpenseDate,
                Amount = dto.Amount,
                PaymentMethodID = dto.PaymentMethodID,
                ReferenceNumber = dto.ReferenceNumber?.Trim(),
                Description = dto.Description?.Trim(),
                SupplierID = dto.SupplierID,
                ReceiptNumber = dto.ReceiptNumber?.Trim(),
                Status = dto.Status.Trim()
            };

            return await _expenseRepository.UpdateAsync(expense);
        }

        public async Task<bool> DeleteAsync(int expenseId)
        {
            if (expenseId <= 0)
                throw new ArgumentException("Invalid expense ID");

            var existing = await _expenseRepository.GetByIdAsync(expenseId);
            if (existing == null)
                throw new InvalidOperationException("Expense not found");

            return await _expenseRepository.DeleteAsync(expenseId);
        }

        public async Task<Expense?> GetByIdAsync(int expenseId)
        {
            if (expenseId <= 0)
                throw new ArgumentException("Invalid expense ID");

            return await _expenseRepository.GetByIdAsync(expenseId);
        }

        public async Task<List<Expense>> GetAllAsync(GetAllExpensesDTO dto)
        {
            return await _expenseRepository.GetAllAsync(
                dto.ExpenseCategoryID,
                dto.SupplierID,
                dto.Status,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<Expense>> GetRecurringExpensesAsync()
        {
            return await _expenseRepository.GetRecurringExpensesAsync();
        }

        public async Task<bool> ApproveExpenseAsync(ApproveExpenseDTO dto)
        {
            if (dto.ExpenseID <= 0)
                throw new ArgumentException("Invalid expense ID");

            if (dto.ApprovedBy <= 0)
                throw new ArgumentException("Invalid approver ID");

            var existing = await _expenseRepository.GetByIdAsync(dto.ExpenseID);
            if (existing == null)
                throw new InvalidOperationException("Expense not found");

            if (existing.Status == "Paid")
                throw new InvalidOperationException("Expense is already paid");

            if (existing.Status == "Cancelled")
                throw new InvalidOperationException("Cannot approve a cancelled expense");

            return await _expenseRepository.ApproveExpenseAsync(dto.ExpenseID, dto.ApprovedBy);
        }

        public async Task<(decimal TotalAmount, int TotalCount)> GetExpenseSummaryAsync(GetExpenseSummaryDTO dto)
        {
            if (dto.EndDate < dto.StartDate)
                throw new ArgumentException("End date must be after start date");

            return await _expenseRepository.GetSummaryAsync(dto.StartDate, dto.EndDate);
        }

        public async Task<List<Expense>> GetPendingExpensesAsync()
        {
            var allExpenses = await _expenseRepository.GetAllAsync(
                categoryId: null,
                supplierId: null,
                status: "Pending",
                startDate: null,
                endDate: null
            );

            return allExpenses;
        }

        private async Task ValidateExpenseDTO(CreateExpenseDTO dto)
        {
            if (dto.ExpenseCategoryID <= 0)
                throw new ArgumentException("Invalid expense category ID");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (dto.PaymentMethodID <= 0)
                throw new ArgumentException("Invalid payment method ID");

            if (dto.ExpenseDate > DateTime.Now)
                throw new ArgumentException("Expense date cannot be in the future");

            var category = await _categoryRepository.GetByIdAsync(dto.ExpenseCategoryID);
            if (category == null)
                throw new InvalidOperationException("Expense category not found");

            if (!category.IsActive)
                throw new InvalidOperationException("This expense category is not active");

            if (dto.SupplierID.HasValue && dto.SupplierID > 0)
            {
                var supplier = await _supplierRepository.GetByIdAsync(dto.SupplierID.Value);
                if (supplier == null)
                    throw new InvalidOperationException("Supplier not found");

                if (!supplier.IsActive)
                    throw new InvalidOperationException("This supplier is not active");
            }

            if (!string.IsNullOrWhiteSpace(dto.Status))
            {
                ValidateStatus(dto.Status);
            }

            if (dto.IsRecurring && !string.IsNullOrWhiteSpace(dto.RecurringPeriod))
            {
                ValidateRecurringPeriod(dto.RecurringPeriod);
            }
        }

        private void ValidateStatus(string status)
        {
            var validStatuses = new[] { "Pending", "Paid", "Cancelled" };
            if (!validStatuses.Contains(status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");
        }

        private void ValidateRecurringPeriod(string period)
        {
            var validPeriods = new[] { "Monthly", "Quarterly", "Yearly" };
            if (!validPeriods.Contains(period.Trim()))
                throw new ArgumentException($"Invalid recurring period. Must be one of: {string.Join(", ", validPeriods)}");
        }
    }
}