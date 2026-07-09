namespace API_1.Models
{
    public class SupplierTransaction
    {
        public int TransactionID { get; set; }
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int? InvoiceID { get; set; }
        public string? InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}