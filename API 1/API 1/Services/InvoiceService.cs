using API.Application.Services.Interfaces;
using API_1.DTOs.Invoice;
using API_1.Models;
using API_1.Repositories.Interfaces;

namespace API.Application.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly ICustomerTransactionRepository _customerTransactionRepository;

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            IInvoiceDetailRepository invoiceDetailRepository,
            ICustomerTransactionRepository customerTransactionRepository)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _customerTransactionRepository = customerTransactionRepository;
        }

        public async Task<int> CreateAsync(CreateInvoiceDTO dto)
        {
            ValidateInvoiceDTO(dto);
            var invoice = MapToInvoice(dto);
            return await _invoiceRepository.InsertAsync(invoice);
        }

        public async Task<int> CreateWithDetailsAsync(CreateInvoiceWithDetailsDTO dto)
        {
            ValidateInvoiceWithDetails(dto);

            var invoice = new Invoice
            {
                InvoiceNumber = dto.InvoiceNumber.Trim(),
                InvoiceDate = dto.InvoiceDate,
                InvoiceTypeID = dto.InvoiceTypeID,
                CustomerID = dto.CustomerID,
                PaymentMethodID = dto.PaymentMethodID,
                PaymentType = dto.PaymentType.Trim(),
                SalesRepID = dto.SalesRepID,
                SubTotal = dto.SubTotal,
                DiscountAmount = dto.DiscountAmount,
                DiscountPercent = dto.DiscountPercent,
                TaxAmount = dto.TaxAmount,
                TaxPercent = dto.TaxPercent,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                Notes = dto.Notes?.Trim(),
                Status = dto.Status.Trim(),
                CreatedBy = dto.CreatedBy
            };

            int invoiceId = await _invoiceRepository.InsertAsync(invoice);

            foreach (var detailDto in dto.Details)
            {
                var detail = new InvoiceDetail
                {
                    InvoiceID = invoiceId,
                    ProductID = detailDto.ProductID,
                    Quantity = detailDto.Quantity,
                    UnitPrice = detailDto.UnitPrice,
                    DiscountAmount = detailDto.DiscountAmount,
                    DiscountPercent = detailDto.DiscountPercent,
                    TotalPrice = detailDto.TotalPrice,
                    Notes = detailDto.Notes?.Trim()
                };

                await _invoiceDetailRepository.InsertAsync(detail);
            }

            if (dto.CustomerID.HasValue)
            {
                var transaction = new CustomerTransaction
                {
                    CustomerID = dto.CustomerID.Value,
                    TransactionType = "Sale",
                    InvoiceID = invoiceId,
                    Amount = dto.TotalAmount,
                    Notes = $"Invoice: {dto.InvoiceNumber}",
                    CreatedBy = dto.CreatedBy
                };

                await _customerTransactionRepository.InsertAsync(transaction);
            }

            return invoiceId;
        }

        public async Task<bool> UpdateAsync(UpdateInvoiceDTO dto)
        {
            if (dto.InvoiceID <= 0)
                throw new ArgumentException("Invalid invoice ID");

            var existing = await _invoiceRepository.GetByIdAsync(dto.InvoiceID);
            if (existing == null)
                throw new InvalidOperationException("Invoice not found");

            var invoice = new Invoice
            {
                InvoiceID = dto.InvoiceID,
                InvoiceDate = dto.InvoiceDate,
                CustomerID = dto.CustomerID,
                PaymentMethodID = dto.PaymentMethodID,
                SalesRepID = dto.SalesRepID,
                DiscountAmount = dto.DiscountAmount,
                DiscountPercent = dto.DiscountPercent,
                Notes = dto.Notes?.Trim(),
                Status = dto.Status.Trim()
            };

            return await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task<bool> DeleteAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                throw new ArgumentException("Invalid invoice ID");

            var existing = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (existing == null)
                throw new InvalidOperationException("Invoice not found");

            return await _invoiceRepository.DeleteAsync(invoiceId);
        }

        public async Task<Invoice?> GetByIdAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                throw new ArgumentException("Invalid invoice ID");

            return await _invoiceRepository.GetByIdAsync(invoiceId);
        }

        public async Task<Invoice?> GetByNumberAsync(string invoiceNumber)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
                throw new ArgumentException("Invoice number is required");

            return await _invoiceRepository.GetByNumberAsync(invoiceNumber.Trim());
        }

        public async Task<List<Invoice>> GetAllAsync(GetAllInvoicesDTO dto)
        {
            return await _invoiceRepository.GetAllAsync(
                dto.InvoiceTypeID,
                dto.CustomerID,
                dto.Status,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<Dictionary<string, object>> GetInvoiceWithDetailsAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                throw new ArgumentException("Invalid invoice ID");

            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice == null)
                throw new InvalidOperationException("Invoice not found");

            var details = await _invoiceDetailRepository.GetByInvoiceIdAsync(invoiceId);

            return new Dictionary<string, object>
            {
                { "Invoice", invoice },
                { "Details", details }
            };
        }

        public async Task<InvoiceFullDTO?> GetFullByNumberAsync(string invoiceNumber)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
                throw new ArgumentException("Invoice number is required");

            var invoice = await _invoiceRepository.GetByNumberAsync(invoiceNumber.Trim());
            if (invoice == null)
                return null;

            var details = await _invoiceDetailRepository.GetByInvoiceIdAsync(invoice.InvoiceID);

            var dto = new InvoiceFullDTO
            {
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceDate = invoice.InvoiceDate,
                CustomerName = invoice.CustomerName,
                SupplierName = invoice.CustomerName,
                PaymentType = invoice.PaymentType,
                PaymentMethodName = invoice.MethodName,
                SalesRepName = null,
                Notes = invoice.Notes,
                SubTotal = invoice.SubTotal,
                DiscountAmount = invoice.DiscountAmount,
                TaxAmount = invoice.TaxAmount,
                TotalAmount = invoice.TotalAmount,
                PaidAmount = invoice.PaidAmount,
                RemainingAmount = invoice.RemainingAmount,
                Details = details.Select(d => new InvoiceFullDetailDTO
                {
                    ProductName = d.ProductName ?? string.Empty,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    DiscountAmount = d.DiscountAmount,
                    TotalPrice = d.TotalPrice
                }).ToList()
            };

            return dto;
        }

        private void ValidateInvoiceDTO(CreateInvoiceDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.InvoiceNumber))
                throw new ArgumentException("Invoice number is required");

            if (dto.InvoiceTypeID <= 0)
                throw new ArgumentException("Invalid invoice type ID");

            if (dto.PaymentMethodID <= 0)
                throw new ArgumentException("Invalid payment method ID");

            if (dto.TotalAmount < 0)
                throw new ArgumentException("Total amount cannot be negative");

            if (dto.PaidAmount < 0)
                throw new ArgumentException("Paid amount cannot be negative");

            if (dto.PaidAmount > dto.TotalAmount)
                throw new ArgumentException("Paid amount cannot exceed total amount");
        }

        private void ValidateInvoiceWithDetails(CreateInvoiceWithDetailsDTO dto)
        {
            ValidateInvoiceDTO(new CreateInvoiceDTO
            {
                InvoiceNumber = dto.InvoiceNumber,
                InvoiceTypeID = dto.InvoiceTypeID,
                PaymentMethodID = dto.PaymentMethodID,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount
            });

            if (dto.Details == null || !dto.Details.Any())
                throw new ArgumentException("Invoice must have at least one detail");

            foreach (var detail in dto.Details)
            {
                if (detail.ProductID <= 0)
                    throw new ArgumentException("Invalid product ID in details");

                if (detail.Quantity <= 0)
                    throw new ArgumentException("Quantity must be greater than zero");

                if (detail.UnitPrice < 0)
                    throw new ArgumentException("Unit price cannot be negative");

                if (detail.TotalPrice < 0)
                    throw new ArgumentException("Total price cannot be negative");
            }
        }

        private Invoice MapToInvoice(CreateInvoiceDTO dto)
        {
            return new Invoice
            {
                InvoiceNumber = dto.InvoiceNumber.Trim(),
                InvoiceDate = dto.InvoiceDate,
                InvoiceTypeID = dto.InvoiceTypeID,
                CustomerID = dto.CustomerID,
                PaymentMethodID = dto.PaymentMethodID,
                PaymentType = dto.PaymentType.Trim(),
                SalesRepID = dto.SalesRepID,
                SubTotal = dto.SubTotal,
                DiscountAmount = dto.DiscountAmount,
                DiscountPercent = dto.DiscountPercent,
                TaxAmount = dto.TaxAmount,
                TaxPercent = dto.TaxPercent,
                TotalAmount = dto.TotalAmount,
                PaidAmount = dto.PaidAmount,
                RemainingAmount = dto.RemainingAmount,
                Notes = dto.Notes?.Trim(),
                Status = dto.Status.Trim(),
                CreatedBy = dto.CreatedBy
            };
        }
    }
}