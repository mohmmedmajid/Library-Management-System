using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IFixedAssetCategoryRepository
    {
        Task<int> InsertAsync(FixedAssetCategory category);
        Task<bool> UpdateAsync(FixedAssetCategory category);
        Task<bool> DeleteAsync(int categoryId);
        Task<FixedAssetCategory?> GetByIdAsync(int categoryId);
        Task<List<FixedAssetCategory>> GetAllAsync(bool? isActive = null);
    }
}
