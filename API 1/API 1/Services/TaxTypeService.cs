using API_1.DTOs.TaxType;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{   
        public class TaxTypeService : ITaxTypeService
        {
            private readonly ITaxTypeRepository _taxTypeRepository;

            public TaxTypeService(ITaxTypeRepository taxTypeRepository)
            {
                _taxTypeRepository = taxTypeRepository;
            }

            public async Task<int> CreateAsync(CreateTaxTypeDTO dto)
            {
                if (string.IsNullOrWhiteSpace(dto.TaxCode))
                    throw new ArgumentException("Tax code is required");

                if (string.IsNullOrWhiteSpace(dto.TaxName))
                    throw new ArgumentException("Tax name is required");

                if (string.IsNullOrWhiteSpace(dto.TaxNameAr))
                    throw new ArgumentException("Tax name in Arabic is required");

                if (dto.TaxRate < 0 || dto.TaxRate > 100)
                    throw new ArgumentException("Tax rate must be between 0 and 100");

                var validCategories = new[] { "Sales", "Purchase", "Withholding", "Income" };
                if (!validCategories.Contains(dto.TaxCategory.Trim()))
                    throw new ArgumentException($"Invalid tax category. Must be one of: {string.Join(", ", validCategories)}");

                if (dto.EffectiveTo.HasValue && dto.EffectiveTo <= dto.EffectiveFrom)
                    throw new ArgumentException("Effective to date must be after effective from date");

                var taxType = new TaxType
                {
                    TaxCode = dto.TaxCode.Trim().ToUpper(),
                    TaxName = dto.TaxName.Trim(),
                    TaxNameAr = dto.TaxNameAr.Trim(),
                    TaxRate = dto.TaxRate,
                    TaxCategory = dto.TaxCategory.Trim(),
                    Description = dto.Description?.Trim(),
                    EffectiveFrom = dto.EffectiveFrom,
                    EffectiveTo = dto.EffectiveTo,
                    CreatedBy = dto.CreatedBy
                };

                return await _taxTypeRepository.InsertAsync(taxType);
            }

            public async Task<bool> UpdateAsync(UpdateTaxTypeDTO dto)
            {
                if (dto.TaxTypeID <= 0)
                    throw new ArgumentException("Invalid tax type ID");

                if (string.IsNullOrWhiteSpace(dto.TaxCode))
                    throw new ArgumentException("Tax code is required");

                if (string.IsNullOrWhiteSpace(dto.TaxName))
                    throw new ArgumentException("Tax name is required");

                if (string.IsNullOrWhiteSpace(dto.TaxNameAr))
                    throw new ArgumentException("Tax name in Arabic is required");

                if (dto.TaxRate < 0 || dto.TaxRate > 100)
                    throw new ArgumentException("Tax rate must be between 0 and 100");

                var validCategories = new[] { "Sales", "Purchase", "Withholding", "Income" };
                if (!validCategories.Contains(dto.TaxCategory.Trim()))
                    throw new ArgumentException($"Invalid tax category. Must be one of: {string.Join(", ", validCategories)}");

                if (dto.EffectiveTo.HasValue && dto.EffectiveTo <= dto.EffectiveFrom)
                    throw new ArgumentException("Effective to date must be after effective from date");

                var existing = await _taxTypeRepository.GetByIdAsync(dto.TaxTypeID);
                if (existing == null)
                    throw new InvalidOperationException("Tax type not found");

                var taxType = new TaxType
                {
                    TaxTypeID = dto.TaxTypeID,
                    TaxCode = dto.TaxCode.Trim().ToUpper(),
                    TaxName = dto.TaxName.Trim(),
                    TaxNameAr = dto.TaxNameAr.Trim(),
                    TaxRate = dto.TaxRate,
                    TaxCategory = dto.TaxCategory.Trim(),
                    Description = dto.Description?.Trim(),
                    EffectiveFrom = dto.EffectiveFrom,
                    EffectiveTo = dto.EffectiveTo,
                    IsActive = dto.IsActive
                };

                return await _taxTypeRepository.UpdateAsync(taxType);
            }

            public async Task<bool> DeleteAsync(int taxTypeId)
            {
                if (taxTypeId <= 0)
                    throw new ArgumentException("Invalid tax type ID");

                var existing = await _taxTypeRepository.GetByIdAsync(taxTypeId);
                if (existing == null)
                    throw new InvalidOperationException("Tax type not found");

                return await _taxTypeRepository.DeleteAsync(taxTypeId);
            }

            public async Task<TaxType?> GetByIdAsync(int taxTypeId)
            {
                if (taxTypeId <= 0)
                    throw new ArgumentException("Invalid tax type ID");

                return await _taxTypeRepository.GetByIdAsync(taxTypeId);
            }

            public async Task<List<TaxType>> GetAllAsync(string? taxCategory = null, bool? isActive = null)
            {
                return await _taxTypeRepository.GetAllAsync(taxCategory, isActive);
            }

            public async Task<TaxType?> GetActiveByCategoryAsync(string taxCategory)
            {
                if (string.IsNullOrWhiteSpace(taxCategory))
                    throw new ArgumentException("Tax category is required");

                var validCategories = new[] { "Sales", "Purchase", "Withholding", "Income" };
                if (!validCategories.Contains(taxCategory.Trim()))
                    throw new ArgumentException($"Invalid tax category. Must be one of: {string.Join(", ", validCategories)}");

                return await _taxTypeRepository.GetActiveByCategoryAsync(taxCategory.Trim());
            }

            public async Task<decimal> CalculateTaxAsync(CalculateTaxDTO dto)
            {
                if (dto.TaxTypeID <= 0)
                    throw new ArgumentException("Invalid tax type ID");

                if (dto.BaseAmount < 0)
                    throw new ArgumentException("Base amount cannot be negative");

                var taxType = await _taxTypeRepository.GetByIdAsync(dto.TaxTypeID);
                if (taxType == null)
                    throw new InvalidOperationException("Tax type not found");

                if (!taxType.IsActive)
                    throw new InvalidOperationException("Tax type is not active");

                return await _taxTypeRepository.CalculateTaxAsync(dto.TaxTypeID, dto.BaseAmount);
            }
        }
}

