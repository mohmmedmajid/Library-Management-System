namespace API_1.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductNameAr { get; set; }
        public string? CategoryName { get; set; }
        public int QuantityInStock { get; set; } = 0;
        public int QuantityBorrowed { get; set; } = 0;
        public int AvailableQuantity { get; set; } = 0;
        public int MinimumStockLevel { get; set; } = 5;  
        public DateTime? LastRestockDate { get; set; }
        public DateTime LastUpdatedDate { get; set; } = DateTime.Now;
    }
}
