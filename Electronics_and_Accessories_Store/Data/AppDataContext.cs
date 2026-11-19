using Microsoft.EntityFrameworkCore;
using Electronics_and_Accessories_Store.Models;

namespace Electronics_and_Accessories_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Черный" },
                new Color { Id = 2, Name = "Белый" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Айфон", Price = 1000, ColorId = 1 , ImageUrl = "/images/monkey.png"},
                new Product { Id = 2, Name = "Самсунг", Price = 800, ColorId = 1 },
                new Product { Id = 3, Name = "Реалми", Price = 600, ColorId = 2 }
            );
        }
    }
}