using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : Controller
    {
        private readonly ICarRentService _carRentService;
        public CarsController(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        [HttpGet("GetAllElectricCars")]
        public IActionResult GetAllElectricCars()
        {
            var allEVCars = _carRentService.GetAllElectricCars();
            return Ok(allEVCars);
        }

        [HttpGet("GetElectricCarById")]
        public IActionResult GetElectricCarById(int id)
        {
            var evCar = _carRentService.GetElectricCarById(id);
            return Ok(evCar);
        }

        [HttpPost("InsertElectricCar")]
        public IActionResult InsertElectricCar(ElectricCar car)
        {
            try
            {
                _carRentService.AddNewCar(car);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateElectricCar")]
        public IActionResult UpdateElectricCar(ElectricCar car)
        {
            try
            {
                _carRentService.UpdateElectricCarInfo(car);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        //OIL CARS TODO
    }
}
