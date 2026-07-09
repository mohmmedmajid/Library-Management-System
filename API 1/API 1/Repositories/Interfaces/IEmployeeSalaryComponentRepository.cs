using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IEmployeeSalaryComponentRepository
    {
        Task<int> InsertAsync(EmployeeSalaryComponent employeeComponent);
        Task<bool> UpdateAsync(EmployeeSalaryComponent employeeComponent);
        Task<bool> DeleteAsync(int employeeSalaryComponentId);
        Task<List<EmployeeSalaryComponent>> GetByEmployeeAsync(int employeeId, bool? isActive = null);
        Task<EmployeeSalaryComponent?> GetTotalsAsync(int employeeId);
    }
}