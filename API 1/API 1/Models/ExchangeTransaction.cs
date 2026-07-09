namespace API_1.Models
{
    public class ExchangeTransaction
    {
        public int ExchangeID { get; set; }
        public string ExchangeNumber { get; set; } = string.Empty;
        public int OriginalInvoiceID { get; set; }
        public string? OriginalInvoiceNumber { get; set; }
        public int OriginalInvoiceDetailID { get; set; }
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public DateTime ExchangeDate { get; set; }
        public int OldProductID { get; set; }
        public string? OldProductName { get; set; }
        public int OldQuantity { get; set; }
        public int NewProductID { get; set; }
        public string? NewProductName { get; set; }
        public int NewQuantity { get; set; }
        public decimal OldTotalAmount { get; set; }
        public decimal NewTotalAmount { get; set; }
        public decimal PriceDifference { get; set; }
        public int PaymentMethodID { get; set; }
        public int? NewInvoiceID { get; set; }
        public string? NewInvoiceNumber { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}