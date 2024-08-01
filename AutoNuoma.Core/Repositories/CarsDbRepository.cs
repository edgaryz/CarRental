using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarRental.Core.Repositories
{
    public class CarsDbRepository : ICarsRepository
    {
        private readonly string _dbConnectionString;
        public CarsDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }
        public void WriteCars(List<Car> carList)
        {
            throw new NotImplementedException();
        }

        public List<Car> ReadCars()
        {
            throw new NotImplementedException();
        }

        public List<ElectricCar> GetAllElectricCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<ElectricCar>(@"SELECT id, brand, model, rent_price AS RentPrice, battery_capacity AS BatteryCapacity, battery_charging_time AS BatteryChargingTime FROM electric_cars").ToList();
            dbConnection.Close();
            return result;
        }

        public List<OilFuelCar> GetAllOilFuelCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<OilFuelCar>(@"SELECT id, brand, model, rent_price AS RentPrice, fuel_consumption AS FuelConsumption FROM oil_fuel_cars").ToList();
            dbConnection.Close();
            return result;
        }

        public void InsertElectricCar(ElectricCar ev)
        {
            string sqlCommand = "INSERT INTO electric_cars " +
                "(brand, model, rent_price, battery_capacity, battery_charging_time)" +
                "VALUES" +
                "(@Brand, @Model, @RentPrice, @BatteryCapacity, @BatteryChargingTime)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, ev);
            }
        }

        public void InsertOilFuelCar(OilFuelCar v)
        {
            string sqlCommand = "INSERT INTO oil_fuel_cars " +
                "(brand, model, rent_price, fuel_consumption)" +
                "VALUES" +
                "(@Brand, @Model, @RentPrice, @FuelConsumption)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, v);
            }
        }

        public Car GetElectricCarById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.QueryFirst<ElectricCar>(
                @"SELECT id, brand, model, rent_price AS RentPrice, battery_capacity AS BatteryCapacity, battery_charging_time AS BatteryChargingTime 
                  FROM electric_cars WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }

        public Car GetOilFuelCarById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.QueryFirst<OilFuelCar>(
                @"SELECT id, brand, model, rent_price AS RentPrice, fuel_consumption AS FuelConsumption 
                  FROM oil_fuel_cars WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }
    }
}
