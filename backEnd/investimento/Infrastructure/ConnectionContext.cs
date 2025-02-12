using Microsoft.EntityFrameworkCore;
using investimento.Domain.Models;

namespace investimento.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Investment> Investments { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder.UseNpgsql(
                  "Server=localhost;" +
                  "Port=5432;Database=gerenciamento_investimentos_db;" +
                  "User Id=postgres;" +
                  "Password=12345;");
    }
}
