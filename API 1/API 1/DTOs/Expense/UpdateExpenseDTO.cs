namespace API_1.DTOs.Expense
{
    public class UpdateExpenseDTO
    {
        public int ExpenseID { get; set; }
        public int ExpenseCategoryID { get; set; }
        public DateTime ExpenseDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Description { get; set; }
        public int? SupplierID { get; set; }
        public string? ReceiptNumber { get; set; }
        public string Status { get; set; } = "Paid";
    }
}