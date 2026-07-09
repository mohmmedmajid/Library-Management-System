namespace API_1.DTOs.Supplier
{
    public class CreateSupplierDTO
    {
        public string SupplierName { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? TaxNumber { get; set; }
        public decimal CreditLimit { get; set; } = 0;
        public string? PaymentTerms { get; set; }
        public int CreatedBy { get; set; }
    }
}