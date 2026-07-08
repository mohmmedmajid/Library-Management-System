using System;

namespace LibrarySystem.WinForms.Models.Purchasing
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int ExpenseCategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string MethodName { get; set; } = string.Empty;
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string ReceiptNumber { get; set; } = string.Empty;
        public bool IsRecurring { get; set; } = false;
        public string Status { get; set; } = "Paid";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}