using CarRental.DAL.Consts;
using CarRental.DAL.Models;
using CarRental.Services.Payments.PriceComputors;
using System.Threading.Tasks;

namespace CarRental.Services.Payments
{

    public interface IPaymentService
    {   
        RentalPayment ComputePayment(CarReturn carReturn);
    }


    // TODO Resolve properly in DI
    public class PaymentService : IPaymentService
    {
        public RentalPayment ComputePayment(CarReturn carReturn)
        {
            var computors = new IPaymentComputor[]
            {
                new CompactCategoryComputor(),
                new PremiumCategoryComputor(),
                new MinivanCategoryComputor(),

            };
            var paymentStrategy = new PaymentStrategy(computors);

            var paymentInfo = CreatePaymentInfo(carReturn);
            var payment = paymentStrategy.ComputePayment(paymentInfo);
            return payment;
        }

        private PaymentInfo CreatePaymentInfo(CarReturn carReturn)
        {
            var numberOfDays = carReturn.ReturnDate.Subtract(carReturn.CarRental.StartDate).Days;
            var categoryName = carReturn.CarRental.Car.Category.Name;
            var numberOfKilometers = carReturn.CurrentCarMilageKm - carReturn.CarRental.CurrentCarMilageKm;
            // TODO Move BaseDayRental to db

            return new PaymentInfo
            {
                CategoryName = categoryName,
                BaseDayRental = 50.0f,
                NumberOfDays = numberOfDays,
                KilometerPrice = 10.0f,
                NumberOfKilometers = numberOfKilometers
            };
        }
    }
}