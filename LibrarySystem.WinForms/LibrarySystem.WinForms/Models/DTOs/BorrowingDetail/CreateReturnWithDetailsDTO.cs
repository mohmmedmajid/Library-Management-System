using System;
using System.Collections.Generic;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateReturnWithDetailsDTO
    {
        public int BorrowingID { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public List<ReturnDetailItemDTO> Details { get; set; } = new List<ReturnDetailItemDTO>();
    }

    public class ReturnDetailItemDTO
    {
        public int BorrowingDetailID { get; set; }
        public int ProductID { get; set; }
        public int ReturnQuantity { get; set; }
        public int LateDays { get; set; } = 0;
        public decimal LateFeeAmount { get; set; } = 0;
        public decimal RefundAmount { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
    }
}