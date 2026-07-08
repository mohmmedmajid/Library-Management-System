using System;
using System.Collections.Generic;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreatePurchaseInvoiceWithDetailsDTO
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public int InvoiceTypeID { get; set; } = 6; 
        public int SupplierID { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentType { get; set; } = "Cash";
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
}