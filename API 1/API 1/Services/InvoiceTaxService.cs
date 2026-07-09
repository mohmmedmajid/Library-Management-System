using API_1.DTOs.InvoiceTax;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class InvoiceTaxService : IInvoiceTaxService
    {
        private readonly IInvoiceTaxRepository _invoiceTaxRepository;

        public InvoiceTaxService(IInvoiceTaxRepository invoiceTaxRepository)
        {
            _invoiceTaxRepository = invoiceTaxRepository;
        }

        public async Task<int> CreateAsync(CreateInvoiceTaxDTO dto)
        {
            if (dto.InvoiceID <= 0)
                throw new ArgumentException("Invalid invoice ID");

            if (dto.TaxTypeID <= 0)
                throw new ArgumentException("Invalid tax type ID");

            if (dto.TaxableAmount < 0)
                throw new ArgumentException("Taxable amount cannot be negative");

            if (dto.TaxRate < 0 || dto.TaxRate > 100)
                throw new ArgumentException("Tax rate must be between 0 and 100");

            if (dto.TaxAmount < 0)
                throw new ArgumentException("Tax amount cannot be negative");

            var invoiceTax = new InvoiceTax
            {
                InvoiceID = dto.InvoiceID,
                TaxTypeID = dto.TaxTypeID,
                TaxableAmount = dto.TaxableAmount,
                TaxRate = dto.TaxRate,
                TaxAmount = dto.TaxAmount
            };

            return await _invoiceTaxRepository.InsertAsync(invoiceTax);
        }

        public async Task<bool> UpdateAsync(UpdateInvoiceTaxDTO dto)
        {
            if (dto.InvoiceTaxID <= 0)
                throw new ArgumentException("Invalid invoice tax ID");

            if (dto.TaxableAmount < 0)
                throw new ArgumentException("Taxable amount cannot be negative");

            if (dto.TaxRate < 0 || dto.TaxRate > 100)
                throw new ArgumentException("Tax rate must be between 0 and 100");

            if (dto.TaxAmount < 0)
                throw new ArgumentException("Tax amount cannot be negative");

            var existing = await _invoiceTaxRepository.GetByIdAsync(dto.InvoiceTaxID);
            if (existing == null)
                throw new InvalidOperationException("Invoice tax not found");

            var invoiceTax = new InvoiceTax
            {
                InvoiceTaxID = dto.InvoiceTaxID,
                TaxableAmount = dto.TaxableAmount,
                TaxRate = dto.TaxRate,
                TaxAmount = dto.TaxAmount
            };

            return await _invoiceTaxRepository.UpdateAsync(invoiceTax);
        }

        public async Task<bool> DeleteAsync(int invoiceTaxId)
        {
            if (invoiceTaxId <= 0)
                throw new ArgumentException("Invalid invoice tax ID");

            var existing = await _invoiceTaxRepository.GetByIdAsync(invoiceTaxId);
            if (existing == null)
                throw new InvalidOperationException("Invoice tax not found");

            return await _invoiceTaxRepository.DeleteAsync(invoiceTaxId);
        }

        public async Task<InvoiceTax?> GetByIdAsync(int invoiceTaxId)
        {
            if (invoiceTaxId <= 0)
                throw new ArgumentException("Invalid invoice tax ID");

            return await _invoiceTaxRepository.GetByIdAsync(invoiceTaxId);
        }

        public async Task<List<InvoiceTax>> GetByInvoiceIdAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                throw new ArgumentException("Invalid invoice ID");

            return await _invoiceTaxRepository.GetByInvoiceIdAsync(invoiceId);
        }

        public async Task<List<InvoiceTax>> GetAllAsync(GetAllInvoiceTaxesDTO dto)
        {
            return await _invoiceTaxRepository.GetAllAsync(
                dto.TaxTypeID,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<InvoiceTax>> GetSummaryAsync(GetTaxSummaryDTO dto)
        {
            if (dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date must be before end date");

            return await _invoiceTaxRepository.GetSummaryAsync(dto.StartDate, dto.EndDate);
        }
    }
}
