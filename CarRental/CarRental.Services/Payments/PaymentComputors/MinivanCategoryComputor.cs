using CarRental.DAL.Consts;
using CarRental.Services.Payments.PriceComputors;
using System;

namespace CarRental.Services.Payments
{
    public class MinivanCategoryComputor : IPaymentComputor
    {

        public double Compute(PaymentInfo paymentInfo)
        {
            return paymentInfo.BaseDayRental * paymentInfo.NumberOfDays * 1.7 +
                (paymentInfo.KilometerPrice * paymentInfo.NumberOfKilometers * 1.5);
        }

        public string GetCategoryName()
        {
            return CategoriesNames.Minivan;
        }
    }
}