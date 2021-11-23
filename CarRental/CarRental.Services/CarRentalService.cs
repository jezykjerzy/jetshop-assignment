
using CarRental.DAL;
using CarRental.DAL.Model;
using CarRental.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services
{
    // TODO Split into CarService and CarRentalService
    // TODO Should be introduced DTO in order not to expose all properties and converter like Automapper
    public interface ICarRentalService
    {
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task UpdateCarAsync(Car car);
        Task AddCarAsync(Car car);
        Task RemoveCarAsync(Car car);
        Task<List<CarCategory>> GetCategoriesAsync();
        Task<List<Car>> GetAvailableCarsAsync();
        Task<CarRentalEntry> GetCarRentalAsync(int id);
        Task AddCarRentalAsync(CarRentalEntry carRental);
        Task<List<CarRentalEntry>> GetAvailableRentalsAsync();
        Task AddCarReturnAsync(CarReturn carReturn);
    }

    public class CarRentalService : ICarRentalService
    {
        private readonly ICarRentalRepository _repository;

        public CarRentalService(ICarRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> GetCarAsync(int id)
        {
            return await _repository.GetCarAsync(id);
        }

        public async Task<CarRentalEntry> GetCarRentalAsync(int id)
        {
            return await _repository.GetCarRentalAsync(id);
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _repository.GetCarsAsync();
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
            return await _repository.GetAvailableCarsAsync();
        }

        public async Task<List<CarRentalEntry>> GetAvailableRentalsAsync()
        {
            return await _repository.GetAvailableRentalsAsync();
        }

        public async Task<List<CarCategory>> GetCategoriesAsync()
        {
            return await _repository.GetCategoriesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _repository.UpdateCar(car);
        }

        public async Task AddCarRentalAsync(CarRentalEntry carRental)
        {
            await _repository.AddCarRentalAsync(carRental);
        }

        public async Task AddCarAsync(Car car)
        {
            await _repository.AddCarAsync(car);
        }

        public async Task RemoveCarAsync(Car car)
        {
            await _repository.RemoveCarAsync(car);
        }

        public async Task AddCarReturnAsync(CarReturn carReturn)
        {

            await _repository.AddCarReturnAsync(carReturn);
        }
    }
}