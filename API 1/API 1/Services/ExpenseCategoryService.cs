using API_1.DTOs.ExpenseCategory;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _categoryRepository;

        public ExpenseCategoryService(IExpenseCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> CreateAsync(CreateExpenseCategoryDTO dto)
        {
            ValidateCategoryDTO(dto);

            await CheckDuplicateCategoryName(dto.CategoryName);

            var category = new ExpenseCategory
            {
                CategoryName = dto.CategoryName.Trim(),
                CategoryNameAr = dto.CategoryNameAr.Trim(),
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _categoryRepository.InsertAsync(category);
        }

        public async Task<bool> UpdateAsync(UpdateExpenseCategoryDTO dto)
        {
            if (dto.ExpenseCategoryID <= 0)
                throw new ArgumentException("Invalid category ID");

            ValidateCategoryDTO(new CreateExpenseCategoryDTO
            {
                CategoryName = dto.CategoryName,
                CategoryNameAr = dto.CategoryNameAr
            });

            var existing = await _categoryRepository.GetByIdAsync(dto.ExpenseCategoryID);
            if (existing == null)
                throw new InvalidOperationException("Category not found");

            await CheckDuplicateCategoryName(dto.CategoryName, dto.ExpenseCategoryID);

            var category = new ExpenseCategory
            {
                ExpenseCategoryID = dto.ExpenseCategoryID,
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

        public async Task<ExpenseCategory?> GetByIdAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Invalid category ID");

            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task<List<ExpenseCategory>> GetAllAsync(bool? isActive = null)
        {
            return await _categoryRepository.GetAllAsync(isActive);
        }

        public async Task<List<ExpenseCategory>> GetWithTotalsAsync(GetCategoriesWithTotalsDTO dto)
        {
            return await _categoryRepository.GetWithTotalsAsync(dto.StartDate, dto.EndDate);
        }

        private void ValidateCategoryDTO(CreateExpenseCategoryDTO dto)
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
                (!excludeId.HasValue || c.ExpenseCategoryID != excludeId.Value));

            if (duplicate != null)
                throw new InvalidOperationException("A category with this name already exists");
        }
    }
}