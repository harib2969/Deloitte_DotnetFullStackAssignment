using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTool.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Employee> Employees { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options)
         : base(options)
        {

        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
            
        public string Department { get; set; }
    }
}
