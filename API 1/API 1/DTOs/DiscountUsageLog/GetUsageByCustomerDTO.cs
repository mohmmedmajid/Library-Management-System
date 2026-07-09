namespace API_1.DTOs.DiscountUsageLog
{
    public class GetUsageByCustomerDTO
    {
        public int CustomerID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}