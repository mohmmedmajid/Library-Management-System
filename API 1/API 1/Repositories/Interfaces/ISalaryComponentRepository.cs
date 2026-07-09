using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ISalaryComponentRepository
    {
        Task<int> InsertAsync(SalaryComponent component);
        Task<bool> UpdateAsync(SalaryComponent component);
        Task<bool> DeleteAsync(int componentId);
        Task<SalaryComponent?> GetByIdAsync(int componentId);
        Task<List<SalaryComponent>> GetAllAsync(string? componentType = null, bool? isActive = null);
    }
}