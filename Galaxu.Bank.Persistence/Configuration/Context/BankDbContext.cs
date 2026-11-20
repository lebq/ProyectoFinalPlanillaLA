using Microsoft.EntityFrameworkCore;

namespace Galaxy.Bank.Persistence.Configuration.Context
{
    public class BankDbContext : DbContext
    {
        public BankDbContext()
        {
            
        }
        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1500; database=DbBank; uid=sa; password=Password2026; encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Bank");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDbContext).Assembly);
        }
    }
}
