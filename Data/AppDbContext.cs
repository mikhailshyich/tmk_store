using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TMKStore.Models;

namespace TMKStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser { Id = Guid.NewGuid(), Name = "Admin", Email = "admin@mail.ru", Password = BCrypt.Net.BCrypt.HashPassword("admin"), Role = "Admin" }
            );
        }
    }
}
