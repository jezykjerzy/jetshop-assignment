using CarRental.DAL.Model;
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
            _context.Add(car);
            await _context.SaveChangesAsync();
        }

        public async Task<Car> GetCarAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task RemoveCarAsync(Car car)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;

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
