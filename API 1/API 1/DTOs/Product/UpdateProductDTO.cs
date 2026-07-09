namespace API_1.DTOs.Product
{
    public class UpdateProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string? Barcode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; } = 0;
        public string? Description { get; set; }
        public string ProductType { get; set; } = "Other";
        public bool IsActive { get; set; } = true;
    }
}
