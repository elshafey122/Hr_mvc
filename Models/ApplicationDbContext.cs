using Microsoft.EntityFrameworkCore;
using mvc2.Models;

namespace mvclab2.Models
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-QK9PCF4;Database=Iti_mvc2_project;Trusted_Connection=True;TrustServerCertificate=True");
        }
        public DbSet<Office> offices { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Emp_Project> emp_Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp_Project>().HasKey(u => new
            {
                u.Emp_id,
                u.Project_id
            });
        }
    }
}
