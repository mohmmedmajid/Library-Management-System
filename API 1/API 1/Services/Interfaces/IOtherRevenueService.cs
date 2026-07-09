using API_1.DTOs.OtherRevenue;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IOtherRevenueService
    {
        Task<int> CreateAsync(CreateOtherRevenueDTO dto);
        Task<bool> UpdateAsync(UpdateOtherRevenueDTO dto);
        Task<bool> DeleteAsync(int revenueId);
        Task<OtherRevenue?> GetByIdAsync(int revenueId);
        Task<List<OtherRevenue>> GetAllAsync(GetAllRevenuesDTO dto);
        Task<List<OtherRevenue>> GetRecurringRevenuesAsync();
        Task<(decimal TotalAmount, int TotalCount)> GetRevenueSummaryAsync(GetRevenueSummaryDTO dto);
        Task<List<OtherRevenue>> GetPendingRevenuesAsync();
    }
}