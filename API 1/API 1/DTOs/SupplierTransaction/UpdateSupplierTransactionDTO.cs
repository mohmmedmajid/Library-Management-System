namespace API_1.DTOs.SupplierTransaction
{
    public class UpdateSupplierTransactionDTO
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
    }
}