using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployeesFromDb();
        Employee GetEmployeeById(int id);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
