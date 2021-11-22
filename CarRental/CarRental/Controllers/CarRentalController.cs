using CarRental.DAL.Model;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Car>>> GetAvailableCars()
        {
            return await _carRentalService.GetAvailableCarsAsync();
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
