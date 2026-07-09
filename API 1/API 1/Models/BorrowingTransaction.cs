namespace API_1.Models
{
    public class BorrowingTransaction
    {
        public int BorrowingID { get; set; }
        public string BorrowingNumber { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public DateTime BorrowingDate { get; set; } = DateTime.Now;
        public DateTime ExpectedReturnDate { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public string Status { get; set; } = "Borrowed"; 
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CustomerName { get; set; }
        public string? CreatedByName { get; set; }
    }
}