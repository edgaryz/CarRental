using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Core.Repositories
{
    public class EmployeesEFDbRepository : IEmployeeRepository
    {
        public async Task<List<Employee>> GetAllEmployeesFromDb()
        {
            using (var context = new MyDbContext())
            {
                List<Employee> allEmployees = await context.Employees.ToListAsync();
                return allEmployees;
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            using (var context = new MyDbContext())
            {
                return await context.Employees.FindAsync(id);
            }
        }

        public async Task InsertEmployee(Employee employee)
        {
            using (var context = new MyDbContext())
            {
                await context.Employees.AddAsync(employee);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            using (var context = new MyDbContext())
            {
                await context.Employees
                    .Where(x => x.Id == employee.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.FirstName, employee.FirstName)
                        .SetProperty(y => y.LastName, employee.LastName)
                        .SetProperty(y => y.Position, employee.Position));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteEmployee(int id)
        {
            using (var context = new MyDbContext())
            {
                context.Employees.Remove(await context.Employees.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetEmployeeCountFromDb()
        {
            using (var context = new MyDbContext())
            {
                var allEmployeesCount = await context.Employees.CountAsync();
                return allEmployeesCount;
            }
        }
    }
}
