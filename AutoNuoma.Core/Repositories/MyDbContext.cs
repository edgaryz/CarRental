using CarRental.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Core.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<ElectricCar> ElectricCars { get; set; }
        public DbSet<OilFuelCar> OilFuelCars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeBaseSalary> EmployeeBaseSalaries { get; set; }
        public DbSet<RentOrder> RentOrders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=car_rental_efdb;Integrated Security=True;TrustServerCertificate=true;");
        }

    }
}
