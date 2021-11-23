using CarRental.DAL.Consts;
using CarRental.DAL.Models;
using CarRental.Services.Payments.PriceComputors;
using System;

namespace CarRental.Services.Payments
{
    public static class PaymentFactory
    {

        public static IPriceComputor CreatePaymentComputor(CarReturn carReturn, double baseDayRental, double kilometerPrice)
        {
            var category = carReturn.CarRental.Car.Category;
            var startDate = carReturn.CarRental.StartDate;
            var numberOfDays = (long) carReturn.ReturnDate.Subtract(startDate).TotalDays;
            var numberOfKilometers = carReturn.CurrentCarMilageKm - carReturn.CarRental.CurrentCarMilageKm;

            switch (category.Name)
            {
                case CategoriesNames.Compact:
                    return new CompactPriceComputor(baseDayRental, numberOfDays);
                case CategoriesNames.Premium:
                    return new PremiumPriceComputor(baseDayRental, numberOfDays, kilometerPrice, numberOfKilometers);
                case CategoriesNames.Minivan:
                    return new MinivanPriceComputor(baseDayRental, numberOfDays, kilometerPrice, numberOfKilometers);
                default:
                    throw new ApplicationException($"No category found with name: {category.Name}");
            }
        }
    }
}