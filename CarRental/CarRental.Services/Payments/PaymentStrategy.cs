using CarRental.DAL.Models;
using CarRental.Services.Payments.PriceComputors;
using System;
using System.Linq;

namespace CarRental.Services.Payments
{
    public class PaymentStrategy
    {
        private readonly IPaymentComputor[] _paymentComputors;

        public PaymentStrategy(IPaymentComputor[] paymentComputors)
        {
            _paymentComputors = paymentComputors;
        }

        public RentalPayment ComputePayment(PaymentInfo paymentInfo)
        {
            var price = GetPaymentComputor(paymentInfo).Compute(paymentInfo);
            return new RentalPayment()
            {
                Price = price
            };
        }

        private IPaymentComputor GetPaymentComputor(PaymentInfo paymentInfo)
        {
             var paymentComputor = _paymentComputors.FirstOrDefault(computor => 
                                            computor.GetCategoryName() == paymentInfo.CategoryName);

            if(paymentComputor == null)
            {
                throw new ApplicationException($"Payment computor for category: {paymentInfo.GetType()} not registered");
            }
            return paymentComputor;
        }

       
    }
}