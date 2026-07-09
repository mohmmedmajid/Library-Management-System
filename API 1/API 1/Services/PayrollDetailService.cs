using API_1.DTOs.PayrollDetail;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class PayrollDetailService : IPayrollDetailService
    {
        private readonly IPayrollDetailRepository _payrollDetailRepository;
        private readonly IPayrollRepository _payrollRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public PayrollDetailService(
            IPayrollDetailRepository payrollDetailRepository,
            IPayrollRepository payrollRepository,
            IEmployeeRepository employeeRepository)
        {
            _payrollDetailRepository = payrollDetailRepository;
            _payrollRepository = payrollRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<List<PayrollDetail>> GetByPayrollIdAsync(int payrollId)
        {
            if (payrollId <= 0)
                throw new ArgumentException("Invalid payroll ID");

            var payroll = await _payrollRepository.GetByIdAsync(payrollId);
            if (payroll == null)
                throw new InvalidOperationException("Payroll not found");

            return await _payrollDetailRepository.GetByPayrollIdAsync(payrollId);
        }

        public async Task<List<PayrollDetail>> GetByEmployeeAsync(GetDetailsByEmployeeDTO dto)
        {
            if (dto.EmployeeID <= 0)
                throw new ArgumentException("Invalid employee ID");

            var employee = await _employeeRepository.GetByIdAsync(dto.EmployeeID);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return await _payrollDetailRepository.GetByEmployeeAsync(
                dto.EmployeeID,
                dto.PayrollYear
            );
        }

        public async Task<PayrollDetail?> GetBreakdownAsync(int payrollDetailId)
        {
            if (payrollDetailId <= 0)
                throw new ArgumentException("Invalid payroll detail ID");

            return await _payrollDetailRepository.GetBreakdownAsync(payrollDetailId);
        }
    }
}