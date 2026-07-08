namespace LibrarySystem.WinForms.Models.DTOs
{
    public class ReverseJournalEntryDTO
    {
        public int JournalEntryID { get; set; }
        public int ReversedBy { get; set; }
    }
}