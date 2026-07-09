using API_1.DTOs.AssetDepreciation;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IAssetDepreciationService
    {
        Task<int> CreateAsync(CreateAssetDepreciationDTO dto);
        Task<bool> PostAsync(PostAssetDepreciationDTO dto);
        Task<bool> ProcessMonthlyAsync(ProcessMonthlyDepreciationDTO dto);
        Task<AssetDepreciation?> GetByIdAsync(int depreciationId);
        Task<List<AssetDepreciation>> GetByAssetAsync(GetDepreciationByAssetDTO dto);
        Task<List<AssetDepreciation>> GetAllAsync(GetAllDepreciationsDTO dto);
        Task<List<AssetDepreciation>> GetSummaryAsync(GetDepreciationSummaryDTO dto);
    }
}
