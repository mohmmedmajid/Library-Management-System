namespace API_1.Models
{
    public class Expense
    {
        public int ExpenseID { get; set; }
        public int ExpenseCategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryNameAr { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string? MethodName { get; set; }
        public string? MethodNameAr { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Description { get; set; }
        public int? SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string? ReceiptNumber { get; set; }
        public bool IsRecurring { get; set; } = false;
        public string? RecurringPeriod { get; set; } 
        public int? ApprovedBy { get; set; }
        public string? ApprovedByName { get; set; }
        public string Status { get; set; } = "Paid"; 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}