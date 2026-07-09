namespace API_1.DTOs.BorrowingTransaction
{
    public class GetAllBorrowingsDTO
    {
        public int? CustomerID { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}