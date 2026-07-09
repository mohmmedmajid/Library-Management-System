using API_1.DTOs.RepCommission;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class RepCommissionService  : IRepCommissionService
    {
        private readonly IRepCommissionRepository _repCommissionRepository;
        private readonly ISalesRepresentativeRepository _salesRepRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public RepCommissionService(
            IRepCommissionRepository repCommissionRepository,
            ISalesRepresentativeRepository salesRepRepository,
            IInvoiceRepository invoiceRepository)
        {
            _repCommissionRepository = repCommissionRepository;
            _salesRepRepository = salesRepRepository;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<int> CreateAsync(CreateRepCommissionDTO dto)
        {
            ValidateCommissionDTO(dto);

            var salesRep = await _salesRepRepository.GetByIdAsync(dto.SalesRepID);
            if (salesRep == null)
                throw new InvalidOperationException("Sales representative not found");

            var invoice = await _invoiceRepository.GetByIdAsync(dto.InvoiceID);
            if (invoice == null)
                throw new InvalidOperationException("Invoice not found");

            var commission = new RepCommission
            {
                SalesRepID = dto.SalesRepID,
                InvoiceID = dto.InvoiceID,
                SalesAmount = dto.SalesAmount,
                CommissionPercent = dto.CommissionPercent,
                CommissionAmount = dto.CommissionAmount,
                IsPaid = dto.IsPaid,
                Notes = dto.Notes?.Trim()
            };

            return await _repCommissionRepository.InsertAsync(commission);
        }

        public async Task<bool> UpdateAsync(UpdateRepCommissionDTO dto)
        {
            if (dto.CommissionID <= 0)
                throw new ArgumentException("Invalid commission ID");

            if (dto.CommissionAmount < 0)
                throw new ArgumentException("Commission amount cannot be negative");

            var existing = await _repCommissionRepository.GetByIdAsync(dto.CommissionID);
            if (existing == null)
                throw new InvalidOperationException("Commission not found");

            var commission = new RepCommission
            {
                CommissionID = dto.CommissionID,
                CommissionAmount = dto.CommissionAmount,
                IsPaid = dto.IsPaid,
                Notes = dto.Notes?.Trim()
            };

            return await _repCommissionRepository.UpdateAsync(commission);
        }

        public async Task<bool> DeleteAsync(int commissionId)
        {
            if (commissionId <= 0)
                throw new ArgumentException("Invalid commission ID");

            var existing = await _repCommissionRepository.GetByIdAsync(commissionId);
            if (existing == null)
                throw new InvalidOperationException("Commission not found");

            if (existing.IsPaid)
                throw new InvalidOperationException("Cannot delete a paid commission");

            return await _repCommissionRepository.DeleteAsync(commissionId);
        }

        public async Task<RepCommission?> GetByIdAsync(int commissionId)
        {
            if (commissionId <= 0)
                throw new ArgumentException("Invalid commission ID");

            return await _repCommissionRepository.GetByIdAsync(commissionId);
        }

        public async Task<List<RepCommission>> GetBySalesRepAsync(GetCommissionsBySalesRepDTO dto)
        {
            if (dto.SalesRepID <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            return await _repCommissionRepository.GetBySalesRepAsync(
                dto.SalesRepID,
                dto.IsPaid,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<RepCommission>> GetAllAsync(GetAllCommissionsDTO dto)
        {
            return await _repCommissionRepository.GetAllAsync(
                dto.IsPaid,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<bool> MarkAsPaidAsync(int commissionId)
        {
            if (commissionId <= 0)
                throw new ArgumentException("Invalid commission ID");

            var commission = await _repCommissionRepository.GetByIdAsync(commissionId);
            if (commission == null)
                throw new InvalidOperationException("Commission not found");

            if (commission.IsPaid)
                throw new InvalidOperationException("Commission is already marked as paid");

            return await _repCommissionRepository.MarkAsPaidAsync(commissionId);
        }

        public async Task<Dictionary<string, object>?> GetUnpaidTotalAsync(int salesRepId)
        {
            if (salesRepId <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            var salesRep = await _salesRepRepository.GetByIdAsync(salesRepId);
            if (salesRep == null)
                throw new InvalidOperationException("Sales representative not found");

            return await _repCommissionRepository.GetUnpaidTotalAsync(salesRepId);
        }

        private void ValidateCommissionDTO(CreateRepCommissionDTO dto)
        {
            if (dto.SalesRepID <= 0)
                throw new ArgumentException("Invalid sales representative ID");

            if (dto.InvoiceID <= 0)
                throw new ArgumentException("Invalid invoice ID");

            if (dto.SalesAmount < 0)
                throw new ArgumentException("Sales amount cannot be negative");

            if (dto.CommissionPercent < 0 || dto.CommissionPercent > 100)
                throw new ArgumentException("Commission percent must be between 0 and 100");

            if (dto.CommissionAmount < 0)
                throw new ArgumentException("Commission amount cannot be negative");

            decimal calculatedCommission = (dto.SalesAmount * dto.CommissionPercent) / 100;
            if (Math.Abs(calculatedCommission - dto.CommissionAmount) > 0.01m)
                throw new ArgumentException($"Commission amount calculation mismatch. Expected: {calculatedCommission:F2}, Provided: {dto.CommissionAmount:F2}");
        }
    }
}
