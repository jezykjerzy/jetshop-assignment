using CarRental.DAL.Consts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Payments.PriceComputors
{
    // TODO Could be refactored to not duplicate code
    public class CompactCategoryComputor : IPaymentComputor
    {
        public double Compute(PaymentInfo paymentInfo)
        {
            return paymentInfo.BaseDayRental * paymentInfo.NumberOfDays;
        }

        public string GetCategoryName()
        {
            return CategoriesNames.Compact;
        }
    }
}
