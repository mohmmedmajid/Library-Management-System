using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateInvoiceDTO
    {
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerID { get; set; }
        public int PaymentMethodID { get; set; }
        public int SalesRepID { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = "Completed";
    }
}