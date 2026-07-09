using API_1.Models;
using API_1.DTOs.RepCommission;

namespace API_1.Services.Interfaces
{
    public interface IRepCommissionService
    {
        Task<int> CreateAsync(CreateRepCommissionDTO dto);
        Task<bool> UpdateAsync(UpdateRepCommissionDTO dto);
        Task<bool> DeleteAsync(int commissionId);
        Task<RepCommission?> GetByIdAsync(int commissionId);
        Task<List<RepCommission>> GetBySalesRepAsync(GetCommissionsBySalesRepDTO dto);
        Task<List<RepCommission>> GetAllAsync(GetAllCommissionsDTO dto);
        Task<bool> MarkAsPaidAsync(int commissionId);
        Task<Dictionary<string, object>?> GetUnpaidTotalAsync(int salesRepId);
    }
}
