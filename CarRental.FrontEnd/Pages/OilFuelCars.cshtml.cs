using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.FrontEnd.Pages
{
    public class OilFuelCarsModel : PageModel
    {
        private readonly ICarRentService _carRentService;
        public List<OilFuelCar> allOFC;

        public OilFuelCarsModel(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }

        public async Task OnGet()
        {
            allOFC = await _carRentService.GetAllOilFuelCars();
        }
    }
}
