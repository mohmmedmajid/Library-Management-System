using API_1.DTOs.Employee;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(CreateEmployeeDTO dto);
        Task<bool> UpdateAsync(UpdateEmployeeDTO dto);
        Task<bool> TerminateAsync(int employeeId, DateTime terminationDate);
        Task<Employee?> GetByIdAsync(int employeeId);
        Task<List<Employee>> GetAllAsync(GetAllEmployeesDTO dto);
        Task<List<Employee>> SearchAsync(string searchTerm);
    }
}