using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WalletApp.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
