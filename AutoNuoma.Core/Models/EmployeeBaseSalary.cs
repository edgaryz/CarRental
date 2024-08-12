using CarRental.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Core.Models
{
    public class EmployeeBaseSalary
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public double BaseSalary { get; set; }
        public EmployeeBaseSalary() { }
        public EmployeeBaseSalary(Employee employee, double baseSalary)
        {
            Employee = employee;
            BaseSalary = baseSalary;
        }
    }
}
