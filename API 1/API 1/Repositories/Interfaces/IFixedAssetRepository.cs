using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IFixedAssetRepository
    {
        Task<int> InsertAsync(FixedAsset asset);
        Task<bool> UpdateAsync(FixedAsset asset);
        Task<bool> DisposeAsync(int assetId, DateTime disposalDate, decimal disposalValue, string? notes);
        Task<FixedAsset?> GetByIdAsync(int assetId);
        Task<List<FixedAsset>> GetAllAsync(int? categoryId = null, string? status = null, int? responsibleEmployee = null);
        Task<List<FixedAsset>> GetDueForMaintenanceAsync();
        Task<List<FixedAsset>> GetSummaryAsync();
    }
}
