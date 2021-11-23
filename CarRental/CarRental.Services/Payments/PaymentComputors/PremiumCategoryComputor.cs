using CarRental.DAL.Consts;
using CarRental.Services.Payments.PriceComputors;
using System;

namespace CarRental.Services.Payments
{
    public class PremiumCategoryComputor : IPaymentComputor
    {
        public double Compute(PaymentInfo paymentInfo)
        {
            return paymentInfo.BaseDayRental * paymentInfo.NumberOfDays * 1.2 +
                   (paymentInfo.KilometerPrice * paymentInfo.NumberOfKilometers);
        }

        public string GetCategoryName()
        {
            return CategoriesNames.Premium;
        }
    }
}