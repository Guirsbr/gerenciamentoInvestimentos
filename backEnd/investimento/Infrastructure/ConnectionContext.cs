using Microsoft.EntityFrameworkCore;
using investimento.Domain.Models;

namespace investimento.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Investimento> Investimentos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
              => optionsBuilder.UseNpgsql(
                  "Server=localhost;" +
                  "Port=5432;Database=gerenciamento_investimentos_db;" +
                  "User Id=postgres;" +
                  "Password=12345;");
    }
}
