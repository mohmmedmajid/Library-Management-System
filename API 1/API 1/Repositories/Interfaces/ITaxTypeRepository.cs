using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ITaxTypeRepository
    {
        Task<int> InsertAsync(TaxType taxType);
        Task<bool> UpdateAsync(TaxType taxType);
        Task<bool> DeleteAsync(int taxTypeId);
        Task<TaxType?> GetByIdAsync(int taxTypeId);
        Task<List<TaxType>> GetAllAsync(string? taxCategory = null, bool? isActive = null);
        Task<TaxType?> GetActiveByCategoryAsync(string taxCategory);
        Task<decimal> CalculateTaxAsync(int taxTypeId, decimal baseAmount);
    }
}
