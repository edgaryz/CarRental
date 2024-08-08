using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesFromDb();
        Task<Employee> GetEmployeeById(int id);
        Task InsertEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int id);
    }
}
