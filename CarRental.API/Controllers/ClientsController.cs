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
            var allClients = await _carRentService.GetAllClientsFromDb();
            return Ok(allClients);
        }

        [HttpGet("GetClientById")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var client = await _carRentService.GetClientById(id);
            return Ok(client);
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
            await _carRentService.DeleteClient(id);
            return Ok();
        }
    }
}
