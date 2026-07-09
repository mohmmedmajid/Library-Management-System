namespace API_1.DTOs.Inventory
{
    public class UpdateStockDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string MovementType { get; set; } = string.Empty;
    }
}
