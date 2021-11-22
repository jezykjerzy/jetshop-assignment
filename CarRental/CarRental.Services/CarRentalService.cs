
using CarRental.DAL;
using CarRental.DAL.Model;
using CarRental.DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Services
{
    // TODO Think about splitting into CarService and CarRentalService
    // TODO Could be introduced CarModel in order not to expose all properties and converter like Automapper
    public interface ICarRentalService
    {
        //Task<CarModel> AddCarAsync(CarModel carModel);
        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task UpdateCarAsync(Car car);
        Task AddCarAsync(Car car);
        Task RemoveCarAsync(Car car);
        Task<List<CarCategory>> GetCategoriesAsync();
        Task<List<Car>> GetAvailableCarsAsync();
        //IList<CarModel> GetCars();
        //CarModel AddCar(CarModel carModel);
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

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _repository.GetCarsAsync();
        }

        public async Task<List<Car>> GetAvailableCarsAsync()
        {
            return await _repository.GetAvailableCarsAsync();
        }

        public async Task<List<CarCategory>> GetCategoriesAsync()
        {
            return await _repository.GetCategoriesAsync();
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _repository.UpdateCar(car);
        }

        public async Task AddCarAsync(Car car)
        {
            await _repository.AddCarAsync(car);
        }

        public async Task RemoveCarAsync(Car car)
        {
            await _repository.RemoveCarAsync(car);
        }
    }
}