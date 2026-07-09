using API_1.DTOs.Bonus;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IBonusService
    {
        Task<int> CreateAsync(CreateBonusDTO dto);
        Task<bool> UpdateAsync(UpdateBonusDTO dto);
        Task<bool> MarkAsPaidAsync(int bonusId);
        Task<bool> DeleteAsync(int bonusId);
        Task<Bonus?> GetByIdAsync(int bonusId);
        Task<List<Bonus>> GetByEmployeeAsync(GetBonusesByEmployeeDTO dto);
        Task<List<Bonus>> GetAllAsync(string? bonusType = null, bool? isPaid = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}