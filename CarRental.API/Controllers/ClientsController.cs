using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ICarRentService _carRentService;
        public ClientsController(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        [HttpGet("GetAllClients")]
        public IActionResult GetAllClients()
        {
            var allClients = _carRentService.GetAllClientsFromDb();
            return Ok(allClients);
        }

        [HttpGet("GetClientById")]
        public IActionResult GetClientById(int id)
        {
            var client = _carRentService.GetClientById(id);
            return Ok(client);
        }

        [HttpPost("InsertClient")]
        public IActionResult InsertClient(Client client)
        {
            try
            {
                _carRentService.InsertClient(client);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateClient")]
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
        }
    }
}
