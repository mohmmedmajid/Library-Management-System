using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IAssetDepreciationRepository
    {
        Task<int> CreateAsync(AssetDepreciation depreciation);
        Task<bool> PostAsync(int depreciationId, int postedBy);
        Task<bool> ProcessMonthlyAsync(int fiscalYear, int fiscalMonth, int createdBy);
        Task<AssetDepreciation?> GetByIdAsync(int depreciationId);
        Task<List<AssetDepreciation>> GetByAssetAsync(int assetId);
        Task<List<AssetDepreciation>> GetAllAsync(int? fiscalYear = null, int? fiscalMonth = null, string? status = null);
        Task<List<AssetDepreciation>> GetSummaryAsync(int fiscalYear);
    }
}
