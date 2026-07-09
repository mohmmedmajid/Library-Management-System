namespace API_1.DTOs.CustomerTransaction
{
    public class UpdateCustomerTransactionDTO
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string? Notes { get; set; }
    }
}