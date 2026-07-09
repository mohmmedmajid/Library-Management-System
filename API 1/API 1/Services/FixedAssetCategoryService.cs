using API_1.DTOs.FixedAssetCategory;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class FixedAssetCategoryService : IFixedAssetCategoryService
    {
        private readonly IFixedAssetCategoryRepository _categoryRepository;

        public FixedAssetCategoryService(IFixedAssetCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateAsync(CreateFixedAssetCategoryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.CategoryCode))
                throw new ArgumentException("Category code is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryName))
                throw new ArgumentException("Category name is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryNameAr))
                throw new ArgumentException("Category name in Arabic is required");

            var validMethods = new[] { "StraightLine", "DecliningBalance", "UnitsOfProduction" };
            if (!validMethods.Contains(dto.DepreciationMethod.Trim()))
                throw new ArgumentException($"Invalid depreciation method. Must be one of: {string.Join(", ", validMethods)}");

            if (dto.UsefulLifeYears <= 0)
                throw new ArgumentException("Useful life years must be greater than zero");

            if (dto.AnnualDepreciationRate < 0 || dto.AnnualDepreciationRate > 100)
                throw new ArgumentException("Annual depreciation rate must be between 0 and 100");

            if (dto.SalvageValuePercent < 0 || dto.SalvageValuePercent > 100)
                throw new ArgumentException("Salvage value percent must be between 0 and 100");

            var category = new FixedAssetCategory
            {
                CategoryCode = dto.CategoryCode.Trim().ToUpper(),
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                DepreciationMethod = dto.DepreciationMethod.Trim(),
                UsefulLifeYears = dto.UsefulLifeYears,
                AnnualDepreciationRate = dto.AnnualDepreciationRate,
                SalvageValuePercent = dto.SalvageValuePercent,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _categoryRepository.InsertAsync(category);
        }

        public async Task<bool> UpdateAsync(UpdateFixedAssetCategoryDTO dto)
        {
            if (dto.CategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            if (string.IsNullOrWhiteSpace(dto.CategoryCode))
                throw new ArgumentException("Category code is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryName))
                throw new ArgumentException("Category name is required");

            if (string.IsNullOrWhiteSpace(dto.CategoryNameAr))
                throw new ArgumentException("Category name in Arabic is required");

            var validMethods = new[] { "StraightLine", "DecliningBalance", "UnitsOfProduction" };
            if (!validMethods.Contains(dto.DepreciationMethod.Trim()))
                throw new ArgumentException($"Invalid depreciation method. Must be one of: {string.Join(", ", validMethods)}");

            if (dto.UsefulLifeYears <= 0)
                throw new ArgumentException("Useful life years must be greater than zero");

            if (dto.AnnualDepreciationRate < 0 || dto.AnnualDepreciationRate > 100)
                throw new ArgumentException("Annual depreciation rate must be between 0 and 100");

            if (dto.SalvageValuePercent < 0 || dto.SalvageValuePercent > 100)
                throw new ArgumentException("Salvage value percent must be between 0 and 100");

            var existing = await _categoryRepository.GetByIdAsync(dto.CategoryID);
            if (existing == null)
                throw new InvalidOperationException("Fixed asset category not found");

            var category = new FixedAssetCategory
            {
                CategoryID = dto.CategoryID,
                CategoryCode = dto.CategoryCode.Trim().ToUpper(),
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                DepreciationMethod = dto.DepreciationMethod.Trim(),
                UsefulLifeYears = dto.UsefulLifeYears,
                AnnualDepreciationRate = dto.AnnualDepreciationRate,
                SalvageValuePercent = dto.SalvageValuePercent,
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
                throw new InvalidOperationException("Fixed asset category not found");

            return await _categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<FixedAssetCategory?> GetByIdAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Invalid category ID");

            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task<List<FixedAssetCategory>> GetAllAsync(bool? isActive = null)
        {
            return await _categoryRepository.GetAllAsync(isActive);
        }
    }
}
