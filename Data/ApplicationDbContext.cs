using Microsoft.EntityFrameworkCore;
using BankApi.Models;


namespace BankApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<AccountHolder> AccountHolders { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<BankAccountAudit> BankAccountAudits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model relationships or constraints here
            modelBuilder.Entity<BankAccount>()
                .HasOne(a => a.AccountHolder)
                .WithMany(h => h.BankAccounts)
                .HasForeignKey(a => a.AccountHolderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


