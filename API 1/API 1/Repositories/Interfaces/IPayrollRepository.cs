using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IPayrollRepository
    {
        Task<int> CreateAsync(int payrollMonth, int payrollYear, int? createdBy);
        Task<bool> ApproveAsync(int payrollId, int approvedBy);
        Task<bool> PostAsync(int payrollId, int postedBy);
        Task<bool> MarkAsPaidAsync(int payrollId, int paidBy);
        Task<bool> DeleteAsync(int payrollId);
        Task<Payroll?> GetByIdAsync(int payrollId);
        Task<List<Payroll>> GetAllAsync(string? status = null, int? payrollYear = null);
        Task<string> GenerateNumberAsync(int payrollYear, int payrollMonth);
    }
}