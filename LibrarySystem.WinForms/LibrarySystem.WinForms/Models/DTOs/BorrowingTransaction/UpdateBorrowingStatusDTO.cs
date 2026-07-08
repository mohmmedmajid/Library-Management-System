namespace LibrarySystem.WinForms.Models.DTOs
{
    public class UpdateBorrowingStatusDTO
    {
        public int BorrowingID { get; set; }
        public string Status { get; set; } = "Borrowed";
    }
}