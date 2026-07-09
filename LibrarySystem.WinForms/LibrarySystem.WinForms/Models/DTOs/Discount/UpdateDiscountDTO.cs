using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateDiscountDTO
    {
        public int DiscountID { get; set; }
        public string DiscountName { get; set; } = string.Empty;
        public string DiscountNameAr { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal MinimumPurchaseAmount { get; set; }
        public decimal MaximumDiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsageLimit { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}