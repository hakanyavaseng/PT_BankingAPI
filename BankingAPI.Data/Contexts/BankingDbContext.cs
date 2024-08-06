using BankingAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingAPI.Data.Contexts
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankingDbContext).Assembly);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
