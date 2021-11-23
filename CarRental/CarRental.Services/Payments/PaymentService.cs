using CarRental.DAL.Consts;
using CarRental.DAL.Models;
using CarRental.Services.Payments.PriceComputors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services.Payments
{
    public interface IPaymentService
    {
        RentalPayment ComputePayment(CarReturn carReturn);
    }

    public class PaymentService : IPaymentService
    {
        public RentalPayment ComputePayment(CarReturn carReturn)
        {
          
            var paymentStrategy = new PaymentStrategy(              new IPaymentComputor[]{
                    new CompactComputor(),
                    new PremiumComputor()
                });


            paymentStrategy.ComputePayment(carReturn);



            //var paymentComputor = PaymentFactory.CreatePaymentComputor(carReturn);
            //var price = paymentComputor.ComputePrice();
           
            //return new RentalPayment()
            //{
            //    CarReturn = carReturn,
            //    Price = price
            //};
        }
    }

    

    public class BasePriceComputor
    {
        private readonly double _baseDayRental;
        private long _numberOfDays;
        private long _numberOfKilometers;
        private CarCategory _category;
        private DateTime _startDate;

        public void ResolveCarReturn(CarReturn carReturn)
        {
            _category = carReturn.CarRental.Car.Category;
            _startDate = carReturn.CarRental.StartDate;
            _numberOfDays = (long)carReturn.ReturnDate.Subtract(_startDate).TotalDays;
            _numberOfKilometers = carReturn.CurrentCarMilageKm - carReturn.CarRental.CurrentCarMilageKm;
        }

        public double ComputeBasePrice()
        {
            return _baseDayRental * _numberOfDays;
        }

    }

    public class CompactComputor : BasePriceComputor, IPaymentComputor
    {
        public string GetCategoryName()
        {
            return CategoriesNames.Compact;
        }

        public double Compute(CarReturn carReturn)
        {
            ResolveCarReturn(carReturn);
            return ComputeBasePrice();
        }
    }

    public class PremiumComputor : BasePriceComputor, IPaymentComputor
    {
        public double Compute(CarReturn carReturn)
        {
            ResolveCarReturn(carReturn);
            return ComputeBasePrice() * 1.2 + (_kilometerPrice * _numberOfKilometers);
        }

        public string GetCategoryName()
        {
            return CategoriesNames.Premium;
        }
     
    }

    public interface IPaymentComputor
    {
        double Compute(CarReturn carReturn);
        string GetCategoryName();
    }

    public class PaymentStrategy
    {
        private readonly IPaymentComputor[] _paymentComputors;

        public PaymentStrategy(IPaymentComputor[] paymentComputors)
        {
            _paymentComputors = paymentComputors;
        }

        public RentalPayment  ComputePayment(CarReturn carReturn)
        {
            var price = GetPaymentComputor(carReturn).Compute(carReturn);
            return new RentalPayment()
            {
                CarReturn = carReturn,
                Price = price
            };
        }

        private IPaymentComputor GetPaymentComputor(CarReturn carReturn)
        {
            var categoryName = carReturn.CarRental.Car.Category.Name;
            var paymentComputor = _paymentComputors.FirstOrDefault(computor => computor.GetCategoryName() == categoryName);

            if(paymentComputor == null)
            {
                throw new ApplicationException($"Payment computor for category: {categoryName} not registered");
            }
            return paymentComputor;
        }

       
    }
}