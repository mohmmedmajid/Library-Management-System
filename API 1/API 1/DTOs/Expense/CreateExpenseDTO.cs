namespace API_1.DTOs.Expense
{
    public class CreateExpenseDTO
    {
        public int ExpenseCategoryID { get; set; }
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Description { get; set; }
        public int? SupplierID { get; set; }
        public string? ReceiptNumber { get; set; }
        public bool IsRecurring { get; set; } = false;
        public string? RecurringPeriod { get; set; }
        public int? ApprovedBy { get; set; }
        public string Status { get; set; } = "Paid";
        public int CreatedBy { get; set; }
    }
}