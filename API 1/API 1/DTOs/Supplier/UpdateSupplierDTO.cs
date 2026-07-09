namespace API_1.DTOs.Supplier
{
    public class UpdateSupplierDTO
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? TaxNumber { get; set; }
        public decimal CreditLimit { get; set; }
        public string? PaymentTerms { get; set; }
        public bool IsActive { get; set; } = true;
    }
}