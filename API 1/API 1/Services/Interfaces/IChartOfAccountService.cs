using API_1.DTOs.ChartOfAccount;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IChartOfAccountService
    {
        Task<int> CreateAsync(CreateChartOfAccountDTO dto);
        Task<bool> UpdateAsync(UpdateChartOfAccountDTO dto);
        Task<bool> DeleteAsync(int accountId);
        Task<ChartOfAccount?> GetByIdAsync(int accountId);
        Task<ChartOfAccount?> GetByCodeAsync(string accountCode);
        Task<List<ChartOfAccount>> GetAllAsync(GetAllAccountsDTO dto);
        Task<List<ChartOfAccount>> GetTreeAsync(int? accountTypeId = null);
        Task<List<ChartOfAccount>> GetLeafAccountsAsync(int? accountTypeId = null);
        Task<bool> UpdateBalanceAsync(UpdateAccountBalanceDTO dto);
        Task<List<ChartOfAccount>> SearchAsync(string searchTerm);
    }
}