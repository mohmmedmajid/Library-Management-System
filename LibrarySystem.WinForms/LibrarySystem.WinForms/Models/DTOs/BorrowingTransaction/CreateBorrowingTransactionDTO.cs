using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateBorrowingTransactionDTO
    {
        public string BorrowingNumber { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public DateTime BorrowingDate { get; set; } = DateTime.Now;
        public DateTime ExpectedReturnDate { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public string Status { get; set; } = "Borrowed";
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}