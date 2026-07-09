using API_1.DTOs.CostCenter;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ICostCenterService
    {
        Task<int> CreateAsync(CreateCostCenterDTO dto);
        Task<bool> UpdateAsync(UpdateCostCenterDTO dto);
        Task<bool> DeleteAsync(int costCenterId);
        Task<CostCenter?> GetByIdAsync(int costCenterId);
        Task<List<CostCenter>> GetAllAsync(bool? isActive = null);
    }
}