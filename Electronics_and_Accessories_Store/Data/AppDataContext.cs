using Microsoft.EntityFrameworkCore;
using Electronics_and_Accessories_Store.Models;

namespace Electronics_and_Accessories_Store.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<ReleaseDate> ReleaseDates { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Phone).IsUnique();
            
            modelBuilder.Entity<Color>().HasData(
                new Color { Id = 1, Name = "Черный" },
                new Color { Id = 2, Name = "Белый" }
            );

            modelBuilder.Entity<ReleaseDate>().HasData(
                new ReleaseDate { Id = 1, Name = "2021" },
                new ReleaseDate { Id = 2, Name = "2022" },
                new ReleaseDate { Id = 3, Name = "2025" }
            );

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1, Name = "Apple" },
                new Manufacturer { Id = 2, Name = "Samsung" },
                new Manufacturer { Id = 3, Name = "Realme" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 13", Price = 1000, ColorId = 2 ,ReleaseDateId = 1, ManufacturerId = 1, ImageUrl = "/images/iPhone 13.jpg"},
                new Product { Id = 2, Name = "Galaxy S21", Price = 800, ColorId = 1, ReleaseDateId = 2, ManufacturerId = 2, ImageUrl = "/images/Galaxy S21.jpeg"},
                new Product { Id = 3, Name = "Realme gt8 pro", Price = 600, ColorId = 2, ReleaseDateId = 3, ManufacturerId = 3,ImageUrl = "/images/realme GT8 Pro.jpg"}
            );
        }
    }
}