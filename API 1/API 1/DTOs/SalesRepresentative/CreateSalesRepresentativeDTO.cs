namespace API_1.DTOs.SalesRepresentative
{
    public class CreateSalesRepresentativeDTO
    {
        public string RepName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public decimal CommissionPercent { get; set; } = 0;
        public int? CreatedBy { get; set; }
    }
}