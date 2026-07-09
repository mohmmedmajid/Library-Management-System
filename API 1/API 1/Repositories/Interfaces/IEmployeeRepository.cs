using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> InsertAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> TerminateAsync(int employeeId, DateTime terminationDate);
        Task<Employee?> GetByIdAsync(int employeeId);
        Task<List<Employee>> GetAllAsync(int? departmentId = null, string? status = null, bool? isActive = null);
        Task<List<Employee>> SearchAsync(string searchTerm);
    }
}