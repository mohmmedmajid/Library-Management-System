namespace API_1.DTOs.BorrowingTransaction
{
    public class UpdateBorrowingTransactionDTO
    {
        public int BorrowingID { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public string Status { get; set; } = "Borrowed";
        public string? Notes { get; set; }
    }
}