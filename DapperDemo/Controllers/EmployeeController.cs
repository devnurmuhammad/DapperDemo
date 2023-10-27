using Dapper;
using DapperDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");
        [HttpGet]
        public IActionResult GetAllUser()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "Select * From Employee";
                IEnumerable<Employee> users = connection.Query<Employee>(query);
                return Ok(users);
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO Users " +
                               $"VALUES ('{user.Name}');";

                connection.Execute(query);
                return Ok("Created");
            }
        }

        [HttpGet]
        
        public async ValueTask<IActionResult> GetAllMultipleQueryUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT * FROM Users;
                             SELECT * FROM Employee";

                var users = await connection.QueryMultipleAsync(query);

                var firstTable = users.ReadAsync<User>().Result;
                var secondTable = users.ReadAsync<Employee>().Result;

                return Ok(firstTable);
            }
        }
    }
}
