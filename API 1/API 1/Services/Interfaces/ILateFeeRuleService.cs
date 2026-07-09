using API_1.DTOs.LateFeeRule;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface ILateFeeRuleService
    {
        Task<int> CreateAsync(CreateLateFeeRuleDTO dto);
        Task<bool> UpdateAsync(UpdateLateFeeRuleDTO dto);
        Task<bool> DeleteAsync(int ruleId);
        Task<LateFeeRule?> GetByIdAsync(int ruleId);
        Task<LateFeeRule?> GetActiveAsync();
        Task<List<LateFeeRule>> GetAllAsync(bool? isActive = null);
        Task<(int LateDays, decimal LateFee)> CalculateFeeAsync(DateTime expectedReturnDate, DateTime actualReturnDate);
    }
}