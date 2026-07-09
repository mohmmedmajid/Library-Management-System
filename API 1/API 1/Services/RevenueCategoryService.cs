using API_1.DTOs.RevenueCategory;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class RevenueCategoryService : IRevenueCategoryService
    {
        private readonly IRevenueCategoryRepository _categoryRepository;

        public RevenueCategoryService(IRevenueCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateAsync(CreateRevenueCategoryDTO dto)
        {
            ValidateCategoryDTO(dto);

            await CheckDuplicateCategoryName(dto.CategoryName);

            var category = new RevenueCategory
            {
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _categoryRepository.InsertAsync(category);
        }

        public async Task<bool> UpdateAsync(UpdateRevenueCategoryDTO dto)
        {
            if (dto.RevenueCategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            ValidateCategoryDTO(new CreateRevenueCategoryDTO
            {
                CategoryName = dto.CategoryName,
                CategoryNameAr = dto.CategoryNameAr
            });

            var existing = await _categoryRepository.GetByIdAsync(dto.RevenueCategoryID);
            if (existing == null)
                throw new InvalidOperationException("Category not found");

            await CheckDuplicateCategoryName(dto.CategoryName, dto.RevenueCategoryID);

            var category = new RevenueCategory
            {
                RevenueCategoryID = dto.RevenueCategoryID,
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _categoryRepository.UpdateAsync(category);
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Invalid category ID");

            var existing = await _categoryRepository.GetByIdAsync(categoryId);
            if (existing == null)
                throw new InvalidOperationException("Category not found");

            return await _categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<RevenueCategory?> GetByIdAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Invalid category ID");

            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task<List<RevenueCategory>> GetAllAsync(bool? isActive = null)
        {
            return await _categoryRepository.GetAllAsync(isActive);
        }

        public async Task<List<RevenueCategory>> GetWithTotalsAsync(GetCategoriesWithTotalsDTO dto)
        {
            return await _categoryRepository.GetWithTotalsAsync(dto.StartDate, dto.EndDate);
        }

        private void ValidateCategoryDTO(CreateRevenueCategoryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CategoryName))
                throw new ArgumentException("Category name is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryNameAr))
                throw new ArgumentException("Category name in Arabic is required");

            if (dto.CategoryName.Trim().Length < 2)
                throw new ArgumentException("Category name must be at least 2 characters");

            if (dto.CategoryNameAr.Trim().Length < 2)
                throw new ArgumentException("Category name in Arabic must be at least 2 characters");
        }

        private async Task CheckDuplicateCategoryName(string categoryName, int? excludeId = null)
        {
            var existing = await _categoryRepository.GetAllAsync(true);

            var duplicate = existing.FirstOrDefault(c =>
                c.CategoryName.Equals(categoryName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                (!excludeId.HasValue || c.RevenueCategoryID != excludeId.Value));

            if (duplicate != null)
                throw new InvalidOperationException("A category with this name already exists");
        }
    }
}