namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateSupplierTransactionDTO
    {
        public int SupplierID { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}