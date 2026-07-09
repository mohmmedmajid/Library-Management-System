namespace API_1.DTOs.SupplierTransaction
{
    public class GetAllTransactionsDTO
    {
        public string? TransactionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}