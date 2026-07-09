using API_1.DTOs.EmployeeSalaryComponent;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class EmployeeSalaryComponentService : IEmployeeSalaryComponentService
    {
        private readonly IEmployeeSalaryComponentRepository _employeeSalaryComponentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryComponentRepository _salaryComponentRepository;

        public EmployeeSalaryComponentService(
            IEmployeeSalaryComponentRepository employeeSalaryComponentRepository,
            IEmployeeRepository employeeRepository,
            ISalaryComponentRepository salaryComponentRepository)
        {
            _employeeSalaryComponentRepository = employeeSalaryComponentRepository;
            _employeeRepository = employeeRepository;
            _salaryComponentRepository = salaryComponentRepository;
        }

        public async Task<int> CreateAsync(CreateEmployeeSalaryComponentDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            if (dto.ComponentID <= 0)
                throw new ArgumentException("Invalid component ID");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            var component = await _salaryComponentRepository.GetByIdAsync(dto.ComponentID);
            if (component == null)
                throw new InvalidOperationException("Salary component not found");

            var employeeComponent = new EmployeeSalaryComponent
            {
                EmployeeID = dto.EmployeeID,
                ComponentID = dto.ComponentID,
                Amount = dto.Amount,
                StartDate = dto.StartDate,
                CreatedBy = dto.CreatedBy
            };

            return await _employeeSalaryComponentRepository.InsertAsync(employeeComponent);
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeSalaryComponentDTO dto)
        {
            if (dto.EmployeeSalaryComponentID <= 0)
                throw new ArgumentException("Invalid employee salary component ID");

            if (dto.Amount < 0)
                throw new ArgumentException("Amount cannot be negative");

            var employeeComponent = new EmployeeSalaryComponent
            {
                EmployeeSalaryComponentID = dto.EmployeeSalaryComponentID,
                Amount = dto.Amount,
                IsActive = dto.IsActive
            };

            return await _employeeSalaryComponentRepository.UpdateAsync(employeeComponent);
        }

        public async Task<bool> DeleteAsync(int employeeSalaryComponentId)
        {
            if (employeeSalaryComponentId <= 0)
                throw new ArgumentException("Invalid employee salary component ID");

            return await _employeeSalaryComponentRepository.DeleteAsync(employeeSalaryComponentId);
        }

        public async Task<List<EmployeeSalaryComponent>> GetByEmployeeAsync(GetComponentsByEmployeeDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return await _employeeSalaryComponentRepository.GetByEmployeeAsync(
                dto.EmployeeID,
                dto.IsActive
            );
        }

        public async Task<EmployeeSalaryComponent?> GetTotalsAsync(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Invalid employee ID");

            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return await _employeeSalaryComponentRepository.GetTotalsAsync(employeeId);
        }
    }
}