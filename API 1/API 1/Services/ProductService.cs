using API_1.DTOs.Product;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateAsync(CreateProductDTO dto)
        {

            if (string.IsNullOrWhiteSpace(dto.ProductName))
                throw new ArgumentException("Product name is required");

            if (string.IsNullOrWhiteSpace(dto.ProductNameAr))
                throw new ArgumentException("Product name (Arabic) is required");

            if (dto.UnitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero");

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryID);
            if (category == null)
                throw new Exception("Category not found");

            if (!category.IsActive)
                throw new Exception("Category is not active");

            var product = new Product
            {
                ProductName = dto.ProductName.Trim(),
                ProductNameAr = dto.ProductNameAr.Trim(),
                CategoryID = dto.CategoryID,
                Barcode = dto.Barcode?.Trim(),
                UnitPrice = dto.UnitPrice,
                CostPrice = dto.CostPrice,
                Description = dto.Description?.Trim(),
                ProductType = dto.ProductType,
                CreatedBy = dto.CreatedBy
            };

            return await _productRepository.InsertAsync(product);
        }


        public async Task<bool> UpdateAsync(UpdateProductDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ProductName))
                throw new ArgumentException("Product name is required");

            if (string.IsNullOrWhiteSpace(dto.ProductNameAr))
                throw new ArgumentException("Product name (Arabic) is required");

            if (dto.UnitPrice <= 0)
                throw new ArgumentException("Unit price must be greater than zero");

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryID);
            if (category == null)
                throw new Exception("Category not found");

            var product = new Product
            {
                ProductID = dto.ProductID,
                ProductName = dto.ProductName.Trim(),
                ProductNameAr = dto.ProductNameAr.Trim(),
                CategoryID = dto.CategoryID,
                Barcode = dto.Barcode?.Trim(),
                UnitPrice = dto.UnitPrice,
                CostPrice = dto.CostPrice,
                Description = dto.Description?.Trim(),
                ProductType = dto.ProductType,
                IsActive = dto.IsActive
            };

            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found");

            return await _productRepository.DeleteAsync(productId);
        }

 
        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }

     
        public async Task<List<Product>> GetAllAsync(bool? isActive = null, int? categoryId = null)
        {
            return await _productRepository.GetAllAsync(isActive, categoryId);
        }

       
        public async Task<List<Product>> SearchAsync(SearchProductDTO dto)
        {
          
            if (string.IsNullOrWhiteSpace(dto.SearchTerm))
                throw new ArgumentException("Search term is required");

            return await _productRepository.SearchAsync(dto.SearchTerm.Trim());
        }


        public async Task<Product?> GetByBarcodeAsync(GetProductByBarcodeDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.Barcode))
                throw new ArgumentException("Barcode is required");

            return await _productRepository.GetByBarcodeAsync(dto.Barcode.Trim());
        }
    }
}