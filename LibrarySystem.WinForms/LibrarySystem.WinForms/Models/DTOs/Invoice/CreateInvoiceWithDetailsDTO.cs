using System;
using System.Collections.Generic;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateInvoiceWithDetailsDTO
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public int InvoiceTypeID { get; set; }
        public int? CustomerID { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentType { get; set; } = "Cash";
        public int SalesRepID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;
        public decimal TaxPercent { get; set; } = 0;
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; } = 0;
        public decimal RemainingAmount { get; set; } = 0;
        public string Notes { get; set; } = string.Empty;
        public string Status { get; set; } = "Completed";
        public int CreatedBy { get; set; }
        public List<InvoiceDetailItemDTO> Details { get; set; } = new List<InvoiceDetailItemDTO>();
    }

    public class InvoiceDetailItemDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
        public decimal DiscountPercent { get; set; } = 0;
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}