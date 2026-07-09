using API_1.DTOs.ChartOfAccount;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class ChartOfAccountService : IChartOfAccountService
    {
        private readonly IChartOfAccountRepository _chartOfAccountRepository;
        private readonly IAccountTypeRepository _accountTypeRepository;

        public ChartOfAccountService(
            IChartOfAccountRepository chartOfAccountRepository,
            IAccountTypeRepository accountTypeRepository)
        {
            _chartOfAccountRepository = chartOfAccountRepository;
            _accountTypeRepository = accountTypeRepository;
        }

        public async Task<int> CreateAsync(CreateChartOfAccountDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.AccountCode))
                throw new ArgumentException("Account code is required");

            if (string.IsNullOrWhiteSpace(dto.AccountName))
                throw new ArgumentException("Account name is required");

            if (string.IsNullOrWhiteSpace(dto.AccountNameAr))
                throw new ArgumentException("Account name in Arabic is required");

            if (dto.AccountTypeID <= 0)
                throw new ArgumentException("Invalid account type ID");

            if (dto.Level < 1 || dto.Level > 5)
                throw new ArgumentException("Account level must be between 1 and 5");

            var accountType = await _accountTypeRepository.GetByIdAsync(dto.AccountTypeID);
            if (accountType == null)
                throw new InvalidOperationException("Account type not found");

            if (dto.ParentAccountID.HasValue)
            {
                var parent = await _chartOfAccountRepository.GetByIdAsync(dto.ParentAccountID.Value);
                if (parent == null)
                    throw new InvalidOperationException("Parent account not found");
            }

            var account = new ChartOfAccount
            {
                AccountCode = dto.AccountCode.Trim(),
                AccountName = dto.AccountName.Trim(),
                AccountNameAr = dto.AccountNameAr.Trim(),
                AccountTypeID = dto.AccountTypeID,
                ParentAccountID = dto.ParentAccountID,
                Level = dto.Level,
                IsParent = dto.IsParent,
                OpeningBalance = dto.OpeningBalance,
                CurrencyCode = dto.CurrencyCode.Trim(),
                AllowPosting = dto.AllowPosting,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _chartOfAccountRepository.InsertAsync(account);
        }

        public async Task<bool> UpdateAsync(UpdateChartOfAccountDTO dto)
        {
            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            if (string.IsNullOrWhiteSpace(dto.AccountCode))
                throw new ArgumentException("Account code is required");

            if (string.IsNullOrWhiteSpace(dto.AccountName))
                throw new ArgumentException("Account name is required");

            if (string.IsNullOrWhiteSpace(dto.AccountNameAr))
                throw new ArgumentException("Account name in Arabic is required");

            if (dto.AccountTypeID <= 0)
                throw new ArgumentException("Invalid account type ID");

            var existing = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (existing == null)
                throw new InvalidOperationException("Account not found");

            var accountType = await _accountTypeRepository.GetByIdAsync(dto.AccountTypeID);
            if (accountType == null)
                throw new InvalidOperationException("Account type not found");

            var account = new ChartOfAccount
            {
                AccountID = dto.AccountID,
                AccountCode = dto.AccountCode.Trim(),
                AccountName = dto.AccountName.Trim(),
                AccountNameAr = dto.AccountNameAr.Trim(),
                AccountTypeID = dto.AccountTypeID,
                AllowPosting = dto.AllowPosting,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _chartOfAccountRepository.UpdateAsync(account);
        }

        public async Task<bool> DeleteAsync(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentException("Invalid account ID");

            var existing = await _chartOfAccountRepository.GetByIdAsync(accountId);
            if (existing == null)
                throw new InvalidOperationException("Account not found");

            return await _chartOfAccountRepository.DeleteAsync(accountId);
        }

        public async Task<ChartOfAccount?> GetByIdAsync(int accountId)
        {
            if (accountId <= 0)
                throw new ArgumentException("Invalid account ID");

            return await _chartOfAccountRepository.GetByIdAsync(accountId);
        }

        public async Task<ChartOfAccount?> GetByCodeAsync(string accountCode)
        {
            if (string.IsNullOrWhiteSpace(accountCode))
                throw new ArgumentException("Account code is required");

            return await _chartOfAccountRepository.GetByCodeAsync(accountCode.Trim());
        }

        public async Task<List<ChartOfAccount>> GetAllAsync(GetAllAccountsDTO dto)
        {
            return await _chartOfAccountRepository.GetAllAsync(
                dto.AccountTypeID,
                dto.IsActive,
                dto.AllowPosting
            );
        }

        public async Task<List<ChartOfAccount>> GetTreeAsync(int? accountTypeId = null)
        {
            return await _chartOfAccountRepository.GetTreeAsync(accountTypeId);
        }

        public async Task<List<ChartOfAccount>> GetLeafAccountsAsync(int? accountTypeId = null)
        {
            return await _chartOfAccountRepository.GetLeafAccountsAsync(accountTypeId);
        }

        public async Task<bool> UpdateBalanceAsync(UpdateAccountBalanceDTO dto)
        {
            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            var account = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (account == null)
                throw new InvalidOperationException("Account not found");

            if (!account.AllowPosting)
                throw new InvalidOperationException("This account does not allow posting");

            return await _chartOfAccountRepository.UpdateBalanceAsync(
                dto.AccountID,
                dto.Amount,
                dto.IsDebit
            );
        }

        public async Task<List<ChartOfAccount>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("Search term is required");

            if (searchTerm.Trim().Length < 2)
                throw new ArgumentException("Search term must be at least 2 characters");

            return await _chartOfAccountRepository.SearchAsync(searchTerm.Trim());
        }
    }
}