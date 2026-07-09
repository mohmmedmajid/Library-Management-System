using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface ILateFeeRuleRepository
    {
        Task<int> InsertAsync(LateFeeRule rule);
        Task<bool> UpdateAsync(LateFeeRule rule);
        Task<bool> DeleteAsync(int ruleId);
        Task<LateFeeRule?> GetByIdAsync(int ruleId);
        Task<LateFeeRule?> GetActiveAsync();
        Task<List<LateFeeRule>> GetAllAsync(bool? isActive = null);
        Task<(int LateDays, decimal LateFee)> CalculateFeeAsync(DateTime expectedReturnDate, DateTime actualReturnDate);
    }
}