using API_1.DTOs.AccountBalance;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class AccountBalanceService : IAccountBalanceService
    {
        private readonly IAccountBalanceRepository _accountBalanceRepository;
        private readonly IChartOfAccountRepository _chartOfAccountRepository;

        public AccountBalanceService(
            IAccountBalanceRepository accountBalanceRepository,
            IChartOfAccountRepository chartOfAccountRepository)
        {
            _accountBalanceRepository = accountBalanceRepository;
            _chartOfAccountRepository = chartOfAccountRepository;
        }

        public async Task<AccountBalance?> GetBalanceAsync(GetAccountBalanceDTO dto)
        {
            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            if (dto.FiscalYear < 2000 || dto.FiscalYear > 2100)
                throw new ArgumentException("Invalid fiscal year");

            if (dto.FiscalMonth < 1 || dto.FiscalMonth > 12)
                throw new ArgumentException("Fiscal month must be between 1 and 12");

            var account = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (account == null)
                throw new InvalidOperationException("Account not found");

            return await _accountBalanceRepository.GetBalanceAsync(
                dto.AccountID,
                dto.FiscalYear,
                dto.FiscalMonth
            );
        }

        public async Task<List<AccountBalance>> GetByPeriodAsync(GetBalancesByPeriodDTO dto)
        {
            if (dto.FiscalYear < 2000 || dto.FiscalYear > 2100)
                throw new ArgumentException("Invalid fiscal year");

            if (dto.FiscalMonth < 1 || dto.FiscalMonth > 12)
                throw new ArgumentException("Fiscal month must be between 1 and 12");

            return await _accountBalanceRepository.GetByPeriodAsync(
                dto.FiscalYear,
                dto.FiscalMonth,
                dto.AccountTypeID
            );
        }

        public async Task<List<AccountBalance>> GetYearToDateAsync(GetYearToDateDTO dto)
        {
            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            if (dto.FiscalYear < 2000 || dto.FiscalYear > 2100)
                throw new ArgumentException("Invalid fiscal year");

            if (dto.EndMonth < 1 || dto.EndMonth > 12)
                throw new ArgumentException("End month must be between 1 and 12");

            var account = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (account == null)
                throw new InvalidOperationException("Account not found");

            return await _accountBalanceRepository.GetYearToDateAsync(
                dto.AccountID,
                dto.FiscalYear,
                dto.EndMonth
            );
        }
    }
}