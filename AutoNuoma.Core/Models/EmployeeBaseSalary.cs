using CarRental.Core.Enums;

namespace CarRental.Core.Models
{
    public class EmployeeBaseSalary : Employee
    {
        public int EmployeeId { get; set; }
        public double BaseSalary { get; set; }
        public EmployeeBaseSalary() { }
        public EmployeeBaseSalary(int employeeId, double baseSalary)
        {
            EmployeeId = employeeId;
            BaseSalary = baseSalary;
        }
        public EmployeeBaseSalary(int employeeId, double baseSalary, int id, string firstName, string lastName, Position position) : base(id, firstName, lastName, position)
        {
            EmployeeId = employeeId;
            BaseSalary = baseSalary;
        }


    }
}
