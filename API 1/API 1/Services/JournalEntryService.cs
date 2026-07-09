using API_1.DTOs.JournalEntry;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class JournalEntryService : IJournalEntryService
    {
        private readonly IJournalEntryRepository _journalEntryRepository;
        private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;
        private readonly ICostCenterRepository _costCenterRepository;

        public JournalEntryService(
            IJournalEntryRepository journalEntryRepository,
            IJournalEntryDetailRepository journalEntryDetailRepository,
            ICostCenterRepository costCenterRepository)
        {
            _journalEntryRepository = journalEntryRepository;
            _journalEntryDetailRepository = journalEntryDetailRepository;
            _costCenterRepository = costCenterRepository;
        }

        public async Task<string> GenerateNumberAsync()
        {
            return await _journalEntryRepository.GenerateNumberAsync();
        }

        public async Task<int> CreateAsync(CreateJournalEntryDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.EntryType))
                throw new ArgumentException("Entry type is required");

            var validEntryTypes = new[] { "Manual", "Automatic" };
            if (!validEntryTypes.Contains(dto.EntryType.Trim()))
                throw new ArgumentException("Entry type must be either 'Manual' or 'Automatic'");

            if (dto.CostCenterID.HasValue)
            {
                var costCenter = await _costCenterRepository.GetByIdAsync(dto.CostCenterID.Value);
                if (costCenter == null)
                    throw new InvalidOperationException("Cost center not found");
            }

            var journalEntry = new JournalEntry
            {
                JournalEntryNumber = dto.JournalEntryNumber.Trim(),
                EntryDate = dto.EntryDate,
                EntryType = dto.EntryType.Trim(),
                ReferenceType = dto.ReferenceType?.Trim(),
                ReferenceID = dto.ReferenceID,
                CostCenterID = dto.CostCenterID,
                Description = dto.Description?.Trim(),
                FiscalYear = dto.FiscalYear,
                FiscalMonth = dto.FiscalMonth,
                CreatedBy = dto.CreatedBy
            };

            return await _journalEntryRepository.InsertAsync(journalEntry);
        }

        public async Task<bool> UpdateAsync(UpdateJournalEntryDTO dto)
        {
            if (dto.JournalEntryID <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            var existing = await _journalEntryRepository.GetByIdAsync(dto.JournalEntryID);
            if (existing == null)
                throw new InvalidOperationException("Journal entry not found");

            if (existing.Status == "Posted")
                throw new InvalidOperationException("Cannot update posted journal entry");

            if (dto.CostCenterID.HasValue)
            {
                var costCenter = await _costCenterRepository.GetByIdAsync(dto.CostCenterID.Value);
                if (costCenter == null)
                    throw new InvalidOperationException("Cost center not found");
            }

            var journalEntry = new JournalEntry
            {
                JournalEntryID = dto.JournalEntryID,
                EntryDate = dto.EntryDate,
                CostCenterID = dto.CostCenterID,
                Description = dto.Description?.Trim()
            };

            return await _journalEntryRepository.UpdateAsync(journalEntry);
        }

        public async Task<bool> DeleteAsync(int journalEntryId)
        {
            if (journalEntryId <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            var existing = await _journalEntryRepository.GetByIdAsync(journalEntryId);
            if (existing == null)
                throw new InvalidOperationException("Journal entry not found");

            if (existing.Status == "Posted")
                throw new InvalidOperationException("Cannot delete posted journal entry. Use reversal instead.");

            return await _journalEntryRepository.DeleteAsync(journalEntryId);
        }

        public async Task<bool> PostAsync(PostJournalEntryDTO dto)
        {
            if (dto.JournalEntryID <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            if (dto.PostedBy <= 0)
                throw new ArgumentException("Invalid user ID");

            var existing = await _journalEntryRepository.GetByIdAsync(dto.JournalEntryID);
            if (existing == null)
                throw new InvalidOperationException("Journal entry not found");

            if (existing.Status == "Posted")
                throw new InvalidOperationException("Journal entry already posted");

            if (!existing.IsBalanced)
                throw new InvalidOperationException("Journal entry is not balanced. Total debits must equal total credits.");

            return await _journalEntryRepository.PostAsync(dto.JournalEntryID, dto.PostedBy);
        }

        public async Task<int> ReverseAsync(ReverseJournalEntryDTO dto)
        {
            if (dto.JournalEntryID <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            if (dto.ReversedBy <= 0)
                throw new ArgumentException("Invalid user ID");

            var existing = await _journalEntryRepository.GetByIdAsync(dto.JournalEntryID);
            if (existing == null)
                throw new InvalidOperationException("Journal entry not found");

            if (existing.Status != "Posted")
                throw new InvalidOperationException("Can only reverse posted entries");

            return await _journalEntryRepository.ReverseAsync(dto.JournalEntryID, dto.ReversedBy);
        }

        public async Task<JournalEntry?> GetByIdAsync(int journalEntryId)
        {
            if (journalEntryId <= 0)
                throw new ArgumentException("Invalid journal entry ID");

            return await _journalEntryRepository.GetByIdAsync(journalEntryId);
        }

        public async Task<List<JournalEntry>> GetAllAsync(GetAllJournalEntriesDTO dto)
        {
            return await _journalEntryRepository.GetAllAsync(
                dto.EntryType,
                dto.Status,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<JournalEntry>> GetByReferenceAsync(string referenceType, int referenceId)
        {
            if (string.IsNullOrWhiteSpace(referenceType))
                throw new ArgumentException("Reference type is required");

            if (referenceId <= 0)
                throw new ArgumentException("Invalid reference ID");

            return await _journalEntryRepository.GetByReferenceAsync(referenceType.Trim(), referenceId);
        }
    }
}