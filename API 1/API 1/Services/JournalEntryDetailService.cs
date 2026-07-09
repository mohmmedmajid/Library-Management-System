using API_1.DTOs.JournalEntryDetail;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class JournalEntryDetailService : IJournalEntryDetailService
    {
        private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IChartOfAccountRepository _chartOfAccountRepository;

        public JournalEntryDetailService(
            IJournalEntryDetailRepository journalEntryDetailRepository,
            IJournalEntryRepository journalEntryRepository,
            IChartOfAccountRepository chartOfAccountRepository)
        {
            _journalEntryDetailRepository = journalEntryDetailRepository;
            _journalEntryRepository = journalEntryRepository;
            _chartOfAccountRepository = chartOfAccountRepository;
        }

        public async Task<int> CreateAsync(CreateJournalEntryDetailDTO dto)
        {
            if (dto.JournalEntryID <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            var journalEntry = await _journalEntryRepository.GetByIdAsync(dto.JournalEntryID);
            if (journalEntry == null)
                throw new InvalidOperationException("Journal entry not found");

            if (journalEntry.Status == "Posted")
                throw new InvalidOperationException("Cannot add details to posted journal entry");

            var account = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (account == null)
                throw new InvalidOperationException("Account not found");

            if (!account.AllowPosting)
                throw new InvalidOperationException("This account does not allow posting");

            var detail = new JournalEntryDetail
            {
                JournalEntryID = dto.JournalEntryID,
                LineNumber = dto.LineNumber,
                AccountID = dto.AccountID,
                Amount = dto.Amount,
                IsDebit = dto.IsDebit,
                Description = dto.Description?.Trim()
            };

            return await _journalEntryDetailRepository.InsertAsync(detail);
        }

        public async Task<bool> UpdateAsync(UpdateJournalEntryDetailDTO dto)
        {
            if (dto.JournalEntryDetailID <= 0)
                throw new ArgumentException("Invalid journal entry detail ID");

            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            var account = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (account == null)
                throw new InvalidOperationException("Account not found");

            if (!account.AllowPosting)
                throw new InvalidOperationException("This account does not allow posting");

            var detail = new JournalEntryDetail
            {
                JournalEntryDetailID = dto.JournalEntryDetailID,
                AccountID = dto.AccountID,
                Amount = dto.Amount,
                IsDebit = dto.IsDebit,
                Description = dto.Description?.Trim()
            };

            return await _journalEntryDetailRepository.UpdateAsync(detail);
        }

        public async Task<bool> DeleteAsync(int journalEntryDetailId)
        {
            if (journalEntryDetailId <= 0)
                throw new ArgumentException("Invalid journal entry detail ID");

            return await _journalEntryDetailRepository.DeleteAsync(journalEntryDetailId);
        }

        public async Task<List<JournalEntryDetail>> GetByJournalEntryIdAsync(int journalEntryId)
        {
            if (journalEntryId <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            return await _journalEntryDetailRepository.GetByJournalEntryIdAsync(journalEntryId);
        }

        public async Task<List<JournalEntryDetail>> GetByAccountAsync(GetDetailsByAccountDTO dto)
        {
            if (dto.AccountID <= 0)
                throw new ArgumentException("Invalid account ID");

            var account = await _chartOfAccountRepository.GetByIdAsync(dto.AccountID);
            if (account == null)
                throw new InvalidOperationException("Account not found");

            return await _journalEntryDetailRepository.GetByAccountAsync(
                dto.AccountID,
                dto.StartDate,
                dto.EndDate
            );
        }
    }
}