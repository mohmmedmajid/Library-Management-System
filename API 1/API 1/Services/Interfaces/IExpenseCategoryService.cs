using API_1.DTOs.ExpenseCategory;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IExpenseCategoryService
    {
        Task<int> CreateAsync(CreateExpenseCategoryDTO dto);
        Task<bool> UpdateAsync(UpdateExpenseCategoryDTO dto);
        Task<bool> DeleteAsync(int categoryId);
        Task<ExpenseCategory?> GetByIdAsync(int categoryId);
        Task<List<ExpenseCategory>> GetAllAsync(bool? isActive = null);
        Task<List<ExpenseCategory>> GetWithTotalsAsync(GetCategoriesWithTotalsDTO dto);
    }
}