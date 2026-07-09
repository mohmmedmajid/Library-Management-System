namespace API_1.DTOs.OtherRevenue
{
    public class CreateOtherRevenueDTO
    {
        public int RevenueCategoryID { get; set; }
        public DateTime RevenueDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Description { get; set; }
        public int? CustomerID { get; set; }
        public string? ReceiptNumber { get; set; }
        public bool IsRecurring { get; set; } = false;
        public string? RecurringPeriod { get; set; }
        public string Status { get; set; } = "Received";
        public int CreatedBy { get; set; }
    }
}