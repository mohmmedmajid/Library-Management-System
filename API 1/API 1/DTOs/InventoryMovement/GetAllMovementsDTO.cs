namespace API_1.DTOs.InventoryMovement
{
    public class GetAllMovementsDTO
    {
        public string? MovementType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
