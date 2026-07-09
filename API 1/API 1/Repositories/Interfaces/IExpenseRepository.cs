using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<int> InsertAsync(Expense expense);
        Task<bool> UpdateAsync(Expense expense);
        Task<bool> DeleteAsync(int expenseId);
        Task<Expense?> GetByIdAsync(int expenseId);
        Task<List<Expense>> GetAllAsync(int? categoryId = null, int? supplierId = null, string? status = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<Expense>> GetByCategoryAsync(int categoryId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<Expense>> GetBySupplierAsync(int supplierId, DateTime? startDate = null, DateTime? endDate = null);
        Task<(decimal TotalAmount, int TotalCount)> GetSummaryAsync(DateTime startDate, DateTime endDate);
        Task<bool> ApproveExpenseAsync(int expenseId, int approvedBy);
        Task<List<Expense>> GetRecurringExpensesAsync();
    }
}