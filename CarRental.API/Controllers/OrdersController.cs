using CarRental.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICarRentService _carRentService;
        public OrdersController(ICarRentService carRentService)
        {
            _carRentService = carRentService;
        }
    }
}
