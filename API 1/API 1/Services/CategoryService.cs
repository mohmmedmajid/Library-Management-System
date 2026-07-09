using API_1.DTOs.Category;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

       
        public async Task<int> CreateAsync(CreateCategoryDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.CategoryName))
                throw new ArgumentException("Category name is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryNameAr))
                throw new ArgumentException("Category name (Arabic) is required");

            
            var category = new Category
            {
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

           
            return await _categoryRepository.InsertAsync(category);
        }

        
        public async Task<bool> UpdateAsync(UpdateCategoryDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.CategoryName))
                throw new ArgumentException("Category name is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryNameAr))
                throw new ArgumentException("Category name (Arabic) is required");

            
            var category = new Category
            {
                CategoryID = dto.CategoryID,
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

           
            return await _categoryRepository.UpdateAsync(category);
        }

        
        public async Task<bool> DeleteAsync(int categoryId)
        {
            
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                throw new Exception("Category not found");

            
            return await _categoryRepository.DeleteAsync(categoryId);
        }

  
        public async Task<Category?> GetByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
        }

      
        public async Task<List<Category>> GetAllAsync(bool? isActive = null)
        {
            return await _categoryRepository.GetAllAsync(isActive);
        }

     
        public async Task<List<Category>> GetWithProductCountAsync()
        {
            return await _categoryRepository.GetWithProductCountAsync();
        }
    }
}