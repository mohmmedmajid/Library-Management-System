using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IChartOfAccountRepository
    {
        Task<int> InsertAsync(ChartOfAccount account);
        Task<bool> UpdateAsync(ChartOfAccount account);
        Task<bool> DeleteAsync(int accountId);
        Task<ChartOfAccount?> GetByIdAsync(int accountId);
        Task<ChartOfAccount?> GetByCodeAsync(string accountCode);
        Task<List<ChartOfAccount>> GetAllAsync(int? accountTypeId = null, bool? isActive = null, bool? allowPosting = null);
        Task<List<ChartOfAccount>> GetTreeAsync(int? accountTypeId = null);
        Task<List<ChartOfAccount>> GetLeafAccountsAsync(int? accountTypeId = null);
        Task<bool> UpdateBalanceAsync(int accountId, decimal amount, bool isDebit);
        Task<List<ChartOfAccount>> SearchAsync(string searchTerm);
    }
}