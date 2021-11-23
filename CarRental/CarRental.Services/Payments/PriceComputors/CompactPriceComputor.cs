namespace CarRental.Services.Payments.PriceComputors
{
    class CompactPriceComputor : BasePriceComputor, IPriceComputor
    {
        public CompactPriceComputor(double baseDayRental, long numberOfDays) : base(baseDayRental, numberOfDays)
        {
        }

        public double ComputePrice()
        {
            return ComputeBasePrice();
        }
    }
}