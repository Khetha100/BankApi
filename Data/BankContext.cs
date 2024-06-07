using Microsoft.EntityFrameworkCore;
using BankApi.Models;

public class BankContext : DbContext
{
    public DbSet<AccountHolder> AccountHolders { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Withdrawal> Withdrawals { get; set; }

    public BankContext(DbContextOptions<BankContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Initial data
        modelBuilder.Entity<AccountHolder>().HasData(new AccountHolder
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1980, 1, 1),
            IDNumber = "123456789",
            ResidentialAddress = "123 Main St",
            MobileNumber = "1234567890",
            Email = "john.doe@example.com"
        });

        modelBuilder.Entity<BankAccount>().HasData(new BankAccount
        {
            Id = 1,
            AccountNumber = "111111",
            AccountType = "Cheque",
            Name = "John Doe",
            Status = "Active",
            AvailableBalance = 5000,
            AccountHolderId = 1
        });

        modelBuilder.Entity<BankAccount>().HasData(new BankAccount
        {
            Id = 2,
            AccountNumber = "222222",
            AccountType = "Savings",
            Name = "John Doe",
            Status = "Active",
            AvailableBalance = 10000,
            AccountHolderId = 1
        });

        modelBuilder.Entity<BankAccount>().HasData(new BankAccount
        {
            Id = 3,
            AccountNumber = "333333",
            AccountType = "Fixed Deposit",
            Name = "John Doe",
            Status = "Active",
            AvailableBalance = 20000,
            AccountHolderId = 1
        });
    }
}
