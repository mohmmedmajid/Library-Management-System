namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllOffersDTO
    {
        public bool IsActive { get; set; } = true;
        public bool CurrentOnly { get; set; } = false;
    }
}