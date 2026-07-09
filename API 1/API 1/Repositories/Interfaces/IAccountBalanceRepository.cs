using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IAccountBalanceRepository
    {
        Task<bool> UpsertAsync(int accountId, int fiscalYear, int fiscalMonth, decimal debitAmount = 0, decimal creditAmount = 0);
        Task<AccountBalance?> GetBalanceAsync(int accountId, int fiscalYear, int fiscalMonth);
        Task<List<AccountBalance>> GetByPeriodAsync(int fiscalYear, int fiscalMonth, int? accountTypeId = null);
        Task<List<AccountBalance>> GetYearToDateAsync(int accountId, int fiscalYear, int endMonth);
    }
}