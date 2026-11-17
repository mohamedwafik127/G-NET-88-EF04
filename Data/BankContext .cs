using Microsoft.EntityFrameworkCore;
using NationalBank.Configs;
using NationalBank.Model;


public class BankContext : DbContext
{
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<CustomerAccount> CustomerAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=.;Database=National Bank Management;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ManagerConfig());
        modelBuilder.ApplyConfiguration(new BranchConfig());
        modelBuilder.ApplyConfiguration(new TransactionConfig());
        modelBuilder.ApplyConfiguration(new AccountConfig());
        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new CustomerAccountConfig());
}
}
