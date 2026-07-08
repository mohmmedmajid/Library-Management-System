using System;

namespace LibrarySystem.WinForms.Models
{
    public class CustomerTransaction
    {
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public int? InvoiceID { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = string.Empty;
        public string CreatedByName { get; set; } = string.Empty;
    }
}