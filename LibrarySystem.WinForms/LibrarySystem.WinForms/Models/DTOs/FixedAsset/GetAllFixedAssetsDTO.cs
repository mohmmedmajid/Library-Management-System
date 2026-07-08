namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllFixedAssetsDTO
    {
        public int CategoryID { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ResponsibleEmployee { get; set; }
    }
}