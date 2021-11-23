namespace CarRental.Services.Payments.PriceComputors
{
    internal class PremiumPriceComputor : BasePriceComputor, IPriceComputor
    {
        private readonly double _kilometerPrice;
        private readonly long _numberOfKilometers;

        public PremiumPriceComputor(double baseDayRental, long numberOfDays, double kilometerPrice, long numberOfKilometers): base(baseDayRental, numberOfDays)
        {
            _kilometerPrice = kilometerPrice;
            _numberOfKilometers = numberOfKilometers;
        }

        public double ComputePrice()
        {
            return ComputeBasePrice() * 1.2 + (_kilometerPrice * _numberOfKilometers);
        }
    }
}