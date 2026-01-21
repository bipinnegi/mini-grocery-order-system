using Microsoft.EntityFrameworkCore;
using order_api.Models;

namespace order_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Apple", Price = 10, Stock = 100 },
            new Product { Id = 2, Name = "Banana", Price = 5, Stock = 200 },
            new Product { Id = 3, Name = "Milk", Price = 40, Stock = 50 },
            new Product { Id = 4, Name = "Bread", Price = 30, Stock = 80 },
            new Product { Id = 5, Name = "Eggs (12 pcs)", Price = 60, Stock = 70 },
            new Product { Id = 6, Name = "Rice (1 kg)", Price = 55, Stock = 150 },
            new Product { Id = 7, Name = "Sugar (1 kg)", Price = 45, Stock = 120 },
            new Product { Id = 8, Name = "Salt (1 kg)", Price = 20, Stock = 200 },
            new Product { Id = 9, Name = "Cooking Oil (1 L)", Price = 130, Stock = 60 },
            new Product { Id = 10, Name = "Tea Powder (250 g)", Price = 90, Stock = 40 }
        );
    }
}
