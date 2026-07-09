namespace API_1.DTOs.OtherRevenue
{
    public class GetAllRevenuesDTO
    {
        public int? RevenueCategoryID { get; set; }
        public int? CustomerID { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}