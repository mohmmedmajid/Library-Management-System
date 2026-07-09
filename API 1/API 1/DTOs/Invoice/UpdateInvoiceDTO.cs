namespace API_1.DTOs.Invoice
{
    public class UpdateInvoiceDTO
    {
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int? CustomerID { get; set; }
        public int PaymentMethodID { get; set; }
        public int? SalesRepID { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = "Completed";
    }
}