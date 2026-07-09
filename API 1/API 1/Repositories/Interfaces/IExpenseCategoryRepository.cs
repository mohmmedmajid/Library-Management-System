using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<int> InsertAsync(ExpenseCategory category);
        Task<bool> UpdateAsync(ExpenseCategory category);
        Task<bool> DeleteAsync(int categoryId);
        Task<ExpenseCategory?> GetByIdAsync(int categoryId);
        Task<List<ExpenseCategory>> GetAllAsync(bool? isActive = null);
        Task<List<ExpenseCategory>> GetWithTotalsAsync(DateTime? startDate = null, DateTime? endDate = null);
    }
}