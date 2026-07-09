using API_1.DTOs.Payroll;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IPayrollService
    {
        Task<int> CreateAsync(CreatePayrollDTO dto);
        Task<bool> ApproveAsync(ApprovePayrollDTO dto);
        Task<bool> PostAsync(PostPayrollDTO dto);
        Task<bool> MarkAsPaidAsync(int payrollId, int paidBy);
        Task<bool> DeleteAsync(int payrollId);
        Task<Payroll?> GetByIdAsync(int payrollId);
        Task<List<Payroll>> GetAllAsync(GetAllPayrollsDTO dto);
    }
}