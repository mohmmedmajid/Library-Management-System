namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateCustomerTransactionDTO
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}