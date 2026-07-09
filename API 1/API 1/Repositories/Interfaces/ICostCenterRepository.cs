using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ICostCenterRepository
    {
        Task<int> InsertAsync(CostCenter costCenter);
        Task<bool> UpdateAsync(CostCenter costCenter);
        Task<bool> DeleteAsync(int costCenterId);
        Task<CostCenter?> GetByIdAsync(int costCenterId);
        Task<List<CostCenter>> GetAllAsync(bool? isActive = null);
    }
}