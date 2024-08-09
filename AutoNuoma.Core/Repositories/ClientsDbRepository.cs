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

        public async Task<List<Client>> GetAllClientsFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryAsync<Client>(@"SELECT id, first_name AS FirstName, last_name AS LastName, year_of_birth AS YearOfBirth FROM clients");
            dbConnection.Close();
            return result.ToList();
        }

        public async Task InsertClient(Client client)
        {
            string sqlCommand = "INSERT INTO clients " +
                "(first_name, last_name, year_of_birth)" +
                "VALUES" +
                "(@FirstName, @LastName, @YearOfBirth)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, client);
            }
        }

        public async Task<Client> GetClientById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryFirstAsync<Client>(
                @"SELECT id, first_name AS FirstName, last_name AS LastName, year_of_birth AS YearOfBirth 
                  FROM clients WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }

        public async Task UpdateClient(Client client)
        {
            string sqlCommand = "UPDATE clients SET " +
                "first_name = @FirstName, last_name = @LastName, year_of_birth = @YearOfBirth " +
                "WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, client);
            }
        }

        public async Task DeleteClient(int id)
        {
            string sqlCommand = "DELETE FROM clients WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }

        public async Task<int> GetClientCountFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.ExecuteScalarAsync<int>(@"SELECT COUNT(id) FROM clients");
            dbConnection.Close();
            return result;
        }

        //File System
        public List<Client> ReadClients()
        {
            throw new NotImplementedException();
        }

        public void WriteClients(List<Client> clientList)
        {
            throw new NotImplementedException();
        }
    }
}
