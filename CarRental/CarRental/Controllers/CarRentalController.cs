using CarRental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarRental.Controllers
{
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

        //[HttpGet]
        //public IActionResult RegisterCarRental()
        //{
        //    return Ok(_carRentalService.GetCars());
        //}

        //[HttpGet]
        //public IActionResult RegisterCarReturn()
        //{
        //    return Ok(_carRentalService.GetCars());
        //}


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_carRentalService.GetCars());
        //}

    }
}
