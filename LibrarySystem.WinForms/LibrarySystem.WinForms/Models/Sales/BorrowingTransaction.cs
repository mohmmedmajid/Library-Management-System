using System;

namespace LibrarySystem.WinForms.Models.Sales
{
    public class BorrowingTransaction
    {
        public int BorrowingID { get; set; }
        public string BorrowingNumber { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime BorrowingDate { get; set; } = DateTime.Now;
        public DateTime ExpectedReturnDate { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public string Status { get; set; } = "Borrowed";
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = string.Empty;
    }
}