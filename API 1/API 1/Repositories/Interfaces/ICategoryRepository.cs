using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> InsertAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int categoryId);
        Task<Category?> GetByIdAsync(int categoryId);
        Task<List<Category>> GetAllAsync(bool? isActive = null);
        Task<List<Category>> GetWithProductCountAsync();
    }
}