using Microsoft.EntityFrameworkCore;

namespace PMS_AdminApi.Models
{
    public class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
