using AppDDDProject.Domain.Entities;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace AppDDDProject.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().Property(x => x.Id);
            modelBuilder.Entity<Cliente>().Property(x => x.Nome).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Cliente>().Property(x => x.Cpf).HasMaxLength(11).HasColumnType("char(11)");
            modelBuilder.Entity<Cliente>().Property(x => x.Email).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Cliente>().Property(x => x.DataNascimento).HasColumnType("date");
            modelBuilder.Entity<Cliente>().HasKey("Id");
            modelBuilder.Ignore<Notification>();
        }
    }
}