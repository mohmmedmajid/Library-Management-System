using API_1.Models;

namespace API_1.Repositories.Interfaces
{
    public interface IJournalEntryDetailRepository
    {
        Task<int> InsertAsync(JournalEntryDetail detail);
        Task<bool> UpdateAsync(JournalEntryDetail detail);
        Task<bool> DeleteAsync(int journalEntryDetailId);
        Task<List<JournalEntryDetail>> GetByJournalEntryIdAsync(int journalEntryId);
        Task<List<JournalEntryDetail>> GetByAccountAsync(int accountId, DateTime? startDate = null, DateTime? endDate = null);
    }
}