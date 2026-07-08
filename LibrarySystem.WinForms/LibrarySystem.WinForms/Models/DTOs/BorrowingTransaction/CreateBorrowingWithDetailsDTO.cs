using System;
using System.Collections.Generic;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateBorrowingWithDetailsDTO
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
        public List<BorrowingDetailItemDTO> Details { get; set; } = new List<BorrowingDetailItemDTO>();
    }

    public class BorrowingDetailItemDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerDay { get; set; }
        public int TotalDays { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}