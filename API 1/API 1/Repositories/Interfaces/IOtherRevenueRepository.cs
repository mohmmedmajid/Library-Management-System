using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IOtherRevenueRepository
    {
        Task<int> InsertAsync(OtherRevenue revenue);
        Task<bool> UpdateAsync(OtherRevenue revenue);
        Task<bool> DeleteAsync(int revenueId);
        Task<OtherRevenue?> GetByIdAsync(int revenueId);
        Task<List<OtherRevenue>> GetAllAsync(int? categoryId = null, int? customerId = null, string? status = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<OtherRevenue>> GetByCategoryAsync(int categoryId, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<OtherRevenue>> GetByCustomerAsync(int customerId, DateTime? startDate = null, DateTime? endDate = null);
        Task<(decimal TotalAmount, int TotalCount)> GetSummaryAsync(DateTime startDate, DateTime endDate);
        Task<List<OtherRevenue>> GetRecurringRevenuesAsync();
    }
}