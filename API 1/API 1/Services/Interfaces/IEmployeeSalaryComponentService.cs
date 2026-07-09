using API_1.DTOs.EmployeeSalaryComponent;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IEmployeeSalaryComponentService
    {
        Task<int> CreateAsync(CreateEmployeeSalaryComponentDTO dto);
        Task<bool> UpdateAsync(UpdateEmployeeSalaryComponentDTO dto);
        Task<bool> DeleteAsync(int employeeSalaryComponentId);
        Task<List<EmployeeSalaryComponent>> GetByEmployeeAsync(GetComponentsByEmployeeDTO dto);
        Task<EmployeeSalaryComponent?> GetTotalsAsync(int employeeId);
    }
}