using CarRental.Core.Models;
using CarRental.Core.Services;

namespace CarRental.Core.Contracts
{
    public interface ICarRentService
    {
        void CreateOrder(string clientName, string clientLastName, int autoId, DateTime orderStartDate, int orderDays);
        void CountTotalRentPrice();
        List<RentOrder> GetOrderByClient(Client client);
        List<RentOrder> GetAllOrders();
        List<Car> GetAllCars();
        void AddNewCar(Car car);
        List<Client> GetAllClientsFromFile();
        List<Client> GetAllClientsFromDb();
        void InsertClient(Client client);
        List<ElectricCar> GetAllElectricCars();
        List<OilFuelCar> GetAllOilFuelCars();
        ElectricCar GetElectricCarById(int id);
        OilFuelCar GetOilFuelCarById(int id);
        void CreateElectricCarOrder(RentOrder newOrder);
        void CreateOilFuelCarOrder(RentOrder newOrder);
        List<Employee> GetAllEmployeesFromDb();
        Employee GetEmployeeById(int id);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
