using CarRental.Core.Models;

namespace CarRental.Core.Contracts
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployeesFromDb();
        public Employee GetEmployeeById(int id);
        public void InsertEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(int id);
    }
}
