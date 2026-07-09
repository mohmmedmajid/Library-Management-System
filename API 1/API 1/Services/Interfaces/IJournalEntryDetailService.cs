using API_1.DTOs.JournalEntryDetail;
using API_1.Models;

namespace API_1.Services.Interfaces
{
    public interface IJournalEntryDetailService
    {
        Task<int> CreateAsync(CreateJournalEntryDetailDTO dto);
        Task<bool> UpdateAsync(UpdateJournalEntryDetailDTO dto);
        Task<bool> DeleteAsync(int journalEntryDetailId);
        Task<List<JournalEntryDetail>> GetByJournalEntryIdAsync(int journalEntryId);
        Task<List<JournalEntryDetail>> GetByAccountAsync(GetDetailsByAccountDTO dto);
    }
}