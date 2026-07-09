using API_1.DTOs.Category;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<int> CreateAsync(CreateCategoryDTO dto);
        Task<bool> UpdateAsync(UpdateCategoryDTO dto);
        Task<bool> DeleteAsync(int categoryId);
        Task<Category?> GetByIdAsync(int categoryId);
        Task<List<Category>> GetAllAsync(bool? isActive = null);
        Task<List<Category>> GetWithProductCountAsync();
    }
}