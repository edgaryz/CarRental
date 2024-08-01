using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class CarRentService : ICarRentService
    {
        public readonly IClientService _clientService;
        public readonly ICarsService _carsService;
        public readonly IRentOrderService _rentOrderService;

        private List<Car> AllCars = new List<Car>();

        private List<RentOrder> AllOrders = new List<RentOrder>();

        public CarRentService() { }
        public CarRentService(IClientService clientService, ICarsService carsService, IRentOrderService rentOrderService)
        {
            _clientService = clientService;
            _carsService = carsService;
            _rentOrderService = rentOrderService;
        }
        public void CountTotalRentPrice()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(string clientName, string clientLastName, int autoId, DateTime orderStartDate, int orderDays)
        {
            Client client = _clientService.FindClientByFirstNameAndLastName(clientName, clientLastName);

            Car car = new Car();

            foreach (Car a in AllCars)
            {
                if (a.Id == autoId)
                    car = a;
            }

            RentOrder rentOrder = new RentOrder
            {
                Client = client,
                Car = car,
                OrderStartDate = orderStartDate,
                OrderDays = orderDays
            };
            AllOrders.Add(rentOrder);
        }

        public List<RentOrder> GetAllOrders()
        {
            return _rentOrderService.GetAllOrders();
        }

        public List<RentOrder> GetOrderByClient(Client client)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            if (AllCars.Count == 0)
                AllCars = _carsService.GetAllCars();
            return AllCars;
        }

        public void AddNewCar(Car car)
        {
            _carsService.InsertNewCar(car);
        }

        public List<Client> GetAllClientsFromFile()
        {
            return _clientService.GetAllClientsFromFile();
        }

        public List<ElectricCar> GetAllElectricCars()
        {
           return _carsService.GetAllElectricCars();
        }

        public List<OilFuelCar> GetAllOilFuelCars()
        {
            return _carsService.GetAllOilFuelCars();
        }

        public List<Client> GetAllClientsFromDb()
        {
            return _clientService.GetAllClientsFromDb();
        }

        public void InsertClient(Client client)
        {
            _clientService.InsertClient(client);
        }
    }
}
