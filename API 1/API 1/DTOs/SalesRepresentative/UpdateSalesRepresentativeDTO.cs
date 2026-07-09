namespace API_1.DTOs.SalesRepresentative
{
    public class UpdateSalesRepresentativeDTO
    {
        public int SalesRepID { get; set; }
        public string RepName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal CommissionPercent { get; set; }
        public bool IsActive { get; set; } = true;
    }
}