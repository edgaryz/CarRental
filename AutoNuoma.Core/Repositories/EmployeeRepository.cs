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
        public List<Employee> GetAllEmployeesFromDb()
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.Query<Employee>(@"SELECT employee_id, base_salary FROM employees").ToList();
            dbConnection.Close();
            return result;
        }
        public Employee GetEmployeeById(int id)
        {
            using IDbConnection dbConnection = new SqlConnection(_dbConnectionString);
            dbConnection.Open();
            var result = dbConnection.QueryFirst<Employee>(
                @"SELECT id, first_name AS FirstName, last_name AS LastName, position AS Position 
                  FROM employees WHERE id = @Id", new { Id = id });
            dbConnection.Close();
            return result;
        }
        public void InsertEmployee(Employee employee)
        {
            string sqlCommand = "INSERT INTO employees " +
                "(first_name, last_name, position)" +
                "VALUES" +
                "(@FirstName, @LastName, @Position)";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, employee);
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            string sqlCommand = "UPDATE employees SET " +
                "first_name = @FirstName" +
                "last_name = @LastName" +
                "position = @Position" +
                "WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, employee);
            }
        }
        public void DeleteEmployee(int id)
        {
            string sqlCommand = "DELETE FROM employees WHERE id = @Id";
            using (var connection = new SqlConnection(_dbConnectionString))
            {
                connection.Execute(sqlCommand, new { Id = id });
            }
        }
    }
}
