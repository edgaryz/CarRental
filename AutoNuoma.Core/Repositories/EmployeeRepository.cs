using CarRental.Core.Contracts;
using CarRental.Core.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarRental.Core.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _dbConnectionString;
        public EmployeeRepository(string connectionString)
        {
            _dbConnectionString = connectionString;
        }
        public async Task<List<Employee>> GetAllEmployeesFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryAsync<Employee>(@"SELECT id, first_name AS FirstName, last_name AS LastName, position FROM employees");
            dbConnection.Close();
            return result.ToList();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.QueryFirstAsync<Employee>(
                @"SELECT id, first_name AS FirstName, last_name AS LastName, position AS Position 
                  FROM employees WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }
        public async Task InsertEmployee(Employee employee)
        {
            string sqlCommand = "INSERT INTO employees " +
                "(first_name, last_name, position)" +
                "VALUES" +
                "(@FirstName, @LastName, @Position)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, employee);
            }
        }
        public async Task UpdateEmployee(Employee employee)
        {
            string sqlCommand = "UPDATE employees SET " +
                "first_name = @FirstName, last_name = @LastName, position = @Position " +
                "WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, employee);
            }
        }
        public async Task DeleteEmployee(int id)
        {
            string sqlCommand = "DELETE FROM employees WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                await connection.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }

        public async Task<int> GetEmployeeCountFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = await dbConnection.ExecuteScalarAsync<int>(@"SELECT COUNT(id) FROM employees");
            dbConnection.Close();
            return result;
        }
    }
}
