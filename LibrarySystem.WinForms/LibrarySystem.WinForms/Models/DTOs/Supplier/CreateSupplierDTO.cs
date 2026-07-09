namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateSupplierDTO
    {
        public string SupplierName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; } = 0;
        public string PaymentTerms { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
    }
}