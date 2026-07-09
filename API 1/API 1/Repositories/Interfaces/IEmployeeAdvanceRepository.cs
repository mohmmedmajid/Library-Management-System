using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IEmployeeAdvanceRepository
    {
        Task<int> InsertAsync(EmployeeAdvance advance);
        Task<bool> UpdateAsync(EmployeeAdvance advance);
        Task<bool> CancelAsync(int advanceId);
        Task<EmployeeAdvance?> GetByIdAsync(int advanceId);
        Task<List<EmployeeAdvance>> GetByEmployeeAsync(int employeeId, string? status = null);
        Task<List<EmployeeAdvance>> GetAllAsync(string? status = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<string> GenerateNumberAsync();
    }
}