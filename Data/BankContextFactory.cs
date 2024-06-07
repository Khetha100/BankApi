using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class BankContextFactory : IDesignTimeDbContextFactory<BankContext>
{
    public BankContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BankContext>();

        // Read the configuration from appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);

        return new BankContext(optionsBuilder.Options);
    }
}
