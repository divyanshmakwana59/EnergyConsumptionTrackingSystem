using Microsoft.EntityFrameworkCore;
using EnergyTrackerProject.Models;

namespace EnergyTrackerProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<EnergyUsage> EnergyUsages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergyUsage>()
                .Property(e => e.HoursUsed)
                .HasPrecision(10, 2);

            modelBuilder.Entity<EnergyUsage>()
                .Property(e => e.EnergyConsumed)
                .HasPrecision(10, 2);
        }
    }

}