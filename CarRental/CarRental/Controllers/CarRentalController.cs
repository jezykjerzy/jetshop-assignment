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
        private readonly IPaymentService _paymentService;

        public CarRentalController(ILogger<CarRentalController> logger, ICarRentalService carRentalService, IPaymentService paymentService)
        {
            _logger = logger;
            _carRentalService = carRentalService;
            _paymentService = paymentService;
        }


        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars()
        {
            return await _carRentalService.GetAvailableCarsAsync();
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


        [HttpPost]
        public async Task<ActionResult<CarRentalEntry>> PostCarRental(CarRentalEntry carRental)
        {
            // TODO check if car is not rented already
            // TODO check if date of rental and return are valid
            await _carRentalService.AddCarRentalAsync(carRental);

            return CreatedAtAction("GetCarRentalAsync", new { id = carRental.Id }, carRental);
        }

        class PaymentStrategy
        {

        }

        [HttpPost]
        public Task<ActionResult<RentalPayment>> PostCarReturnAync(CarReturn carReturn)
        {
            // TODO check if customer did not exceed return date;
            // TODO computing payment and saving car return should be done in transaction
            var payment = _paymentService.ComputePayment(carReturn);

             
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
