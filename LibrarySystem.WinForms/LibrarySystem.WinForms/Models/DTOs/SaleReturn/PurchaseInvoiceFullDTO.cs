using System;
using System.Collections.Generic;

namespace LibrarySystem.WinForms.Models.Purchases
{
    public class PurchaseInvoiceFullDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string PaymentType { get; set; }
        public string PaymentMethodName { get; set; }
        public string Notes { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public List<PurchaseInvoiceDetailDTO> Details { get; set; }
    }

    public class PurchaseInvoiceDetailDTO
    {
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}