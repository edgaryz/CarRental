using CarRental.Core.Contracts;
using CarRental.Core.Models;

namespace CarRental.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMongoDbCacheRepository _cache;
        private List<Employee> AllEmployees = new List<Employee>();
        public EmployeeService(IEmployeeRepository employeeRepository, IMongoDbCacheRepository cache)
        {
            _employeeRepository = employeeRepository;
            _cache = cache;
        }

        public async Task<List<Employee>> GetAllEmployeesFromDb()
        {
            var empList = await _cache.GetEmployeeList();

            if (empList != null)
            {
                return empList;
            }

            empList = await _employeeRepository.GetAllEmployeesFromDb();
            await _cache.InsertEmployeeList(empList);
            return empList;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var emp = await _cache.GetEmployeeById(id);

            if (emp != null)
            {
                return emp;
            }

            emp = await _employeeRepository.GetEmployeeById(id);
            await _cache.InsertEmployee(emp);
            return emp;
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _employeeRepository.InsertEmployee(employee);
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _employeeRepository.UpdateEmployee(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }
    }
}
