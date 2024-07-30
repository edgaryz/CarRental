using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class CarRentService : ICarRentService
    {
        public readonly IClientService _clientService;
        public readonly ICarsService _carsService;

        public CarRentService() { }
        public CarRentService(IClientService clientService, ICarsService carsService)
        {
            _clientService = clientService;
            _carsService = carsService;
        }
        public void CountTotalRentPrice()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(RentOrder order)
        {
            throw new NotImplementedException();
        }

        public List<RentOrder> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<RentOrder> GetOrderByClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            return _carsService.GetAllCars();
        }

        public void AddNewCar(Car car)
        {
            _carsService.AddCar(car);
        }

    }
}
