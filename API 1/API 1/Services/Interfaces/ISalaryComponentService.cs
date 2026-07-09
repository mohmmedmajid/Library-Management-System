using API_1.DTOs.SalaryComponent;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ISalaryComponentService
    {
        Task<int> CreateAsync(CreateSalaryComponentDTO dto);
        Task<bool> UpdateAsync(UpdateSalaryComponentDTO dto);
        Task<bool> DeleteAsync(int componentId);
        Task<SalaryComponent?> GetByIdAsync(int componentId);
        Task<List<SalaryComponent>> GetAllAsync(string? componentType = null, bool? isActive = null);
    }
}