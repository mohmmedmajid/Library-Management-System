using API_1.DTOs.FixedAssetCategory;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IFixedAssetCategoryService
    {
        Task<int> CreateAsync(CreateFixedAssetCategoryDTO dto);
        Task<bool> UpdateAsync(UpdateFixedAssetCategoryDTO dto);
        Task<bool> DeleteAsync(int categoryId);
        Task<FixedAssetCategory?> GetByIdAsync(int categoryId);
        Task<List<FixedAssetCategory>> GetAllAsync(bool? isActive = null);
    }
}
