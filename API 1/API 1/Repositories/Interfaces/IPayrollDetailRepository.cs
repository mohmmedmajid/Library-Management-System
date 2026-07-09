using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IPayrollDetailRepository
    {
        Task<List<PayrollDetail>> GetByPayrollIdAsync(int payrollId);
        Task<List<PayrollDetail>> GetByEmployeeAsync(int employeeId, int? payrollYear = null);
        Task<PayrollDetail?> GetBreakdownAsync(int payrollDetailId);
    }
}