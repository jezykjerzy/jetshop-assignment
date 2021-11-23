using CarRental.DAL.Model;
using CarRental.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DAL
{
    // TODO Add error handling
    // TODO Cars controller coudld be extracted
    // TODO Introduce DTO with Automapper for Car instead of passing Category object
    public interface ICarRentalRepository
    {
        Task AddCarAsync(Car car);
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task UpdateCar(Car car);
        Task RemoveCarAsync(Car car);
        Task<List<CarCategory>> GetCategoriesAsync();
        Task<List<Car>> GetAvailableCarsAsync();
        Task AddCarRentalAsync(CarRentalEntry carRental);
        Task<CarRentalEntry> GetCarRentalAsync(int id);
        Task<List<CarRentalEntry>> GetAvailableRentalsAsync();
        Task AddCarReturnAsync(CarReturn carReturn);
    }

    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly CarRentalDbContext _context;

        public CarRentalRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        //TODO Add validation for existing cars
        public async Task AddCarAsync(Car car)
        {
            var category = await _context.Categories.SingleAsync(category => category.Id == car.Category.Id);
            car.Category = category;
            car.Available = true;
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }


        public async Task AddCarRentalAsync(CarRentalEntry carRental)
        {
            var existingCar = await _context.Cars.SingleAsync(car => car.Id == carRental.Car.Id);
            existingCar.Available = false;
            carRental.Car = existingCar;
            _context.CarRentals.Add(carRental);
            await _context.SaveChangesAsync();
            
        }

        public async Task AddCarReturnAsync(CarReturn carReturn)
        {
            var existingCarRentalEntry = await _context.CarRentals
                                                       .Include(carRental => carRental.Car)
                                                       .SingleAsync(carRental => carRental.Id == carReturn.CarRental.Id)
;

            existingCarRentalEntry.Car.Available = true;
            carReturn.CarRental = existingCarRentalEntry;
            _context.CarReturns.Add(carReturn);
            
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarAsync(int id)
        {
            return await _context.Cars
                                 .Include(car => car.Category)
                                 .SingleAsync(car => car.Id == id);
        }

        public async Task<CarRentalEntry> GetCarRentalAsync(int id)
        {
           return await _context.CarRentals
                          .Include(carRental => carRental.Car)
                          .SingleAsync(carRental => carRental.Id == id);
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
            return await _context.Cars
                                 .Where(car => car.Available)
                                 .Include(car => car.Category)
                                 .ToListAsync();
   
        }

        public async Task<List<CarRentalEntry>> GetAvailableRentalsAsync()
        {
            return await _context.CarRentals
                        .Include(carRental => carRental.Car)
                        .ThenInclude(car => car.Category)
                        .Where(carRental => false == carRental.Car.Available)
                        .ToListAsync();
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _context.Cars
                                 .Include(car => car.Category)
                                 .ToListAsync();
        }

        public Task<List<CarCategory>> GetCategoriesAsync()
        {
            return _context.Categories.ToListAsync();
        }

        public async Task RemoveCarAsync(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCar(Car carToUpdate)
        {
            //_context.Entry(car).State = EntityState.Modified;
            //_context.Entry(car).Entity.Category = car.Category;

            var existingCar = await _context.Cars
                                 .Include(car => car.Category)
                                 .SingleAsync(car => car.Id == carToUpdate.Id);
            existingCar.Category = carToUpdate.Category;
            existingCar.Name = carToUpdate.Name;
            // TODO update whole Car


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

       
    }
}
