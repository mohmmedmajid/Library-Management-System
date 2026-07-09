namespace API_1.DTOs.OtherRevenue
{
    public class UpdateOtherRevenueDTO
    {
        public int RevenueID { get; set; }
        public int RevenueCategoryID { get; set; }
        public DateTime RevenueDate { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodID { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Description { get; set; }
        public int? CustomerID { get; set; }
        public string? ReceiptNumber { get; set; }
        public string Status { get; set; } = "Received";
    }
}