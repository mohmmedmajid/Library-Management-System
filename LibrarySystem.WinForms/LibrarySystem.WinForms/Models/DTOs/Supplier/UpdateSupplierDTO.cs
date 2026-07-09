namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateSupplierDTO
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string TaxNumber { get; set; } = string.Empty;
        public decimal CreditLimit { get; set; }
        public string PaymentTerms { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}