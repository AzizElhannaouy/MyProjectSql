
using Microsoft.EntityFrameworkCore;
using MyProjectSql.Models;

namespace MyProjectSql.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(c => c.Editor).WithMany(t => t.CoursesEditted);
            modelBuilder.Entity<Course>().HasOne(c => c.Author).WithMany(t => t.CoursesWritten);
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Professeur> Teachers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
