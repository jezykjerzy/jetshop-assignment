using CarRental.DAL.Consts;
using CarRental.DAL.Models;
using CarRental.Services.Payments.PriceComputors;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services.Payments
{
    //public interface IPaymentService
    //{
    //    RentalPayment ComputePayment(CarReturn carReturn);
    //}

    //public class PaymentService : IPaymentService
    //{
    //    public RentalPayment ComputePayment(CarReturn carReturn)
    //    {
          
    //        var paymentStrategy = new PaymentStrategy(              new IPaymentComputor[]{
    //                new CompactComputor(),
    //                new PremiumComputor()
    //            });


    //        paymentStrategy.ComputePayment(carReturn);



    //        //var paymentComputor = PaymentFactory.CreatePaymentComputor(carReturn);
    //        //var price = paymentComputor.ComputePrice();
           
    //        //return new RentalPayment()
    //        //{
    //        //    CarReturn = carReturn,
    //        //    Price = price
    //        //};
    //    }
    //}

    

    //public class BasePriceComputor
    //{
    //    private long _numberOfDays;
    //    private long _numberOfKilometers;
    //    private CarCategory _category;
    //    private DateTime _startDate;

    //    public void ResolveCarReturn(CarReturn carReturn)
    //    {
    //        _category = carReturn.CarRental.Car.Category;
    //        _startDate = carReturn.CarRental.StartDate;
    //        _numberOfDays = (long)carReturn.ReturnDate.Subtract(_startDate).TotalDays;
    //        _numberOfKilometers = carReturn.CurrentCarMilageKm - carReturn.CarRental.CurrentCarMilageKm;
    //    }

    //    public double ComputeBasePrice()
    //    {
    //        return _baseDayRental * _numberOfDays;
    //    }

    //}

    //public class CompactComputor : BasePriceComputor, IPaymentComputor
    //{
    //    public string GetCategoryName()
    //    {
    //        return CategoriesNames.Compact;
    //    }

    //    public double Compute(CarReturn carReturn)
    //    {
    //        ResolveCarReturn(carReturn);
    //        return ComputeBasePrice();
    //    }
    //}

    //public class PremiumComputor : BasePriceComputor, IPaymentComputor
    //{
    //    public double Compute(CarReturn carReturn)
    //    {
    //        ResolveCarReturn(carReturn);
    //        return ComputeBasePrice() * 1.2 + (_kilometerPrice * _numberOfKilometers);
    //    }

    //    public string GetCategoryName()
    //    {
    //        return CategoriesNames.Premium;
    //    }
     
    //}

    public interface IPaymentComputor
    {
        double Compute<T>(IPaymentInfo paymentInfo) where T : IPaymentInfo;
        bool AppliesTo(Type type);
    }

    public class PaymentStrategy
    {
        private readonly IPaymentComputor[] _paymentComputors;

        public PaymentStrategy(IPaymentComputor[] paymentComputors)
        {
            _paymentComputors = paymentComputors;
        }

        public RentalPayment ComputePayment<T>(T paymentInfo) where T:IPaymentInfo
        {
            var price = GetPaymentComputor(paymentInfo).Compute<T>(paymentInfo);
            return new RentalPayment()
            {
                //CarReturn = carReturn,
                Price = price
            };
        }

        private IPaymentComputor GetPaymentComputor<T>(T paymentInfo)  where T: IPaymentInfo
        {
            var paymentComputor = _paymentComputors.FirstOrDefault(computor => computor.AppliesTo(paymentInfo.GetType()));

            if(paymentComputor == null)
            {
                throw new ApplicationException($"Payment computor for category: {paymentInfo.GetType()} not registered");
            }
            return paymentComputor;
        }

       
    }

    public abstract class PaymentComputor<TModel> : IPaymentComputor
        where TModel : IPaymentInfo
    {
        public virtual bool AppliesTo(Type provider)
        {
            return typeof(TModel).Equals(provider);
        }

        public double Compute<T>(IPaymentInfo paymentInfo) where T : IPaymentInfo
        {
            return Compute((TModel)paymentInfo);
        }

      

        protected abstract double Compute(TModel paymentInfo);
        //public string GetCategoryName()
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class PaymentInfo : IPaymentInfo
    {
        public CarReturn CarReturn { get; set; }
        public double BaseDayRental { get; set; }
    }

    public class CompactPaymentInfo : PaymentInfo
    {
    }

    public class PremiumPaymentInfo : PaymentInfo
    {
        public double KilometerPrice { get; set; }
        public long NumberOfKilometers { get; set; }
    }

    public interface IPaymentInfo
    {
    }

    public class CompactCategoryComputor : PaymentComputor<CompactPaymentInfo>
    {
        protected override double Compute(CompactPaymentInfo paymentInfo)
        {
            return paymentInfo.BaseDayRental
                * (paymentInfo.CarReturn.CurrentCarMilageKm - paymentInfo.CarReturn.CarRental.CurrentCarMilageKm);
        }
    }
}