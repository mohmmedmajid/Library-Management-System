
namespace API_1.DTOs.Invoice
{
    public class InvoiceFullDTO
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; }
        public string? CustomerName { get; set; }
        public string? SupplierName { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public string? PaymentMethodName { get; set; }
        public string? SalesRepName { get; set; }
        public string? Notes { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public List<InvoiceFullDetailDTO> Details { get; set; } = new List<InvoiceFullDetailDTO>();
    }

    public class InvoiceFullDetailDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}