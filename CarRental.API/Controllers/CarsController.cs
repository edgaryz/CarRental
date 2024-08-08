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

        //Electric Cars
        [HttpGet("GetAllElectricCars")]
        public async Task<IActionResult> GetAllElectricCars()
        {
            var allEVCars = await _carRentService.GetAllElectricCars();
            return Ok(allEVCars);
        }

        [HttpGet("GetElectricCarById")]
        public async Task<IActionResult> GetElectricCarById(int id)
        {
            var evCar = await _carRentService.GetElectricCarById(id);
            return Ok(evCar);
        }

        [HttpPost("InsertElectricCar")]
        public async Task<IActionResult> InsertElectricCar(ElectricCar car)
        {
            try
            {
                await _carRentService.InsertElectricCar(car);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateElectricCar")]
        public async Task<IActionResult> UpdateElectricCar(ElectricCar car)
        {
            try
            {
                await _carRentService.UpdateElectricCar(car);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteElectricCar")]
        public async Task<IActionResult> DeleteElectricCar(int id)
        {
                await _carRentService.DeleteElectricCar(id);
                return Ok();
        }

        //Oil Fuel Cars
        [HttpGet("GetAllOilFuelCars")]
        public async Task<IActionResult> GetAllOilFuelCars()
        {
            var allOFCCars = await _carRentService.GetAllOilFuelCars();
            return Ok(allOFCCars);
        }

        [HttpGet("GetOilFuelCarById")]
        public async Task<IActionResult> GetOilFuelCarById(int id)
        {
            var ofcCar = await _carRentService.GetOilFuelCarById(id);
            return Ok(ofcCar);
        }

        [HttpPost("InsertOilFuelCar")]
        public async Task<IActionResult> InsertOilFuelCar(OilFuelCar car)
        {
            try
            {
                await _carRentService.InsertOilFuelCar(car);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateOilFuelCar")]
        public async Task<IActionResult> UpdateOilFuelCar(OilFuelCar car)
        {
            try
            {
                await _carRentService.UpdateOilFuelCar(car);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteOilFuelCar")]
        public async Task<IActionResult> DeleteOilFuelCar(int id)
        {
            await _carRentService.DeleteOilFuelCar(id);
            return Ok();
        }
    }
}
