using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarRental.Core.Repositories
{
    public class OrdersDbRepository : IOrderRepository
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
                sqlCommand = "INSERT INTO orders " +
                    "(client_id, ev_car_id, order_start_date, order_days)" +
                    "VALUES" +
                    "(@clientId, @ev_car_id, @order_start_date, order_days)";//TODO
            }
            else
            {
                sqlCommand = "INSERT INTO orders " +
                    "(client_id, oil_car_id, order_start_date, order_days)" +
                    "VALUES" +
                    "(@clientId, @oil_car_id, @order_start_date, order_days)";//TODO
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
            var result = dbConnection.Query<RentOrder>(@"SELECT id, client_id, ev_car_id, oil_car_id, order_start_date, order_days FROM orders").ToList();
            dbConnection.Close();
            return result;
        }

        public List<RentOrder> GetOrderByClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
