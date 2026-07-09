namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateCustomerTransactionDTO
    {
        public int CustomerID { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}