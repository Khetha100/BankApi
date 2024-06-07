using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;



    /// <summary>
    /// Factory for creating instances of the BankContext for design-time tools like Migrations.
    /// </summary>
public class BankContextFactory : IDesignTimeDbContextFactory<BankContext>
{
    /// <summary>
    /// Creates a new instance of the BankContext for design-time tools.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>A new instance of the BankContext.</returns>
    public BankContext CreateDbContext(string[] args)
    {
        // Initialize a DbContextOptionsBuilder
        var optionsBuilder = new DbContextOptionsBuilder<BankContext>();

        // Get the base path for the application
        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"./"));

        // Read the configuration from appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();

        // Get the connection string from the configuration
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Configure the options to use SQL Server with the obtained connection string
        optionsBuilder.UseSqlServer(connectionString);

        // Create and return a new instance of BankContext with the configured options
        return new BankContext(optionsBuilder.Options);
    }
}

