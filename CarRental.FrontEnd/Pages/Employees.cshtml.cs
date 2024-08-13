using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.FrontEnd.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly ICarRentService _carRentService;
        public List<Employee> allEmployees;

        public EmployeesModel(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }
        public async Task OnGet()
        {
            allEmployees = await _carRentService.GetAllEmployeesFromDb();
        }
    }
}
