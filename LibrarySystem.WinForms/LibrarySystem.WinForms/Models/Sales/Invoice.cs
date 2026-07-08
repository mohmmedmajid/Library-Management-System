using System;

namespace LibrarySystem.WinForms.Models.Sales
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public int InvoiceTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int PaymentMethodID { get; set; }
        public string MethodName { get; set; } = string.Empty;
        public string PaymentType { get; set; } = "Cash";
        public int SalesRepID { get; set; }
        public decimal SubTotal { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;
        public decimal TaxPercent { get; set; } = 0;
        public decimal TotalAmount { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = "Completed";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedByName { get; set; } = string.Empty;
    }
}