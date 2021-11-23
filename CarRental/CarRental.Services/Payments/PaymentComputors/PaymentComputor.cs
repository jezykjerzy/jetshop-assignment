using System;

namespace CarRental.Services.Payments.PriceComputors
{
    public interface IPaymentComputor
    {
        double Compute(PaymentInfo paymentInfo);
        string GetCategoryName();
    }
}