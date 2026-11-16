using Microsoft.EntityFrameworkCore;
using NationalBank.Configs;

namespace NationalBank.Data
{
    public class BankContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=.;Database=..;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ManagerConfig());
            modelBuilder.ApplyConfiguration(new BranchConfig());
        }
    }
}