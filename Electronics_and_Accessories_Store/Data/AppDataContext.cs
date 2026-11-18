using Microsoft.EntityFrameworkCore;
using Electronics_and_Accessories_Store.Models;

namespace Electronics_and_Accessories_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Phone> Phones { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().HasData(
                new Phone { Id = 1, Name = "Айфон", Price = 1000 },
                new Phone { Id = 2, Name = "Самсунг", Price = 800 },
                new Phone { Id = 3, Name = "Реалми", Price = 600 }
            );
        }
    }
}