namespace API_1.DTOs.ReturnTransaction
{
    public class CreateReturnTransactionDTO
    {
        public int BorrowingID { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public int ActualDaysUsed { get; set; }
        public int LateDays { get; set; } = 0;
        public decimal LateFeeAmount { get; set; } = 0;
        public decimal RefundAmount { get; set; } = 0;
        public string? Notes { get; set; }
        public int? CreatedBy { get; set; }
    }
}