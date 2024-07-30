using CarRental.Core.Contracts;

namespace CarRental.Core.Services
{
    public class BusinessLogicService
    {
        public readonly ICarsService _carsService;
        public readonly ICarRentService _carRentService;
        public readonly IClientService _clientService;
        public BusinessLogicService() { }
        public BusinessLogicService(ICarsService carsService, ICarRentService carRentService, IClientService clientService)
        {
            _carsService = carsService;
            _carRentService = carRentService;
            _clientService = clientService;
        }
    }
}
