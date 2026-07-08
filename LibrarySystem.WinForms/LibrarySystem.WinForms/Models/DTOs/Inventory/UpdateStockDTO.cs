namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateStockDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string MovementType { get; set; } = string.Empty;
    }
}