using API_1.DTOs.AccountType;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IAccountTypeRepository _accountTypeRepository;

        public AccountTypeService(IAccountTypeRepository accountTypeRepository)
        {
            _accountTypeRepository = accountTypeRepository;
        }

        public async Task<int> CreateAsync(CreateAccountTypeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TypeName))
                throw new ArgumentException("Type name is required");

            if (string.IsNullOrWhiteSpace(dto.TypeNameAr))
                throw new ArgumentException("Type name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.NormalBalance))
                throw new ArgumentException("Normal balance is required");

            var validBalances = new[] { "Debit", "Credit" };
            if (!validBalances.Contains(dto.NormalBalance.Trim()))
                throw new ArgumentException("Normal balance must be either 'Debit' or 'Credit'");

            var accountType = new AccountType
            {
                TypeName = dto.TypeName.Trim(),
                TypeNameAr = dto.TypeNameAr.Trim(),
                NormalBalance = dto.NormalBalance.Trim(),
                Description = dto.Description?.Trim(),
                DisplayOrder = dto.DisplayOrder
            };

            return await _accountTypeRepository.InsertAsync(accountType);
        }

        public async Task<bool> UpdateAsync(UpdateAccountTypeDTO dto)
        {
            if (dto.AccountTypeID <= 0)
                throw new ArgumentException("Invalid account type ID");

            if (string.IsNullOrWhiteSpace(dto.TypeName))
                throw new ArgumentException("Type name is required");

            if (string.IsNullOrWhiteSpace(dto.TypeNameAr))
                throw new ArgumentException("Type name in Arabic is required");

            if (string.IsNullOrWhiteSpace(dto.NormalBalance))
                throw new ArgumentException("Normal balance is required");

            var validBalances = new[] { "Debit", "Credit" };
            if (!validBalances.Contains(dto.NormalBalance.Trim()))
                throw new ArgumentException("Normal balance must be either 'Debit' or 'Credit'");

            var existing = await _accountTypeRepository.GetByIdAsync(dto.AccountTypeID);
            if (existing == null)
                throw new InvalidOperationException("Account type not found");

            var accountType = new AccountType
            {
                AccountTypeID = dto.AccountTypeID,
                TypeName = dto.TypeName.Trim(),
                TypeNameAr = dto.TypeNameAr.Trim(),
                NormalBalance = dto.NormalBalance.Trim(),
                Description = dto.Description?.Trim(),
                DisplayOrder = dto.DisplayOrder,
                IsActive = dto.IsActive
            };

            return await _accountTypeRepository.UpdateAsync(accountType);
        }

        public async Task<bool> DeleteAsync(int accountTypeId)
        {
            if (accountTypeId <= 0)
                throw new ArgumentException("Invalid account type ID");

            var existing = await _accountTypeRepository.GetByIdAsync(accountTypeId);
            if (existing == null)
                throw new InvalidOperationException("Account type not found");

            return await _accountTypeRepository.DeleteAsync(accountTypeId);
        }

        public async Task<AccountType?> GetByIdAsync(int accountTypeId)
        {
            if (accountTypeId <= 0)
                throw new ArgumentException("Invalid account type ID");

            return await _accountTypeRepository.GetByIdAsync(accountTypeId);
        }

        public async Task<List<AccountType>> GetAllAsync(bool? isActive = null)
        {
            return await _accountTypeRepository.GetAllAsync(isActive);
        }
    }
}