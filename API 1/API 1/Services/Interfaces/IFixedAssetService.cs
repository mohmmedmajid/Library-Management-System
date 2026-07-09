using API_1.DTOs.FixedAsset;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IFixedAssetService
    {
        Task<int> CreateAsync(CreateFixedAssetDTO dto);
        Task<bool> UpdateAsync(UpdateFixedAssetDTO dto);
        Task<bool> DisposeAsync(DisposeFixedAssetDTO dto);
        Task<FixedAsset?> GetByIdAsync(int assetId);
        Task<List<FixedAsset>> GetAllAsync(GetAllFixedAssetsDTO dto);
        Task<List<FixedAsset>> GetDueForMaintenanceAsync();
        Task<List<FixedAsset>> GetSummaryAsync();
    }
}
