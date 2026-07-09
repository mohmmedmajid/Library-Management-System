using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IRepCommissionRepository
    {
        Task<int> InsertAsync(RepCommission commission);
        Task<bool> UpdateAsync(RepCommission commission);
        Task<bool> DeleteAsync(int commissionId);
        Task<RepCommission?> GetByIdAsync(int commissionId);
        Task<List<RepCommission>> GetBySalesRepAsync(int salesRepId, bool? isPaid = null,
            DateTime? startDate = null, DateTime? endDate = null);
        Task<List<RepCommission>> GetAllAsync(bool? isPaid = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<bool> MarkAsPaidAsync(int commissionId);
        Task<Dictionary<string, object>?> GetUnpaidTotalAsync(int salesRepId);
    }
}
