using API_1.DTOs.AccountBalance;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IAccountBalanceService
    {
        Task<AccountBalance?> GetBalanceAsync(GetAccountBalanceDTO dto);
        Task<List<AccountBalance>> GetByPeriodAsync(GetBalancesByPeriodDTO dto);
        Task<List<AccountBalance>> GetYearToDateAsync(GetYearToDateDTO dto);
    }
}