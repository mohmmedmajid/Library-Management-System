// UpdateExpenseDTO.cs
using System;

namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateExpenseDTO
    {
        public int ExpenseID { get; set; }
        public int ExpenseCategoryID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string ReferenceNumber { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? SupplierID { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
        public string Status { get; set; } = "Paid";
    }
}