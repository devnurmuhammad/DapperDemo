using System.Net.NetworkInformation;
using static DapperDemo.Enum.ERole;
using static NonProject.Enum.EStatus;

namespace DapperDemo.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
        public Role  Role { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? DeletedDate { get; set; }
    }
}
