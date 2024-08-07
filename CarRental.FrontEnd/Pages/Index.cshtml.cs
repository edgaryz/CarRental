using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICarRentService _carRentService;
        public List<ElectricCar> allEV;
        public IndexModel(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        public void OnGet()
        {
            allEV = _carRentService.GetAllElectricCars();
        }
    }
}
