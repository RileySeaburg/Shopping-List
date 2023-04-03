using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopping_List.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_List.Data
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) { }

        public DbSet<ShoppingItem> Shopping_List {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingItem>().ToTable(nameof(Shopping_List));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
            var connectionString = configuration.GetConnectionString("ShoppingDataBase");

            // Use SQL Server as the database provider and set the connection string
            optionsBuilder.UseSqlServer(connectionString);

        }

        public string GetConnectionString()
        {
            return Database.GetConnectionString();
        }
    }
}
