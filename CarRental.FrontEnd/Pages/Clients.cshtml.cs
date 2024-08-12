using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarRental.FrontEnd.Pages
{
    public class ClientsModel : PageModel
    {
        private readonly ICarRentService _carRentService;
        public List<Client> allClients;

        public ClientsModel(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }
        public async Task OnGet()
        {
            allClients = await _carRentService.GetAllClientsFromDb();
        }
    }
}
