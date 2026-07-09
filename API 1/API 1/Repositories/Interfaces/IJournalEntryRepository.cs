using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IJournalEntryRepository
    {
        Task<int> InsertAsync(JournalEntry journalEntry);
        Task<bool> UpdateAsync(JournalEntry journalEntry);
        Task<bool> DeleteAsync(int journalEntryId);
        Task<JournalEntry?> GetByIdAsync(int journalEntryId);
        Task<List<JournalEntry>> GetAllAsync(string? entryType = null, string? status = null, DateTime? startDate = null, DateTime? endDate = null);
        Task<List<JournalEntry>> GetByReferenceAsync(string referenceType, int referenceId);
        Task<bool> PostAsync(int journalEntryId, int postedBy);
        Task<int> ReverseAsync(int journalEntryId, int reversedBy);
        Task<string> GenerateNumberAsync();
    }
}