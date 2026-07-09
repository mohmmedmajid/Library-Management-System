namespace API_1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductNameAr { get; set; } = string.Empty;
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Barcode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; } = 0;
        public string? Description { get; set; }
        public string ProductType { get; set; } = "Other";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }

        //  Inventory
        public int QuantityInStock { get; set; }
        public int QuantityBorrowed { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
