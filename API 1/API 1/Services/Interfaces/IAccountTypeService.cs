using API_1.DTOs.AccountType;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IAccountTypeService
    {
        Task<int> CreateAsync(CreateAccountTypeDTO dto);
        Task<bool> UpdateAsync(UpdateAccountTypeDTO dto);
        Task<bool> DeleteAsync(int accountTypeId);
        Task<AccountType?> GetByIdAsync(int accountTypeId);
        Task<List<AccountType>> GetAllAsync(bool? isActive = null);
    }
}