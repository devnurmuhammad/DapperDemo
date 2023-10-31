using Dapper;
using DapperDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private string ConnectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("DefaultConnection");
        [HttpGet]
        public async Task<IActionResult> Methods()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Users;";
                string query2 = "SELECT * FROM Users; SELECT * FROM Users WHERE Id <> 4;";

                var result = connection.Query<User>(query);

                var res2 = connection.QueryFirst<User>(query);
                var res3 = await connection.QueryFirstAsync<User>(query);

                var res4 = connection.QuerySingle<User>(query);
                var res5 = await connection.QuerySingleAsync<User>(query);

                var res6 = await connection.QuerySingleAsync(query);
                var res7 = connection.QuerySingle(query);

                using (var res8 = connection.QueryMultiple(query2))
                {
                    var res9 = res8.Read();

                    var res10 = await res8.ReadAsync();
                    var res11 = await res8.ReadAsync<User>();

                    var res12 = res8.ReadFirst<User>();
                    var res13 = await res8.ReadFirstAsync<User>();

                    var res14 = res8.ReadFirstOrDefault<User>();
                    var res15 = res8.ReadFirstOrDefault();

                    var res16 = res8.ReadSingle<User>();
                    var res17 = await res8.ReadSingleAsync<User>();
                }

                return Ok(result);
            }
        }
    }
}
