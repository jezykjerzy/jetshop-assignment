using CarRental.DAL.Models;

namespace CarRental.Services.Payments
{
    public interface IPaymentInfo
    {
    }

    public class PaymentInfo : IPaymentInfo
    {
        public double BaseDayRental { get; set; }
        public int NumberOfDays { get; internal set; }
        public double KilometerPrice { get; set; }
        public long NumberOfKilometers { get; set; }
        public string CategoryName { get; internal set; }
    }
}