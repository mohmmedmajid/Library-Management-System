using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateBorrowingTransactionDTO
    {
        public int BorrowingID { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public string Status { get; set; } = "Borrowed";
        public string Notes { get; set; } = string.Empty;
    }
}