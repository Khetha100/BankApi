using Microsoft.EntityFrameworkCore;
using BankApi.Models;


/// <summary>
/// Represents the database context for the Bank API.
/// </summary>
public class BankContext : DbContext
{
    /// <summary>
    /// Gets or sets the DbSet for AccountHolders.
    /// </summary>
    public DbSet<AccountHolder> AccountHolders { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for BankAccounts.
    /// </summary>
    public DbSet<BankAccount> BankAccounts { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for Withdrawals.
    /// </summary>
    public DbSet<Withdrawal> Withdrawals { get; set; }

    /// <summary>
    /// Gets or sets the DbSet for BankAccountAudits.
    /// </summary>
    public DbSet<BankAccountAudit> BankAccountAudits { get; set; }

    /// <summary>
    /// Initializes a new instance of the BankContext class.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public BankContext(DbContextOptions<BankContext> options) : base(options) { }

    /// <summary>
    /// Configures the database with initial data when the model is being created.
    /// </summary>
    /// <param name="modelBuilder">The model builder instance.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Initial data seeding
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

