namespace LibrarySystem.WinForms.Models.DTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public string ProductType { get; set; } = "Other";
        public int QuantityInStock { get; set; } = 0;
        public int CreatedBy { get; set; }
    }
}