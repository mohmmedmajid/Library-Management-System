using API_1.DTOs.JournalEntry;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IJournalEntryService
    {
        Task<int> CreateAsync(CreateJournalEntryDTO dto);
        Task<bool> UpdateAsync(UpdateJournalEntryDTO dto);
        Task<bool> DeleteAsync(int journalEntryId);
        Task<JournalEntry?> GetByIdAsync(int journalEntryId);
        Task<List<JournalEntry>> GetAllAsync(GetAllJournalEntriesDTO dto);
        Task<List<JournalEntry>> GetByReferenceAsync(string referenceType, int referenceId);
        Task<bool> PostAsync(PostJournalEntryDTO dto);
        Task<int> ReverseAsync(ReverseJournalEntryDTO dto);
        Task<string> GenerateNumberAsync();
    }
}