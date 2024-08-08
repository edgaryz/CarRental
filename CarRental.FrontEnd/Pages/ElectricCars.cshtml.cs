using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.FrontEnd.Pages
{
    public class ElectricCarsModel : PageModel
    {
        private readonly ICarRentService _carRentService;
        public List<ElectricCar> allEV;

        public ElectricCarsModel(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }
        public async Task OnGet()
        {
            allEV = await _carRentService.GetAllElectricCars();
        }
    }
}
