using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shopping_List.Data;
using System.IO;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoppingContext>
{
    public ShoppingContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ShoppingContext>();

        var connectionString = configuration.GetConnectionString("ShoppingDatabase");
        builder.UseSqlServer(connectionString);

        return new ShoppingContext(builder.Options);
    }
}
