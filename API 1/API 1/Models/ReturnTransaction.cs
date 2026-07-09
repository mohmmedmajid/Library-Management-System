namespace API_1.Models
{
    public class ReturnTransaction
    {
        public int ReturnID { get; set; }
        public int BorrowingID { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public int ActualDaysUsed { get; set; }
        public int LateDays { get; set; } = 0;
        public decimal LateFeeAmount { get; set; } = 0;
        public decimal RefundAmount { get; set; } = 0;
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? BorrowingNumber { get; set; }
        public int? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? CreatedByName { get; set; }
    }
}