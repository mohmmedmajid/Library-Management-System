using API_1.DTOs.LateFeeRule;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class LateFeeRuleService : ILateFeeRuleService
    {
        private readonly ILateFeeRuleRepository _lateFeeRuleRepository;

        public LateFeeRuleService(ILateFeeRuleRepository lateFeeRuleRepository)
        {
            _lateFeeRuleRepository = lateFeeRuleRepository;
        }

        public async Task<int> CreateAsync(CreateLateFeeRuleDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.RuleName))
                throw new ArgumentException("Rule name is required");

            if (string.IsNullOrWhiteSpace(dto.RuleNameAr))
                throw new ArgumentException("Rule name in Arabic is required");

            if (dto.FeePerDay < 0)
                throw new ArgumentException("Fee per day cannot be negative");

            if (dto.GracePeriodDays < 0)
                throw new ArgumentException("Grace period days cannot be negative");

            if (dto.MaximumFee.HasValue && dto.MaximumFee.Value < 0)
                throw new ArgumentException("Maximum fee cannot be negative");

            if (dto.ApplicableFrom > DateTime.Now)
                throw new ArgumentException("Applicable from date cannot be in the future");

            if (dto.ApplicableTo.HasValue && dto.ApplicableTo.Value < dto.ApplicableFrom)
                throw new ArgumentException("Applicable to date must be after applicable from date");

            var rule = new LateFeeRule
            {
                RuleName = dto.RuleName.Trim(),
                RuleNameAr = dto.RuleNameAr.Trim(),
                FeePerDay = dto.FeePerDay,
                GracePeriodDays = dto.GracePeriodDays,
                MaximumFee = dto.MaximumFee,
                ApplicableFrom = dto.ApplicableFrom,
                ApplicableTo = dto.ApplicableTo,
                Description = dto.Description?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _lateFeeRuleRepository.InsertAsync(rule);
        }

        public async Task<bool> UpdateAsync(UpdateLateFeeRuleDTO dto)
        {
            if (dto.RuleID <= 0)
                throw new ArgumentException("Invalid rule ID");

            if (string.IsNullOrWhiteSpace(dto.RuleName))
                throw new ArgumentException("Rule name is required");

            if (string.IsNullOrWhiteSpace(dto.RuleNameAr))
                throw new ArgumentException("Rule name in Arabic is required");

            if (dto.FeePerDay < 0)
                throw new ArgumentException("Fee per day cannot be negative");

            if (dto.GracePeriodDays < 0)
                throw new ArgumentException("Grace period days cannot be negative");

            if (dto.MaximumFee.HasValue && dto.MaximumFee.Value < 0)
                throw new ArgumentException("Maximum fee cannot be negative");

            var existing = await _lateFeeRuleRepository.GetByIdAsync(dto.RuleID);
            if (existing == null)
                throw new InvalidOperationException("Late fee rule not found");

            var rule = new LateFeeRule
            {
                RuleID = dto.RuleID,
                RuleName = dto.RuleName.Trim(),
                RuleNameAr = dto.RuleNameAr.Trim(),
                FeePerDay = dto.FeePerDay,
                GracePeriodDays = dto.GracePeriodDays,
                MaximumFee = dto.MaximumFee,
                Description = dto.Description?.Trim(),
                IsActive = dto.IsActive
            };

            return await _lateFeeRuleRepository.UpdateAsync(rule);
        }

        public async Task<bool> DeleteAsync(int ruleId)
        {
            if (ruleId <= 0)
                throw new ArgumentException("Invalid rule ID");

            var existing = await _lateFeeRuleRepository.GetByIdAsync(ruleId);
            if (existing == null)
                throw new InvalidOperationException("Late fee rule not found");

            return await _lateFeeRuleRepository.DeleteAsync(ruleId);
        }

        public async Task<LateFeeRule?> GetByIdAsync(int ruleId)
        {
            if (ruleId <= 0)
                throw new ArgumentException("Invalid rule ID");

            return await _lateFeeRuleRepository.GetByIdAsync(ruleId);
        }

        public async Task<LateFeeRule?> GetActiveAsync()
        {
            return await _lateFeeRuleRepository.GetActiveAsync();
        }

        public async Task<List<LateFeeRule>> GetAllAsync(bool? isActive = null)
        {
            return await _lateFeeRuleRepository.GetAllAsync(isActive);
        }

        public async Task<(int LateDays, decimal LateFee)> CalculateFeeAsync(DateTime expectedReturnDate, DateTime actualReturnDate)
        {
           
            if (expectedReturnDate > actualReturnDate)
            {
                return (0, 0);
            }

            return await _lateFeeRuleRepository.CalculateFeeAsync(expectedReturnDate, actualReturnDate);
        }
    }
}