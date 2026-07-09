using API_1.DTOs.Payroll;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _payrollRepository;

        public PayrollService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<int> CreateAsync(CreatePayrollDTO dto)
        {
            if (dto.PayrollMonth < 1 || dto.PayrollMonth > 12)
                throw new ArgumentException("Payroll month must be between 1 and 12");

            if (dto.PayrollYear < 2000 || dto.PayrollYear > 2100)
                throw new ArgumentException("Invalid payroll year");

            var existingPayrolls = await _payrollRepository.GetAllAsync(null, dto.PayrollYear);
            if (existingPayrolls.Any(p => p.PayrollMonth == dto.PayrollMonth))
                throw new InvalidOperationException($"Payroll for {dto.PayrollMonth}/{dto.PayrollYear} already exists");

            return await _payrollRepository.CreateAsync(
                dto.PayrollMonth,
                dto.PayrollYear,
                dto.CreatedBy
            );
        }

        public async Task<bool> ApproveAsync(ApprovePayrollDTO dto)
        {
            if (dto.PayrollID <= 0)
                throw new ArgumentException("Invalid payroll ID");

            if (dto.ApprovedBy <= 0)
                throw new ArgumentException("Invalid user ID");

            var existing = await _payrollRepository.GetByIdAsync(dto.PayrollID);
            if (existing == null)
                throw new InvalidOperationException("Payroll not found");

            if (existing.Status != "Draft")
                throw new InvalidOperationException("Only draft payroll can be approved");

            if (existing.TotalEmployees == 0)
                throw new InvalidOperationException("Payroll has no employees");

            return await _payrollRepository.ApproveAsync(dto.PayrollID, dto.ApprovedBy);
        }

        public async Task<bool> PostAsync(PostPayrollDTO dto)
        {
            if (dto.PayrollID <= 0)
                throw new ArgumentException("Invalid payroll ID");

            if (dto.PostedBy <= 0)
                throw new ArgumentException("Invalid user ID");

            var existing = await _payrollRepository.GetByIdAsync(dto.PayrollID);
            if (existing == null)
                throw new InvalidOperationException("Payroll not found");

            if (existing.Status != "Approved")
                throw new InvalidOperationException("Only approved payroll can be posted");

            return await _payrollRepository.PostAsync(dto.PayrollID, dto.PostedBy);
        }

        public async Task<bool> MarkAsPaidAsync(int payrollId, int paidBy)
        {
            
            if (payrollId <= 0)
                throw new ArgumentException("Invalid payroll ID");

            if (paidBy <= 0)
                throw new ArgumentException("Invalid user ID");

            var existing = await _payrollRepository.GetByIdAsync(payrollId);
            if (existing == null)
                throw new InvalidOperationException("Payroll not found");

            if (existing.Status != "Posted")
                throw new InvalidOperationException("Only posted payroll can be marked as paid");

            return await _payrollRepository.MarkAsPaidAsync(payrollId, paidBy);
        }

        public async Task<bool> DeleteAsync(int payrollId)
        {
            if (payrollId <= 0)
                throw new ArgumentException("Invalid payroll ID");

            var existing = await _payrollRepository.GetByIdAsync(payrollId);
            if (existing == null)
                throw new InvalidOperationException("Payroll not found");

            if (existing.Status != "Draft")
                throw new InvalidOperationException("Only draft payroll can be deleted");

            return await _payrollRepository.DeleteAsync(payrollId);
        }

        public async Task<Payroll?> GetByIdAsync(int payrollId)
        {
            if (payrollId <= 0)
                throw new ArgumentException("Invalid payroll ID");

            return await _payrollRepository.GetByIdAsync(payrollId);
        }

        public async Task<List<Payroll>> GetAllAsync(GetAllPayrollsDTO dto)
        {
            return await _payrollRepository.GetAllAsync(dto.Status, dto.PayrollYear);
        }
    }
}