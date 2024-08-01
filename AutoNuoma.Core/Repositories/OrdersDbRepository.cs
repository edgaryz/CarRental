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
        public void CreateOrder(RentOrder newOrder, Car car, Client client)
        {

            //reikia GetClientIdByFirstNameAndLastName()
            //int clientId = client.Id;
            int clientId = 0;
            string sqlCommand = "";
            if (car is ElectricCar)
            {

            }
            else
            {

            }

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
