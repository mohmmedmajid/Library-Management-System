namespace API_1.Models
{
    public class SalesRepresentative
    {
        public int SalesRepID { get; set; }
        public string RepName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal CommissionPercent { get; set; } = 0;
        public decimal TotalSales { get; set; } = 0;
        public decimal TotalCommissions { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}