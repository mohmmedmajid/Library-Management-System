using API_1.DTOs.PaymentMethod;
using API_1.Models;
using API_1.Repositories.Interfaces;
using API_1.Services.Interfaces;

namespace API_1.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }
      
        public async Task<int> CreateAsync(CreatePaymentMethodDTO dto)
        {
            
            if (string.IsNullOrWhiteSpace(dto.MethodName))
                throw new ArgumentException("Method name is required");

            if (string.IsNullOrWhiteSpace(dto.MethodNameAr))
                throw new ArgumentException("Method name (Arabic) is required");


            var paymentMethod = new PaymentMethod
            {
                MethodName = dto.MethodName.Trim(),
                MethodNameAr = dto.MethodNameAr.Trim(),
                DisplayOrder = dto.DisplayOrder
            };

         
            return await _paymentMethodRepository.InsertAsync(paymentMethod);
        }

      
        public async Task<bool> UpdateAsync(UpdatePaymentMethodDTO dto)
        {
          
            if (string.IsNullOrWhiteSpace(dto.MethodName))
                throw new ArgumentException("Method name is required");

            if (string.IsNullOrWhiteSpace(dto.MethodNameAr))
                throw new ArgumentException("Method name (Arabic) is required");

           
            var paymentMethod = new PaymentMethod
            {
                PaymentMethodID = dto.PaymentMethodID,
                MethodName = dto.MethodName.Trim(),
                MethodNameAr = dto.MethodNameAr.Trim(),
                IsActive = dto.IsActive,
                DisplayOrder = dto.DisplayOrder
            };

           
            return await _paymentMethodRepository.UpdateAsync(paymentMethod);
        }

      
        public async Task<bool> DeleteAsync(int paymentMethodId)
        {
           
            var paymentMethod = await _paymentMethodRepository.GetByIdAsync(paymentMethodId);
            if (paymentMethod == null)
                throw new Exception("Payment method not found");

           
            return await _paymentMethodRepository.DeleteAsync(paymentMethodId);
        }

    
        public async Task<PaymentMethod?> GetByIdAsync(int paymentMethodId)
        {
            return await _paymentMethodRepository.GetByIdAsync(paymentMethodId);
        }

     
        public async Task<List<PaymentMethod>> GetAllAsync(bool? isActive = null)
        {
            return await _paymentMethodRepository.GetAllAsync(isActive);
        }
    }
}