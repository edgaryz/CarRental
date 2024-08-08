using Amazon.Runtime.Internal.Util;
using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class CarRentService : ICarRentService
    {
        public readonly IClientService _clientsService;
        public readonly ICarsService _carsService;
        public readonly IRentOrderService _rentOrderService;
        public readonly IEmployeeService _employeesService;
        private List<Car> AllCars = new List<Car>();
        private List<RentOrder> AllOrders = new List<RentOrder>();
        private List<Employee> AllEmployees = new List<Employee>();
        public CarRentService() { }
        public CarRentService(IClientService clientsService, ICarsService carsService, IRentOrderService rentOrdersService, IEmployeeService employeesService)
        {
            _clientsService = clientsService;
            _carsService = carsService;
            _rentOrderService = rentOrdersService;
            _employeesService = employeesService;
        }

        //Electric Cars
        public async Task<List<ElectricCar>> GetAllElectricCars()
        {
            return await _carsService.GetAllElectricCars();
        }

        public async Task<ElectricCar> GetElectricCarById(int id)
        {
            return await _carsService.GetElectricCarById(id);
        }

        public async Task InsertElectricCar(ElectricCar car)
        {
            await _carsService.InsertElectricCar(car);
        }

        public async Task UpdateElectricCar(ElectricCar car)
        {
            await _carsService.UpdateElectricCar(car);
        }
        public async Task DeleteElectricCar(int id)
        {
            await _carsService.DeleteElectricCar(id);
        }

        //Oil Fuel Cars
        public async Task<List<OilFuelCar>> GetAllOilFuelCars()
        {
            return await _carsService.GetAllOilFuelCars();
        }

        public async Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            return await _carsService.GetOilFuelCarById(id);
        }

        public async Task InsertOilFuelCar(OilFuelCar car)
        {
            await _carsService.InsertOilFuelCar(car);
        }

        public async Task UpdateOilFuelCar(OilFuelCar car)
        {
            await _carsService.UpdateOilFuelCar(car);
        }

        public async Task DeleteOilFuelCar(int id)
        {
            await _carsService.DeleteOilFuelCar(id);
        }

        //Clients
        public async Task<List<Client>> GetAllClientsFromDb()
        {
            return await _clientsService.GetAllClientsFromDb();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _clientsService.GetClientById(id);
        }

        public async Task InsertClient(Client client)
        {
            await _clientsService.InsertClient(client);
        }

        public async Task UpdateClient(Client client)
        {
            await _clientsService.UpdateClient(client);
        }

        public async Task DeleteClient(int id)
        {
            await _clientsService.DeleteClient(id);
        }

        //Employees
        public async Task<List<Employee>> GetAllEmployeesFromDb()
        {
            return await _employeesService.GetAllEmployeesFromDb();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeesService.GetEmployeeById(id);
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _employeesService.InsertEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _employeesService.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeesService.DeleteEmployee(id);
        }

        //Orders
        public void CountTotalRentPrice()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(string clientName, string clientLastName, int autoId, DateTime orderStartDate, int orderDays)
        {
            Client client = _clientsService.FindClientByFirstNameAndLastName(clientName, clientLastName);

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

/*        public List<RentOrder> GetAllOrders()
        {
            return _rentOrderService.GetAllOrders();
        }*/

        public List<RentOrder> GetOrderByClient(Client client)
        {
            throw new NotImplementedException();
        }
        public void CreateElectricCarOrder(RentOrder newOrder)
        {
            _rentOrderService.CreateElectricCarOrder(newOrder);
        }

        public void CreateOilFuelCarOrder(RentOrder newOrder)
        {
            _rentOrderService.CreateOilFuelCarOrder(newOrder);
        }

        public RentOrder GetOrderById(int id)
        {
            return _rentOrderService.GetOrderById(id);
        }

        //File System
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
            return _clientsService.GetAllClientsFromFile();
        }
    }
}
