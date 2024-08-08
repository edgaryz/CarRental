using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface ICarRentService
    {
        //Electric Cars
        Task<List<ElectricCar>> GetAllElectricCars();
        Task<ElectricCar> GetElectricCarById(int id);
        Task InsertElectricCar(ElectricCar ev);
        Task UpdateElectricCar(ElectricCar car);
        Task DeleteElectricCar(int id);
        //Oil Fuel Cars
        Task<List<OilFuelCar>> GetAllOilFuelCars();
        Task InsertOilFuelCar(OilFuelCar v);
        Task<OilFuelCar> GetOilFuelCarById(int id);
        Task UpdateOilFuelCar(OilFuelCar car);
        Task DeleteOilFuelCar(int id);
        //Client
        Task<List<Client>> GetAllClientsFromDb();
        Task<Client> GetClientById(int id);
        Task InsertClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
        List<Client> GetAllClientsFromFile();
        //Employee
        Task<List<Employee>> GetAllEmployeesFromDb();
        Task<Employee> GetEmployeeById(int id);
        Task InsertEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
        //Order
        void CreateOrder(string clientName, string clientLastName, int autoId, DateTime orderStartDate, int orderDays);
        void CountTotalRentPrice();
        List<RentOrder> GetOrderByClient(Client client);
        /*List<RentOrder> GetAllOrders();*/
        void CreateElectricCarOrder(RentOrder newOrder);
        void CreateOilFuelCarOrder(RentOrder newOrder);
        RentOrder GetOrderById(int id);
        //File System
        List<Car> GetAllCars();
        void AddNewCar(Car car);
    }
}
