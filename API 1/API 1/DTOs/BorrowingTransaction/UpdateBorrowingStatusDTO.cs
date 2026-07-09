namespace API_1.DTOs.BorrowingTransaction
{
    public class UpdateBorrowingStatusDTO
    {
        public int BorrowingID { get; set; }
        public string Status { get; set; } = "Borrowed";
    }
}