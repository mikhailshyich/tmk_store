using Microsoft.EntityFrameworkCore;
using TMKStore.Models;

namespace TMKStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> Users { get; set; }
    }
}
