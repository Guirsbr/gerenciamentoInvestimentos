using Microsoft.EntityFrameworkCore;
using investimento.Application.ViewModel;
using investimento.Domain.Models.BankAggregate;
using investimento.Domain.Models.InvestmentAggregate;
using investimento.Domain.Models.UserAggregate;
using investimento.Domain.Models.InvestmentTypeAggregate;

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

            modelBuilder.Entity<InvestmentResponseViewModel>()
                .HasNoKey()
                .ToView(null);

            // Migrations Configuration
            modelBuilder.Entity<Bank>()
                .HasKey(i => i.id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();

            modelBuilder.Entity<Investment>()
                .HasOne(i => i.bank)
                .WithMany()
                .HasForeignKey(i => i.id__bank)
                .HasConstraintName("FK__investment__bank");

            modelBuilder.Entity<Investment>()
                .HasOne(i => i.investmentType)
                .WithMany()
                .HasForeignKey(i => i.id__investment_type)
                .HasConstraintName("FK__investment__investment_type");

            modelBuilder.Entity<Investment>()
                .HasOne(i => i.user)
                .WithMany()
                .HasForeignKey(i => i.id__user)
                .HasConstraintName("FK__investment__user");
        }
    }
}
