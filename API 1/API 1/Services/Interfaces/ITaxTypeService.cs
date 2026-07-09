using API_1.DTOs.TaxType;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ITaxTypeService
    {
        Task<int> CreateAsync(CreateTaxTypeDTO dto);
        Task<bool> UpdateAsync(UpdateTaxTypeDTO dto);
        Task<bool> DeleteAsync(int taxTypeId);
        Task<TaxType?> GetByIdAsync(int taxTypeId);
        Task<List<TaxType>> GetAllAsync(string? taxCategory = null, bool? isActive = null);
        Task<TaxType?> GetActiveByCategoryAsync(string taxCategory);
        Task<decimal> CalculateTaxAsync(CalculateTaxDTO dto);
    }
}
