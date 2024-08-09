using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IMongoDbCacheRepository
    {
        //Electric Cars
        Task<List<ElectricCar>> GetElectricCarList();
        Task<ElectricCar> GetElectricCarById(int id);
        Task InsertElectricCarList(List<ElectricCar> evList);
        Task InsertElectricCar(ElectricCar ev);
        Task ClearElectricCarCache();

        //Oil Fuel Cars
        Task<List<OilFuelCar>> GetOilFuelCarList();
        Task<OilFuelCar> GetOilFuelCarById(int id);
        Task InsertOilFuelCarList(List<OilFuelCar> ofcList);
        Task InsertOilFuelCar(OilFuelCar ofc);
        Task ClearOilFuelCarsCache();

        //Clients
        Task<List<Client>> GetClientList();
        Task<Client> GetClientById(int id);
        Task InsertClientList(List<Client> clnList);
        Task InsertClient(Client client);
        Task ClearClientsCache();

        //Employees
        Task<List<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeById(int id);
        Task InsertEmployeeList(List<Employee> empList);
        Task InsertEmployee(Employee employee);
        Task ClearEmployeeCache();
    }
}
