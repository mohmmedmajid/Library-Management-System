namespace API_1.DTOs.InventoryMovement
{
    public class CreateInventoryMovementDTO
    {
        public int ProductID { get; set; }
        public string MovementType { get; set; } = string.Empty; 
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? ReferenceType { get; set; }
        public int? ReferenceID { get; set; }
        public string? Notes { get; set; }
        public int CreatedBy { get; set; }
    }
}
