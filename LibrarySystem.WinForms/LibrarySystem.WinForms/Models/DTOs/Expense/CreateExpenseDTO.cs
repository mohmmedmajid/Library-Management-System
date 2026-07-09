// CreateExpenseDTO.cs
using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateExpenseDTO
    {
        public int ExpenseCategoryID { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? SupplierID { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public bool IsRecurring { get; set; } = false;
        public string RecurringPeriod { get; set; } = string.Empty;
        public int? ApprovedBy { get; set; }
        public string Status { get; set; } = "Paid";
        public int CreatedBy { get; set; }
    }
}