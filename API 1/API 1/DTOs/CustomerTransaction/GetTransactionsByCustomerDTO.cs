namespace API_1.DTOs.CustomerTransaction
{
    public class GetTransactionsByCustomerDTO
    {
        public int CustomerID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}