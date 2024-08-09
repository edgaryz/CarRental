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

        //Electric Cars
        public async Task<List<ElectricCar>> GetAllElectricCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryAsync<ElectricCar>(@"SELECT id, brand, model, rent_price AS RentPrice, battery_capacity AS BatteryCapacity, battery_charging_time AS BatteryChargingTime FROM electric_cars");
            dbConnection.Close();
            return result.ToList();
        }

        public async Task<ElectricCar> GetElectricCarById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryFirstAsync<ElectricCar>(
                @"SELECT id, brand, model, rent_price AS RentPrice, battery_capacity AS BatteryCapacity, battery_charging_time AS BatteryChargingTime 
                  FROM electric_cars WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }

        public async Task InsertElectricCar(ElectricCar ev)
        {
            string sqlCommand = "INSERT INTO electric_cars " +
                "(brand, model, rent_price, battery_capacity, battery_charging_time)" +
                "VALUES" +
                "(@Brand, @Model, @RentPrice, @BatteryCapacity, @BatteryChargingTime)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, ev);
            }
        }

        public async Task UpdateElectricCar(ElectricCar car)
        {
            string sqlCommand = "UPDATE electric_cars SET " +
                "brand = @Brand, model = @Model, rent_price = @RentPrice, battery_capacity = @BatteryCapacity, battery_charging_time = @BatteryChargingTime " +
                "WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, car);
            }
        }

        public async Task DeleteElectricCar(int id)
        {
            string sqlCommand = "DELETE FROM electric_cars WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }

        public async Task<int> GetElectricCarCountFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.ExecuteScalarAsync<int>(@"SELECT COUNT(id) FROM electric_cars");
            dbConnection.Close();
            return result;
        }

        //Oil Fuel Cars
        public async Task<List<OilFuelCar>> GetAllOilFuelCars()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryAsync<OilFuelCar>(@"SELECT id, brand, model, rent_price AS RentPrice, fuel_consumption AS FuelConsumption FROM oil_fuel_cars");
            dbConnection.Close();
            return result.ToList();
        }

        public async Task<OilFuelCar> GetOilFuelCarById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryFirstAsync<OilFuelCar>(
                @"SELECT id, brand, model, rent_price AS RentPrice, fuel_consumption AS FuelConsumption 
                  FROM oil_fuel_cars WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }

        public async Task InsertOilFuelCar(OilFuelCar v)
        {
            string sqlCommand = "INSERT INTO oil_fuel_cars " +
                "(brand, model, rent_price, fuel_consumption)" +
                "VALUES" +
                "(@Brand, @Model, @RentPrice, @FuelConsumption)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, v);
            }
        }

        public async Task UpdateOilFuelCar(OilFuelCar car)
        {
            string sqlCommand = "UPDATE oil_fuel_cars SET " +
                "brand = @Brand, model = @Model, rent_price = @RentPrice, fuel_consumption = @FuelConsumption " +
                "WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, car);
            }
        }

        public async Task DeleteOilFuelCar(int id)
        {
            string sqlCommand = "DELETE FROM oil_fuel_cars WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }

        public async Task<int> GetOilFuelCarCountFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.ExecuteScalarAsync<int>(@"SELECT COUNT(id) FROM oil_fuel_cars");
            dbConnection.Close();
            return result;
        }

        //File System
        public void WriteCars(List<Car> carList)
        {
            throw new NotImplementedException();
        }

        public List<Car> ReadCars()
        {
            throw new NotImplementedException();
        }
    }
}
