using Microsoft.EntityFrameworkCore;
using MotoRider.Shared.Models;

namespace MotoRider.Infrastructure.Database.Core
{
    public class MotoRiderDbContext : DbContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Rent> Rents { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=MotoRiderDb;User Id=sa;Password=SQL;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorcycle>().Property(m => m.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Rent>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
        }
    }
}
