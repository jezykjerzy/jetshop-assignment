using CarRental.DAL.Model;
using CarRental.DAL.Models;
using CarRental.Services;
using CarRental.Services.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.Controllers
{
    public enum Category
    {
        Compact,
        Premium,
        Minivan
    }
    //TODO Add validation for inputs
    [ApiController]
    [Route("api/[controller]")]
    public class CarRentalController : ControllerBase
    {
        private readonly ILogger<CarRentalController> _logger;
        private readonly ICarRentalService _carRentalService;

        public CarRentalController(ILogger<CarRentalController> logger, ICarRentalService carRentalService)
        {
            _logger = logger;
            _carRentalService = carRentalService;
        }


        [HttpGet("availablecars")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars()
        {
            return await _carRentalService.GetAvailableCarsAsync();
        }


        [HttpGet("availablerentals")]
        public async Task<ActionResult<IEnumerable<CarRentalEntry>>> GetAvailableRentals()
        {
            return await _carRentalService.GetAvailableRentalsAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CarRentalEntry>> GetCarRentalAsync(int id)
        {
            var carEntry = await _carRentalService.GetCarRentalAsync(id);

            if (carEntry == null)
            {
                return NotFound();
            }

            return carEntry;
        }


        [HttpPost("rental")]
        public async Task<ActionResult<CarRentalEntry>> PostCarRental(CarRentalEntry carRental)
        {
            // TODO check if car is not rented already
            // TODO check if date of rental and return are valid
            await _carRentalService.AddCarRentalAsync(carRental);

            //return CreatedAtAction("GetCarRentalAsync", new { id = carRental.Id }, carRental);
            return CreatedAtAction("GetCarRental", new { id = carRental.Id }, carRental);
        }


        [HttpPost("return")]
        public RentalPayment PostCarReturnAync(CarReturn carReturn)
        {
            // TODO check if customer did not exceed return date;
            // TODO computing payment and saving car return should be done in transaction
            var paymentInfo = new CompactPaymentInfo
            {
                CarReturn = carReturn,
                BaseDayRental = 50.0f

            };
            //var payment = _paymentService.ComputePayment(carReturn);

            var computors = new IPaymentComputor[]
            {
                new CompactCategoryComputor(),

            };
            var paymentStrategy = new PaymentStrategy(computors);
            var payment = paymentStrategy.ComputePayment(paymentInfo);
             
            //await _carRentalService.AddCarReturnAsync(carReturn);
            //await _carRentalService.AddRentalPayment(payment);

            return payment;
        }


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_carRentalService.GetCars());
        //}

    }
}
