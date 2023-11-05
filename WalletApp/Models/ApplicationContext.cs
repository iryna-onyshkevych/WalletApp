using Microsoft.EntityFrameworkCore;
using WalletApp.Services;

namespace WalletApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction[]
                {
            new Transaction {Id = 1,  UserId = 1, Date = "02/03", Description = "description", Name = "firstTransaction", Type = "Credit", Sum = "200", Pending = false, Icon =  IconService.GenerateIcon() },
            new Transaction { Id = 2, UserId = 2, Date = "03/03", Description = "description2", Name = "secondTransaction", Type = "Payment", Sum = "120", Pending = false, Icon = IconService.GenerateIcon() },
            new Transaction { Id = 3, UserId = 1, Date = "04/08", Description = "description3", Name = "thirdTransaction", Type = "Payment", Sum = "100", Pending = true, Icon =  IconService.GenerateIcon() },
            new Transaction { Id = 4,  UserId = 1, Date = "04/11", Description = "description4", Name = "ffourthTransaction", Type = "Payment", Sum = "230", Pending = false, AuthorizedUser = "Ell", Icon = IconService.GenerateIcon()}
        });
        }
    }
}
