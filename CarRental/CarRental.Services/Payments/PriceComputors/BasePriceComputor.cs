namespace CarRental.Services.Payments.PriceComputors
{
    public class BasePriceComputor
    {
        private readonly double _baseDayRental;
        private readonly long _numberOfDays;

        public BasePriceComputor(double baseDayRental, long numberOfDays)
        {
            _baseDayRental = baseDayRental;
            _numberOfDays = numberOfDays;
        }

        public double ComputeBasePrice()
        {
            return _baseDayRental * _numberOfDays;
        }

    }
}