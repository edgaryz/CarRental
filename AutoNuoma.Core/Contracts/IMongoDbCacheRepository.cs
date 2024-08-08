using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IMongoDbCacheRepository
    {
        Task AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int id);
        Task AddClient(Client employee);
        Task<Client> GetClientById(int id);
    }
}
