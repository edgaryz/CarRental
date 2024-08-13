using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ICarRentService _carRentService;
        public EmployeeController(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var allEmployees = await _carRentService.GetAllEmployeesFromDb();
                return Ok(allEmployees);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _carRentService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                await _carRentService.InsertEmployee(employee);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                await _carRentService.UpdateEmployee(employee);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _carRentService.DeleteEmployee(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        //ALGOS ENDPOINTS TODO
    }
}
