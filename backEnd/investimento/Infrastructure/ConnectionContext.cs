using Microsoft.EntityFrameworkCore;
using investimento.Domain.Models;
using investimento.Application.ViewModel;

namespace investimento.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }

        public DbSet<Investment> Investments { get; set; }

        public DbSet<InvestmentType> InvestmentTypes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder.UseNpgsql(
                  "Server=localhost;" +
                  "Port=5432;Database=gerenciamento_investimentos_db;" +
                  "User Id=postgres;" +
                  "Password=12345;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvestmentResponseViewModel>().HasNoKey().ToView(null);
        }
    }
}
