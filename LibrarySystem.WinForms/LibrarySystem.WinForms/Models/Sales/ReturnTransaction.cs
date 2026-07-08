using System;

namespace LibrarySystem.WinForms.Models.Sales
{
    public class ReturnTransaction
    {
        public int ReturnID { get; set; }
        public int BorrowingID { get; set; }
        public string BorrowingNumber { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public int ActualDaysUsed { get; set; }
        public int LateDays { get; set; } = 0;
        public decimal LateFeeAmount { get; set; } = 0;
        public decimal RefundAmount { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = string.Empty;
    }
}