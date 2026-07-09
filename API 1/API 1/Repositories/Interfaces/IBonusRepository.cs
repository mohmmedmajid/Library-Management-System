using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IBonusRepository
    {
        Task<int> InsertAsync(Bonus bonus);
        Task<bool> UpdateAsync(Bonus bonus);
        Task<bool> MarkAsPaidAsync(int bonusId);
        Task<bool> DeleteAsync(int bonusId);
        Task<Bonus?> GetByIdAsync(int bonusId);
        Task<List<Bonus>> GetByEmployeeAsync(int employeeId, string? bonusType = null, bool? isPaid = null);
        Task<List<Bonus>> GetAllAsync(string? bonusType = null, bool? isPaid = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<string> GenerateNumberAsync();
    }
}