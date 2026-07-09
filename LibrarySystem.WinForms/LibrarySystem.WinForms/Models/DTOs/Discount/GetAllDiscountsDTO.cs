namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllDiscountsDTO
    {
        public bool IsActive { get; set; } = true;
        public bool CurrentOnly { get; set; } = false;
    }
}