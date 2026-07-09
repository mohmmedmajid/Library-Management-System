using API_1.DTOs.Product;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateAsync(CreateProductDTO dto);
        Task<bool> UpdateAsync(UpdateProductDTO dto);
        Task<bool> DeleteAsync(int productId);
        Task<Product?> GetByIdAsync(int productId);
        Task<List<Product>> GetAllAsync(bool? isActive = null, int? categoryId = null);
        Task<List<Product>> SearchAsync(SearchProductDTO dto);
        Task<Product?> GetByBarcodeAsync(GetProductByBarcodeDTO dto);
    }
}