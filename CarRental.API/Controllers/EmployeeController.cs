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
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _carRentService.GetAllEmployeesFromDb();
            return Ok(allEmployees);
        }

        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _carRentService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost("InsertEmployee")]
        public IActionResult InsertEmployee(Employee employee)
        {
            try
            {
                _carRentService.InsertEmployee(employee);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                _carRentService.UpdateEmployee(employee);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }
    }
}
