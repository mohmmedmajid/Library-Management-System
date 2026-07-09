using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<int> InsertAsync(AccountType accountType);
        Task<bool> UpdateAsync(AccountType accountType);
        Task<bool> DeleteAsync(int accountTypeId);
        Task<AccountType?> GetByIdAsync(int accountTypeId);
        Task<List<AccountType>> GetAllAsync(bool? isActive = null);
    }
}