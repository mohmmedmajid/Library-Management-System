namespace API_1.DTOs.InventoryMovement
{
    public class GetMovementsByProductDTO
    {
        public int ProductID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
