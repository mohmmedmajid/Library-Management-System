using API_1.DTOs.EmployeeAdvance;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class EmployeeAdvanceService : IEmployeeAdvanceService
    {
        private readonly IEmployeeAdvanceRepository _employeeAdvanceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeAdvanceService(
            IEmployeeAdvanceRepository employeeAdvanceRepository,
            IEmployeeRepository employeeRepository)
        {
            _employeeAdvanceRepository = employeeAdvanceRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> CreateAsync(CreateEmployeeAdvanceDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (dto.InstallmentMonths <= 0)
                throw new ArgumentException("Installment months must be greater than zero");

            if (dto.InstallmentMonths > 24)
                throw new ArgumentException("Installment months cannot exceed 24 months");

            if (dto.AdvanceDate > DateTime.Now)
                throw new ArgumentException("Advance date cannot be in the future");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            if (employee.Status != "Active")
                throw new InvalidOperationException("Can only create advances for active employees");

            var activeAdvances = await _employeeAdvanceRepository.GetByEmployeeAsync(dto.EmployeeID, "Active");
            var totalActiveAdvances = activeAdvances.Sum(a => a.RemainingAmount);

            var maxAdvanceLimit = employee.BasicSalary * 3;
            if (totalActiveAdvances + dto.Amount > maxAdvanceLimit)
                throw new InvalidOperationException($"Total advances cannot exceed {maxAdvanceLimit:F2} (3 months salary)");

            var advance = new EmployeeAdvance
            {
                EmployeeID = dto.EmployeeID,
                AdvanceDate = dto.AdvanceDate,
                Amount = dto.Amount,
                Reason = dto.Reason?.Trim(),
                InstallmentMonths = dto.InstallmentMonths,
                ApprovedBy = dto.ApprovedBy,
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _employeeAdvanceRepository.InsertAsync(advance);
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeAdvanceDTO dto)
        {
            if (dto.AdvanceID <= 0)
                throw new ArgumentException("Invalid advance ID");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (dto.InstallmentMonths <= 0)
                throw new ArgumentException("Installment months must be greater than zero");

            if (dto.InstallmentMonths > 24)
                throw new ArgumentException("Installment months cannot exceed 24 months");

            var existing = await _employeeAdvanceRepository.GetByIdAsync(dto.AdvanceID);
            if (existing == null)
                throw new InvalidOperationException("Employee advance not found");

            if (existing.Status != "Active")
                throw new InvalidOperationException("Can only update active advances");

            var advance = new EmployeeAdvance
            {
                AdvanceID = dto.AdvanceID,
                Amount = dto.Amount,
                Reason = dto.Reason?.Trim(),
                InstallmentMonths = dto.InstallmentMonths,
                Notes = dto.Notes?.Trim()
            };

            return await _employeeAdvanceRepository.UpdateAsync(advance);
        }

        public async Task<bool> CancelAsync(int advanceId)
        {
            if (advanceId <= 0)
                throw new ArgumentException("Invalid advance ID");

            var existing = await _employeeAdvanceRepository.GetByIdAsync(advanceId);
            if (existing == null)
                throw new InvalidOperationException("Employee advance not found");

            if (existing.Status != "Active")
                throw new InvalidOperationException("Can only cancel active advances");

            if (existing.PaidAmount > 0)
                throw new InvalidOperationException("Cannot cancel advance with paid installments");

            return await _employeeAdvanceRepository.CancelAsync(advanceId);
        }

        public async Task<EmployeeAdvance?> GetByIdAsync(int advanceId)
        {
            if (advanceId <= 0)
                throw new ArgumentException("Invalid advance ID");

            return await _employeeAdvanceRepository.GetByIdAsync(advanceId);
        }

        public async Task<List<EmployeeAdvance>> GetByEmployeeAsync(GetAdvancesByEmployeeDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return await _employeeAdvanceRepository.GetByEmployeeAsync(
                dto.EmployeeID,
                dto.Status
            );
        }

        public async Task<List<EmployeeAdvance>> GetAllAsync(string? status = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            return await _employeeAdvanceRepository.GetAllAsync(status, startDate, endDate);
        }
    }
}