using API_1.DTOs.TaxDeclaration;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class TaxDeclarationService : ITaxDeclarationService
    {
        private readonly ITaxDeclarationRepository _taxDeclarationRepository;
        private readonly ITaxTypeRepository _taxTypeRepository;

        public TaxDeclarationService(
            ITaxDeclarationRepository taxDeclarationRepository,
            ITaxTypeRepository taxTypeRepository)
        {
            _taxDeclarationRepository = taxDeclarationRepository;
            _taxTypeRepository = taxTypeRepository;
        }

        public async Task<int> CreateAsync(CreateTaxDeclarationDTO dto)
        {
            if (dto.TaxTypeID <= 0)
                throw new ArgumentException("Invalid tax type ID");

            var validTypes = new[] { "Monthly", "Quarterly", "Annual" };
            if (!validTypes.Contains(dto.DeclarationType.Trim()))
                throw new ArgumentException($"Invalid declaration type. Must be one of: {string.Join(", ", validTypes)}");

            if (dto.FiscalYear < 2000 || dto.FiscalYear > DateTime.Now.Year + 1)
                throw new ArgumentException("Invalid fiscal year");

            if (dto.DeclarationType == "Monthly")
            {
                if (!dto.FiscalMonth.HasValue || dto.FiscalMonth < 1 || dto.FiscalMonth > 12)
                    throw new ArgumentException("Fiscal month (1-12) is required for monthly declarations");
            }

            if (dto.DeclarationType == "Quarterly")
            {
                if (!dto.FiscalQuarter.HasValue || dto.FiscalQuarter < 1 || dto.FiscalQuarter > 4)
                    throw new ArgumentException("Fiscal quarter (1-4) is required for quarterly declarations");
            }

            if (dto.PeriodStartDate >= dto.PeriodEndDate)
                throw new ArgumentException("Period start date must be before end date");

            var taxType = await _taxTypeRepository.GetByIdAsync(dto.TaxTypeID);
            if (taxType == null)
                throw new InvalidOperationException("Tax type not found");

            if (!taxType.IsActive)
                throw new InvalidOperationException("Tax type is not active");

            var declaration = new TaxDeclaration
            {
                TaxTypeID = dto.TaxTypeID,
                DeclarationType = dto.DeclarationType.Trim(),
                FiscalYear = dto.FiscalYear,
                FiscalMonth = dto.FiscalMonth,
                FiscalQuarter = dto.FiscalQuarter,
                PeriodStartDate = dto.PeriodStartDate,
                PeriodEndDate = dto.PeriodEndDate,
                CreatedBy = dto.CreatedBy
            };

            return await _taxDeclarationRepository.CreateAsync(declaration);
        }

        public async Task<bool> SubmitAsync(SubmitTaxDeclarationDTO dto)
        {
            if (dto.DeclarationID <= 0)
                throw new ArgumentException("Invalid declaration ID");

            var existing = await _taxDeclarationRepository.GetByIdAsync(dto.DeclarationID);
            if (existing == null)
                throw new InvalidOperationException("Tax declaration not found");

            if (existing.Status != "Draft")
                throw new InvalidOperationException("Only draft declarations can be submitted");

            return await _taxDeclarationRepository.SubmitAsync(dto.DeclarationID);
        }

        public async Task<bool> MarkAsPaidAsync(PayTaxDeclarationDTO dto)
        {
            if (dto.DeclarationID <= 0)
                throw new ArgumentException("Invalid declaration ID");

            if (dto.PaidAmount <= 0)
                throw new ArgumentException("Paid amount must be greater than zero");

            if (string.IsNullOrWhiteSpace(dto.PaymentReference))
                throw new ArgumentException("Payment reference is required");

            var existing = await _taxDeclarationRepository.GetByIdAsync(dto.DeclarationID);
            if (existing == null)
                throw new InvalidOperationException("Tax declaration not found");

            if (existing.Status == "Draft")
                throw new InvalidOperationException("Declaration must be submitted before payment");

            if (dto.PaidAmount > existing.RemainingAmount)
                throw new ArgumentException("Paid amount cannot exceed remaining amount");

            return await _taxDeclarationRepository.MarkAsPaidAsync(
                dto.DeclarationID,
                dto.PaidAmount,
                dto.PaymentReference.Trim()
            );
        }

        public async Task<TaxDeclaration?> GetByIdAsync(int declarationId)
        {
            if (declarationId <= 0)
                throw new ArgumentException("Invalid declaration ID");

            return await _taxDeclarationRepository.GetByIdAsync(declarationId);
        }

        public async Task<List<TaxDeclaration>> GetAllAsync(GetAllTaxDeclarationsDTO dto)
        {
            return await _taxDeclarationRepository.GetAllAsync(
                dto.TaxTypeID,
                dto.DeclarationType,
                dto.FiscalYear,
                dto.Status
            );
        }
    }
}
