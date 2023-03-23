using Microsoft.EntityFrameworkCore;
using MyProjectSql.Models;

namespace MyProjectSql.Data
{
    public class MyprojectDbtContext : DbContext
    {
        public MyprojectDbtContext(DbContextOptions<MyprojectDbtContext> options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
