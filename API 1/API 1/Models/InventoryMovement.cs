namespace API_1.Models
{
    public class InventoryMovement
    {
        public int MovementID { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string MovementType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? ReferenceType { get; set; }
        public int? ReferenceID { get; set; }
        public string? Notes { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
    }
}
