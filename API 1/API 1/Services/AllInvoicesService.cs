using API_1.DTOs.AllInvoices;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class AllInvoicesService : IAllInvoicesService
    {
        private readonly IInvoiceSearchRepository _invoiceSearchRepository;

        public AllInvoicesService(IInvoiceSearchRepository invoiceSearchRepository)
        {
            _invoiceSearchRepository = invoiceSearchRepository;
        }

        public async Task<List<AllInvoiceItem>> GetAllAsync(GetAllInvoicesDTO dto)
        {
            if (dto.StartDate.HasValue && dto.EndDate.HasValue && dto.StartDate > dto.EndDate)
                throw new ArgumentException("Start date cannot be after end date");

            return await _invoiceSearchRepository.GetAllInvoicesAsync(
                dto.InvoiceType,
                dto.StartDate,
                dto.EndDate,
                dto.CustomerID
            );
        }
    }
}