using Microsoft.EntityFrameworkCore;
using EmployeeProject.Model;

namespace EmployeeProject.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
    }
}
