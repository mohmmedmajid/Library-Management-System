namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSalesRepresentativeDTO
    {
        public int SalesRepID { get; set; }
        public string RepName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal CommissionPercent { get; set; }
        public bool IsActive { get; set; } = true;
    }
}