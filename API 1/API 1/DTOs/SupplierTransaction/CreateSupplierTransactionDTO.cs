namespace API_1.DTOs.SupplierTransaction
{
    public class CreateSupplierTransactionDTO
    {
        public int SupplierID { get; set; }
        public string TransactionType { get; set; } = string.Empty;  
        public int? InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public int? CreatedBy { get; set; }
    }
}