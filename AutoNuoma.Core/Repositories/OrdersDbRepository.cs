using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarRental.Core.Repositories
{
    public class OrdersDbRepository : IRentOrderRepository
    {

        private readonly string _dbConnectionString;
        public OrdersDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }
        public void CreateElectricCarOrder(RentOrder newOrder)
        {

            string sqlCommand = "INSERT INTO orders " +
                "(client_id, ev_car_id, order_start_date, order_days)" +
                "VALUES" +
                "(@ClientId, @ElectricCarId, @OrderStartDate, @OrderDays)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, newOrder);
            }
        }
        public void CreateOilFuelCarOrder(RentOrder newOrder)
        {

            string sqlCommand = "INSERT INTO orders " +
                "(client_id, oil_car_id, order_start_date, order_days)" +
                "VALUES" +
                "(@ClientId, @OilFuelCarId, @OrderStartDate, @OrderDays)";

            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, newOrder);
            }
        }

        public List<RentOrder> GetAllOrdersFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<RentOrder>(
                @"SELECT client_id As ClientId, ev_car_id AS ElectricCarId, oil_car_id AS OilFuelCarId, order_start_date AS OrderStartDate, order_days AS OrderDays FROM orders").ToList();
            dbConnection.Close();
            return result;
        }

        public List<RentOrder> GetOrderByClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
