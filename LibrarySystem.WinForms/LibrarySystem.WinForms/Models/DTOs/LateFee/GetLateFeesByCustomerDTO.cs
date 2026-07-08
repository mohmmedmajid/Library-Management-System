namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetLateFeesByCustomerDTO
    {
        public int CustomerID { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}