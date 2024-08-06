using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarRental.Core.Repositories
{
    public class ClientsDbRepository : IClientRepository
    {
        private readonly string _dbConnectionString;
        public ClientsDbRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }

        public List<Client> ReadClients()
        {
            throw new NotImplementedException();
        }

        public void WriteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void WriteClients(List<Client> clientList)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllClientsFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<Client>(@"SELECT id, first_name AS FirstName, last_name AS LastName, year_of_birth AS YearOfBirth FROM clients").ToList();
            dbConnection.Close();
            return result;
        }

        public void InsertClient(Client client)
        {
            string sqlCommand = "INSERT INTO clients " +
                "(first_name, last_name, year_of_birth)" +
                "VALUES" +
                "(@FirstName, @LastName, @YearOfBirth)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, client);
            }
        }

        public Client GetClientById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.QueryFirst<Client>(
                @"SELECT id, first_name AS FirstName, last_name AS LastName, year_of_birth AS YearOfBirth 
                  FROM clients WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }

        public void UpdateClient(Client client)
        {
            string sqlCommand = "UPDATE clients SET " +
                "first_name = @FirstName, last_name = @LastName, year_of_birth = @YearOfBirth " +
                "WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, client);
            }
        }
    }
}
