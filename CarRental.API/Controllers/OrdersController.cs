using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICarRentService _carRentService;
        public OrdersController(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var allOrders = _carRentService.GetAllOrders();
            return Ok(allOrders);
        }

        [HttpGet("GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            var client = _carRentService.GetOrderById(id);
            return Ok(client);
        }

        [HttpPost("InsertElectricCarOrder")]
        public IActionResult InsertElectricCarOrder(RentOrder order)
        {
            try
            {
                _carRentService.CreateElectricCarOrder(order);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost("InsertOilFuelCarOrder")]
        public IActionResult InsertOilFuelCarOrder(RentOrder order)
        {
            try
            {
                _carRentService.CreateOilFuelCarOrder(order);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

/*        [HttpPut("UpdateClient")]///////////
        public IActionResult UpdateClient(Client client)
        {
            try
            {
                _carRentService.UpdateClient(client);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }*/
    }
}
