namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateBorrowedDTO
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string Operation { get; set; } = string.Empty;
    }
}