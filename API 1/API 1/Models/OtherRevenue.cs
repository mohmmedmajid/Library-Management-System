namespace API_1.Models
{
    public class OtherRevenue
    {
        public int RevenueID { get; set; }
        public int RevenueCategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryNameAr { get; set; }
        public DateTime RevenueDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string? MethodName { get; set; }
        public string? MethodNameAr { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Description { get; set; }
        public int? CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? ReceiptNumber { get; set; }
        public bool IsRecurring { get; set; } = false;
        public string? RecurringPeriod { get; set; }
        public string Status { get; set; } = "Received"; 
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}