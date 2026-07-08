using System;

namespace LibrarySystem.WinForms.Models.Sales
{
    public class LateFee
    {
        public int LateFeeID { get; set; }
        public int BorrowingID { get; set; }
        public string BorrowingNumber { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int LateDays { get; set; }
        public decimal FeePerDay { get; set; }
        public decimal TotalFee { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; }
        public string Status { get; set; } = "Pending";
        public string Notes { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}