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
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var allClients = await _carRentService.GetAllClientsFromDb();
                return Ok(allClients);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("GetClientById")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await _carRentService.GetClientById(id);
                return Ok(client);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("InsertClient")]
        public async Task<IActionResult> InsertClient(Client client)
        {
            try
            {
                await _carRentService.InsertClient(client);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            try
            {
                await _carRentService.UpdateClient(client);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                await _carRentService.DeleteClient(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
