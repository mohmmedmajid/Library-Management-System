namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSupplierTransactionDTO
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}