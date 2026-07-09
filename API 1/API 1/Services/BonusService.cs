using API_1.DTOs.Bonus;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class BonusService : IBonusService
    {
        private readonly IBonusRepository _bonusRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public BonusService(
            IBonusRepository bonusRepository,
            IEmployeeRepository employeeRepository)
        {
            _bonusRepository = bonusRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<int> CreateAsync(CreateBonusDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            if (string.IsNullOrWhiteSpace(dto.BonusType))
                throw new ArgumentException("Bonus type is required");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (dto.BonusDate > DateTime.Now)
                throw new ArgumentException("Bonus date cannot be in the future");

            var validTypes = new[] { "Monthly", "Annual", "Performance", "Special" };
            if (!validTypes.Contains(dto.BonusType.Trim()))
                throw new ArgumentException($"Invalid bonus type. Must be one of: {string.Join(", ", validTypes)}");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            if (employee.Status != "Active")
                throw new InvalidOperationException("Can only create bonuses for active employees");

            var bonus = new Bonus
            {
                EmployeeID = dto.EmployeeID,
                BonusDate = dto.BonusDate,
                BonusType = dto.BonusType.Trim(),
                Amount = dto.Amount,
                Reason = dto.Reason?.Trim(),
                ApprovedBy = dto.ApprovedBy,
                Notes = dto.Notes?.Trim(),
                CreatedBy = dto.CreatedBy
            };

            return await _bonusRepository.InsertAsync(bonus);
        }

        public async Task<bool> UpdateAsync(UpdateBonusDTO dto)
        {
            if (dto.BonusID <= 0)
                throw new ArgumentException("Invalid bonus ID");

            if (string.IsNullOrWhiteSpace(dto.BonusType))
                throw new ArgumentException("Bonus type is required");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (dto.BonusDate > DateTime.Now)
                throw new ArgumentException("Bonus date cannot be in the future");

            var validTypes = new[] { "Monthly", "Annual", "Performance", "Special" };
            if (!validTypes.Contains(dto.BonusType.Trim()))
                throw new ArgumentException($"Invalid bonus type. Must be one of: {string.Join(", ", validTypes)}");

            var existing = await _bonusRepository.GetByIdAsync(dto.BonusID);
            if (existing == null)
                throw new InvalidOperationException("Bonus not found");

            if (existing.IsPaid)
                throw new InvalidOperationException("Cannot update paid bonus");

            var bonus = new Bonus
            {
                BonusID = dto.BonusID,
                BonusDate = dto.BonusDate,
                BonusType = dto.BonusType.Trim(),
                Amount = dto.Amount,
                Reason = dto.Reason?.Trim(),
                Notes = dto.Notes?.Trim(),
                IsPaid = dto.IsPaid
            };

            return await _bonusRepository.UpdateAsync(bonus);
        }

        public async Task<bool> MarkAsPaidAsync(int bonusId)
        {
            if (bonusId <= 0)
                throw new ArgumentException("Invalid bonus ID");

            var existing = await _bonusRepository.GetByIdAsync(bonusId);
            if (existing == null)
                throw new InvalidOperationException("Bonus not found");

            if (existing.IsPaid)
                throw new InvalidOperationException("Bonus is already paid");

            return await _bonusRepository.MarkAsPaidAsync(bonusId);
        }

        public async Task<bool> DeleteAsync(int bonusId)
        {
            if (bonusId <= 0)
                throw new ArgumentException("Invalid bonus ID");

            var existing = await _bonusRepository.GetByIdAsync(bonusId);
            if (existing == null)
                throw new InvalidOperationException("Bonus not found");

            if (existing.IsPaid)
                throw new InvalidOperationException("Cannot delete paid bonus");

            return await _bonusRepository.DeleteAsync(bonusId);
        }

        public async Task<Bonus?> GetByIdAsync(int bonusId)
        {
            if (bonusId <= 0)
                throw new ArgumentException("Invalid bonus ID");

            return await _bonusRepository.GetByIdAsync(bonusId);
        }

        public async Task<List<Bonus>> GetByEmployeeAsync(GetBonusesByEmployeeDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return await _bonusRepository.GetByEmployeeAsync(
                dto.EmployeeID,
                dto.BonusType,
                dto.IsPaid
            );
        }

        public async Task<List<Bonus>> GetAllAsync(string? bonusType = null, bool? isPaid = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            return await _bonusRepository.GetAllAsync(bonusType, isPaid, startDate, endDate);
        }
    }
}