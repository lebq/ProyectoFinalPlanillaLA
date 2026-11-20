using Galaxy.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Bank.Persistence.Configuration.Context
{
    public class BankDbContext(DbContextOptions<BankDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<CreditProduct> creditProducts { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<Payment> payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Bank");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDbContext).Assembly);
        }
    }
}
