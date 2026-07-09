using API_1.DTOs.Employee;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<int> CreateAsync(CreateEmployeeDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.EmployeeCode))
                throw new ArgumentException("Employee code is required");

            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name is required");

            if (string.IsNullOrWhiteSpace(dto.FullNameAr))
                throw new ArgumentException("Full name in Arabic is required");

            if (dto.BasicSalary <= 0)
                throw new ArgumentException("Basic salary must be greater than zero");

            if (dto.HireDate > DateTime.Now)
                throw new ArgumentException("Hire date cannot be in the future");

            if (!string.IsNullOrWhiteSpace(dto.Gender))
            {
                var validGenders = new[] { "Male", "Female" };
                if (!validGenders.Contains(dto.Gender.Trim()))
                    throw new ArgumentException("Gender must be either 'Male' or 'Female'");
            }

            if (dto.DepartmentID.HasValue)
            {
                var department = await _departmentRepository.GetByIdAsync(dto.DepartmentID.Value);
                if (department == null)
                    throw new InvalidOperationException("Department not found");
            }

            var employee = new Employee
            {
                EmployeeCode = dto.EmployeeCode.Trim(),
                FullName = dto.FullName.Trim(),
                FullNameAr = dto.FullNameAr.Trim(),
                NationalID = dto.NationalID?.Trim(),
                BirthDate = dto.BirthDate,
                Gender = dto.Gender?.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                Address = dto.Address?.Trim(),
                DepartmentID = dto.DepartmentID,
                JobTitle = dto.JobTitle?.Trim(),
                JobTitleAr = dto.JobTitleAr?.Trim(),
                HireDate = dto.HireDate,
                BasicSalary = dto.BasicSalary,
                BankAccountNumber = dto.BankAccountNumber?.Trim(),
                BankName = dto.BankName?.Trim(),
                EmergencyContactName = dto.EmergencyContactName?.Trim(),
                EmergencyContactPhone = dto.EmergencyContactPhone?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _employeeRepository.InsertAsync(employee);
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            if (string.IsNullOrWhiteSpace(dto.EmployeeCode))
                throw new ArgumentException("Employee code is required");

            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name is required");

            if (string.IsNullOrWhiteSpace(dto.FullNameAr))
                throw new ArgumentException("Full name in Arabic is required");

            if (dto.BasicSalary <= 0)
                throw new ArgumentException("Basic salary must be greater than zero");

            var existing = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (existing == null)
                throw new InvalidOperationException("Employee not found");

            if (!string.IsNullOrWhiteSpace(dto.Gender))
            {
                var validGenders = new[] { "Male", "Female" };
                if (!validGenders.Contains(dto.Gender.Trim()))
                    throw new ArgumentException("Gender must be either 'Male' or 'Female'");
            }

            var validStatuses = new[] { "Active", "OnLeave", "Terminated" };
            if (!validStatuses.Contains(dto.Status.Trim()))
                throw new ArgumentException("Invalid employee status");

            if (dto.DepartmentID.HasValue)
            {
                var department = await _departmentRepository.GetByIdAsync(dto.DepartmentID.Value);
                if (department == null)
                    throw new InvalidOperationException("Department not found");
            }

            var employee = new Employee
            {
                EmployeeID = dto.EmployeeID,
                EmployeeCode = dto.EmployeeCode.Trim(),
                FullName = dto.FullName.Trim(),
                FullNameAr = dto.FullNameAr.Trim(),
                NationalID = dto.NationalID?.Trim(),
                BirthDate = dto.BirthDate,
                Gender = dto.Gender?.Trim(),
                Phone = dto.Phone?.Trim(),
                Email = dto.Email?.Trim(),
                Address = dto.Address?.Trim(),
                DepartmentID = dto.DepartmentID,
                JobTitle = dto.JobTitle?.Trim(),
                JobTitleAr = dto.JobTitleAr?.Trim(),
                BasicSalary = dto.BasicSalary,
                BankAccountNumber = dto.BankAccountNumber?.Trim(),
                BankName = dto.BankName?.Trim(),
                EmergencyContactName = dto.EmergencyContactName?.Trim(),
                EmergencyContactPhone = dto.EmergencyContactPhone?.Trim(),
                Status = dto.Status.Trim(),
                IsActive = dto.IsActive
            };

            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<bool> TerminateAsync(int employeeId, DateTime terminationDate)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Invalid employee ID");

            if (terminationDate > DateTime.Now)
                throw new ArgumentException("Termination date cannot be in the future");

            var existing = await _employeeRepository.GetByIdAsync(employeeId);
            if (existing == null)
                throw new InvalidOperationException("Employee not found");

            if (existing.Status == "Terminated")
                throw new InvalidOperationException("Employee is already terminated");

            return await _employeeRepository.TerminateAsync(employeeId, terminationDate);
        }

        public async Task<Employee?> GetByIdAsync(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Invalid employee ID");

            return await _employeeRepository.GetByIdAsync(employeeId);
        }

        public async Task<List<Employee>> GetAllAsync(GetAllEmployeesDTO dto)
        {
            return await _employeeRepository.GetAllAsync(
                dto.DepartmentID,
                dto.Status,
                dto.IsActive
            );
        }

        public async Task<List<Employee>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                throw new ArgumentException("Search term is required");

            if (searchTerm.Trim().Length < 2)
                throw new ArgumentException("Search term must be at least 2 characters");

            return await _employeeRepository.SearchAsync(searchTerm.Trim());
        }
    }
}