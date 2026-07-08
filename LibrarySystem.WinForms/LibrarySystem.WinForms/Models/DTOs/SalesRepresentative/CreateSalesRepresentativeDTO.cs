namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateSalesRepresentativeDTO
    {
        public string RepName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal CommissionPercent { get; set; } = 0;
        public int CreatedBy { get; set; }
    }
}