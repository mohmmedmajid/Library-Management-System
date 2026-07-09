namespace API_1.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        public string CustomerName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int CreatedBy { get; set; }
    }
}
