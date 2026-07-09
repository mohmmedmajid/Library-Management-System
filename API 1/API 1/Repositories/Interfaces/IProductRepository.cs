using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<int> InsertAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int productId);
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> GetAllAsync(bool? isActive = null, int? categoryId = null);
        Task<List<Product>> SearchAsync(string searchTerm);
        Task<Product?> GetByBarcodeAsync(string barcode);
    }
}