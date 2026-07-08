namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateCustomerDTO
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}