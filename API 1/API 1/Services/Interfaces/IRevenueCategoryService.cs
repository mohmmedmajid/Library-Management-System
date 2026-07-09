using API_1.DTOs.RevenueCategory;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IRevenueCategoryService
    {
        Task<int> CreateAsync(CreateRevenueCategoryDTO dto);
        Task<bool> UpdateAsync(UpdateRevenueCategoryDTO dto);
        Task<bool> DeleteAsync(int categoryId);
        Task<RevenueCategory?> GetByIdAsync(int categoryId);
        Task<List<RevenueCategory>> GetAllAsync(bool? isActive = null);
        Task<List<RevenueCategory>> GetWithTotalsAsync(GetCategoriesWithTotalsDTO dto);
    }
}