using API_1.DTOs.OtherRevenue;
using API_1.Models;
using API_1.Services.Interfaces;
using API_1.Repositories.Interfaces;

namespace API_1.Services
{
    public class OtherRevenueService : IOtherRevenueService
    {
        private readonly IOtherRevenueRepository _revenueRepository;
        private readonly IRevenueCategoryRepository _categoryRepository;
        private readonly ICustomerRepository _customerRepository;

        public OtherRevenueService(
            IOtherRevenueRepository revenueRepository,
            IRevenueCategoryRepository categoryRepository,
            ICustomerRepository customerRepository)
        {
            _revenueRepository = revenueRepository;
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
        }

        public async Task<int> CreateAsync(CreateOtherRevenueDTO dto)
        {
            await ValidateRevenueDTO(dto);

            var revenue = new OtherRevenue
            {
                RevenueCategoryID = dto.RevenueCategoryID,
                RevenueDate = dto.RevenueDate,
                Amount = dto.Amount,
                PaymentMethodID = dto.PaymentMethodID,
                ReferenceNumber = dto.ReferenceNumber?.Trim(),
                Description = dto.Description?.Trim(),
                CustomerID = dto.CustomerID,
                ReceiptNumber = dto.ReceiptNumber?.Trim(),
                IsRecurring = dto.IsRecurring,
                RecurringPeriod = dto.RecurringPeriod?.Trim(),
                Status = dto.Status?.Trim() ?? "Pending",
                CreatedBy = dto.CreatedBy
            };

            return await _revenueRepository.InsertAsync(revenue);
        }

        public async Task<bool> UpdateAsync(UpdateOtherRevenueDTO dto)
        {
            if (dto.RevenueID <= 0)
                throw new ArgumentException("Invalid revenue ID");

            await ValidateRevenueDTO(new CreateOtherRevenueDTO
            {
                RevenueCategoryID = dto.RevenueCategoryID,
                Amount = dto.Amount,
                PaymentMethodID = dto.PaymentMethodID,
                RevenueDate = dto.RevenueDate
            });

            var existing = await _revenueRepository.GetByIdAsync(dto.RevenueID);
            if (existing == null)
                throw new InvalidOperationException("Revenue not found");

            if (existing.Status == "Cancelled")
                throw new InvalidOperationException("Cannot update a cancelled revenue");

            var revenue = new OtherRevenue
            {
                RevenueID = dto.RevenueID,
                RevenueCategoryID = dto.RevenueCategoryID,
                RevenueDate = dto.RevenueDate,
                Amount = dto.Amount,
                PaymentMethodID = dto.PaymentMethodID,
                ReferenceNumber = dto.ReferenceNumber?.Trim(),
                Description = dto.Description?.Trim(),
                CustomerID = dto.CustomerID,
                ReceiptNumber = dto.ReceiptNumber?.Trim(),
                Status = dto.Status.Trim()
            };

            return await _revenueRepository.UpdateAsync(revenue);
        }

        public async Task<bool> DeleteAsync(int revenueId)
        {
            if (revenueId <= 0)
                throw new ArgumentException("Invalid revenue ID");

            var existing = await _revenueRepository.GetByIdAsync(revenueId);
            if (existing == null)
                throw new InvalidOperationException("Revenue not found");

            return await _revenueRepository.DeleteAsync(revenueId);
        }

        public async Task<OtherRevenue?> GetByIdAsync(int revenueId)
        {
            if (revenueId <= 0)
                throw new ArgumentException("Invalid revenue ID");

            return await _revenueRepository.GetByIdAsync(revenueId);
        }

        public async Task<List<OtherRevenue>> GetAllAsync(GetAllRevenuesDTO dto)
        {
            return await _revenueRepository.GetAllAsync(
                dto.RevenueCategoryID,
                dto.CustomerID,
                dto.Status,
                dto.StartDate,
                dto.EndDate
            );
        }

        public async Task<List<OtherRevenue>> GetRecurringRevenuesAsync()
        {
            return await _revenueRepository.GetRecurringRevenuesAsync();
        }

        public async Task<(decimal TotalAmount, int TotalCount)> GetRevenueSummaryAsync(GetRevenueSummaryDTO dto)
        {
            if (dto.EndDate < dto.StartDate)
                throw new ArgumentException("End date must be after start date");

            return await _revenueRepository.GetSummaryAsync(dto.StartDate, dto.EndDate);
        }

        public async Task<List<OtherRevenue>> GetPendingRevenuesAsync()
        {
            var allRevenues = await _revenueRepository.GetAllAsync(
                categoryId: null,
                customerId: null,
                status: "Pending",
                startDate: null,
                endDate: null
            );

            return allRevenues;
        }

        private async Task ValidateRevenueDTO(CreateOtherRevenueDTO dto)
        {
            if (dto.RevenueCategoryID <= 0)
                throw new ArgumentException("Invalid revenue category ID");

            if (dto.Amount <= 0)
                throw new ArgumentException("Amount must be greater than zero");

            if (dto.PaymentMethodID <= 0)
                throw new ArgumentException("Invalid payment method ID");

            if (dto.RevenueDate > DateTime.Now)
                throw new ArgumentException("Revenue date cannot be in the future");

            var category = await _categoryRepository.GetByIdAsync(dto.RevenueCategoryID);
            if (category == null)
                throw new InvalidOperationException("Revenue category not found");

            if (!category.IsActive)
                throw new InvalidOperationException("This revenue category is not active");

            if (dto.CustomerID.HasValue && dto.CustomerID > 0)
            {
                var customer = await _customerRepository.GetByIdAsync(dto.CustomerID.Value);
                if (customer == null)
                    throw new InvalidOperationException("Customer not found");

                if (!customer.IsActive)
                    throw new InvalidOperationException("This customer is not active");
            }

            if (!string.IsNullOrWhiteSpace(dto.Status))
            {
                ValidateStatus(dto.Status);
            }

            if (dto.IsRecurring && !string.IsNullOrWhiteSpace(dto.RecurringPeriod))
            {
                ValidateRecurringPeriod(dto.RecurringPeriod);
            }
        }

        private void ValidateStatus(string status)
        {
            var validStatuses = new[] { "Pending", "Received", "Cancelled" };
            if (!validStatuses.Contains(status.Trim()))
                throw new ArgumentException($"Invalid status. Must be one of: {string.Join(", ", validStatuses)}");
        }

        private void ValidateRecurringPeriod(string period)
        {
            var validPeriods = new[] { "Monthly", "Quarterly", "Yearly" };
            if (!validPeriods.Contains(period.Trim()))
                throw new ArgumentException($"Invalid recurring period. Must be one of: {string.Join(", ", validPeriods)}");
        }
    }
}