using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IRevenueCategoryRepository
    {
        Task<int> InsertAsync(RevenueCategory category);
        Task<bool> UpdateAsync(RevenueCategory category);
        Task<bool> DeleteAsync(int categoryId);
        Task<RevenueCategory?> GetByIdAsync(int categoryId);
        Task<List<RevenueCategory>> GetAllAsync(bool? isActive = null);
        Task<List<RevenueCategory>> GetWithTotalsAsync(DateTime? startDate = null, DateTime? endDate = null);
    }
}