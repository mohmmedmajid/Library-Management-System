namespace API_1.DTOs.InvoiceType
{
    public class CreateInvoiceTypeDTO
    {
        public string TypeName { get; set; } = string.Empty;
        public string TypeNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}