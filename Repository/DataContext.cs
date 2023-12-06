using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions Parameters) : base(Parameters) { }

        public DbSet<User> Users { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite("Data Source=linkedinJobs.db");
        // }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}