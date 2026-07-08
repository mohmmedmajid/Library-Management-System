using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateOtherRevenueDTO
    {
        public int RevenueID { get; set; }
        public int RevenueCategoryID { get; set; }
        public DateTime RevenueDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Received";
    }
}