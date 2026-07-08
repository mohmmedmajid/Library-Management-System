namespace LibrarySystem.WinForms.Models.DTOs
{
    public class GetAllMessageTemplatesDTO
    {
        public string MessageType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}