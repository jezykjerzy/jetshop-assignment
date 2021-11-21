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
    public interface ICarRentalRepository
    {
        Task AddCarAsync(Car car);
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task UpdateCar(Car car);
        Task RemoveCarAsync(Car car);
        Task<List<CarCategory>> GetCategoriesAsync();
    }

    public class CarRentalRepository : ICarRentalRepository
    {
        private readonly CarRentalDbContext _context;

        public CarRentalRepository(CarRentalDbContext context)
        {
            _context = context;
        }
        public async Task AddCarAsync(Car car)
        {
            var category = await _context.Categories.SingleAsync(category => category.Id == car.Category.Id);
            car.Category = category;
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarAsync(int id)
        {
            return await _context.Cars
                                 .Include(car => car.Category)
                                 .SingleAsync(car => car.Id == id);
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
