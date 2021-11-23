namespace CarRental.Services.Payments.PriceComputors
{
    internal class MinivanPriceComputor : BasePriceComputor, IPriceComputor
    {
        private readonly double _kilometerPrice;
        private readonly long _numberOfKilometers;

        public MinivanPriceComputor(double baseDayRental, long numberOfDays, double kilometerPrice, long numberOfKilometers) : base(baseDayRental, numberOfDays)
        {
            _kilometerPrice = kilometerPrice;
            _numberOfKilometers = numberOfKilometers;
        }

        public double ComputePrice()
        {
            return ComputeBasePrice() * 1.7 + (_kilometerPrice * _numberOfKilometers * 1.5);
        }
    }
}