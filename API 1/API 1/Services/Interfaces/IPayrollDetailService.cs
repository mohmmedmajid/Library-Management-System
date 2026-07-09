using API_1.DTOs.PayrollDetail;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IPayrollDetailService
    {
        Task<List<PayrollDetail>> GetByPayrollIdAsync(int payrollId);
        Task<List<PayrollDetail>> GetByEmployeeAsync(GetDetailsByEmployeeDTO dto);
        Task<PayrollDetail?> GetBreakdownAsync(int payrollDetailId);
    }
}