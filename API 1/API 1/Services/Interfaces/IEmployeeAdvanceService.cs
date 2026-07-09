using API_1.DTOs.EmployeeAdvance;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IEmployeeAdvanceService
    {
        Task<int> CreateAsync(CreateEmployeeAdvanceDTO dto);
        Task<bool> UpdateAsync(UpdateEmployeeAdvanceDTO dto);
        Task<bool> CancelAsync(int advanceId);
        Task<EmployeeAdvance?> GetByIdAsync(int advanceId);
        Task<List<EmployeeAdvance>> GetByEmployeeAsync(GetAdvancesByEmployeeDTO dto);
        Task<List<EmployeeAdvance>> GetAllAsync(string? status = null, DateTime? startDate = null, DateTime? endDate = null);
    }
}