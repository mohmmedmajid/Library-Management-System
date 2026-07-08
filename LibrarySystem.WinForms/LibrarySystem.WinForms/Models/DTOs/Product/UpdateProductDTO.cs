namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public string ProductType { get; set; } = "Other";
        public bool IsActive { get; set; } = true;
        public int QuantityInStock { get; set; }
    }
}