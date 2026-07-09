using API_1.DTOs.SalaryComponent;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class SalaryComponentService : ISalaryComponentService
    {
        private readonly ISalaryComponentRepository _salaryComponentRepository;

        public SalaryComponentService(ISalaryComponentRepository salaryComponentRepository)
        {
            _salaryComponentRepository = salaryComponentRepository;
        }

        public async Task<int> CreateAsync(CreateSalaryComponentDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ComponentCode))
                throw new ArgumentException("Component code is required");

            if (string.IsNullOrWhiteSpace(dto.ComponentName))
                throw new ArgumentException("Component name is required");

            if (string.IsNullOrWhiteSpace(dto.ComponentNameAr))
                throw new ArgumentException("Component name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.ComponentType))
                throw new ArgumentException("Component type is required");

            var validTypes = new[] { "Addition", "Deduction" };
            if (!validTypes.Contains(dto.ComponentType.Trim()))
                throw new ArgumentException("Component type must be either 'Addition' or 'Deduction'");

            if (dto.DefaultAmount < 0)
                throw new ArgumentException("Default amount cannot be negative");

            var component = new SalaryComponent
            {
                ComponentCode = dto.ComponentCode.Trim(),
                ComponentName = dto.ComponentName.Trim(),
                ComponentNameAr = dto.ComponentNameAr.Trim(),
                ComponentType = dto.ComponentType.Trim(),
                IsFixed = dto.IsFixed,
                IsTaxable = dto.IsTaxable,
                DefaultAmount = dto.DefaultAmount,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _salaryComponentRepository.InsertAsync(component);
        }

        public async Task<bool> UpdateAsync(UpdateSalaryComponentDTO dto)
        {
            if (dto.ComponentID <= 0)
                throw new ArgumentException("Invalid component ID");

            if (string.IsNullOrWhiteSpace(dto.ComponentCode))
                throw new ArgumentException("Component code is required");

            if (string.IsNullOrWhiteSpace(dto.ComponentName))
                throw new ArgumentException("Component name is required");

            if (string.IsNullOrWhiteSpace(dto.ComponentNameAr))
                throw new ArgumentException("Component name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.ComponentType))
                throw new ArgumentException("Component type is required");

            var validTypes = new[] { "Addition", "Deduction" };
            if (!validTypes.Contains(dto.ComponentType.Trim()))
                throw new ArgumentException("Component type must be either 'Addition' or 'Deduction'");

            if (dto.DefaultAmount < 0)
                throw new ArgumentException("Default amount cannot be negative");

            var existing = await _salaryComponentRepository.GetByIdAsync(dto.ComponentID);
            if (existing == null)
                throw new InvalidOperationException("Salary component not found");

            var component = new SalaryComponent
            {
                ComponentID = dto.ComponentID,
                ComponentCode = dto.ComponentCode.Trim(),
                ComponentName = dto.ComponentName.Trim(),
                ComponentNameAr = dto.ComponentNameAr.Trim(),
                ComponentType = dto.ComponentType.Trim(),
                IsFixed = dto.IsFixed,
                IsTaxable = dto.IsTaxable,
                DefaultAmount = dto.DefaultAmount,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _salaryComponentRepository.UpdateAsync(component);
        }

        public async Task<bool> DeleteAsync(int componentId)
        {
            if (componentId <= 0)
                throw new ArgumentException("Invalid component ID");

            var existing = await _salaryComponentRepository.GetByIdAsync(componentId);
            if (existing == null)
                throw new InvalidOperationException("Salary component not found");

            return await _salaryComponentRepository.DeleteAsync(componentId);
        }

        public async Task<SalaryComponent?> GetByIdAsync(int componentId)
        {
            if (componentId <= 0)
                throw new ArgumentException("Invalid component ID");

            return await _salaryComponentRepository.GetByIdAsync(componentId);
        }

        public async Task<List<SalaryComponent>> GetAllAsync(string? componentType = null, bool? isActive = null)
        {
            return await _salaryComponentRepository.GetAllAsync(componentType, isActive);
        }
    }
}