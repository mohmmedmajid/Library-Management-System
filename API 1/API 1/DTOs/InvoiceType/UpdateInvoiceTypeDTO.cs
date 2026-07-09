namespace API_1.DTOs.InvoiceType
{
    public class UpdateInvoiceTypeDTO
    {
        public int InvoiceTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string TypeNameAr { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}