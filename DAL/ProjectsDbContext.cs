using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProjectsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Project> Projects { get; set; }

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Project>().ToTable("Project");
        }
    }
}
