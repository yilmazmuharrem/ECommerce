using ECommerce.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description for Product 1",
                Price = 10.99m,
                ImageUrl = "https://example.com/product1.jpg"
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description for Product 2",
                Price = 20.99m,
                ImageUrl = "https://example.com/product2.jpg",
                Stock= 100,
                IsActive = true
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Description = "Description for Product 3",
                Price = 30.99m,
                ImageUrl = "https://example.com/product3.jpg",
                Stock = 200,
                IsActive = true
            },
            new Product
            {
                Id = 4,
                Name = "Product 4",
                Description = "Description for Product 4",
                Price = 40.99m,
                ImageUrl = "https://example.com/product4.jpg",
                Stock = 400,
                IsActive = true
            },
            new Product
            {
                Id = 5,
                Name = "Product 5",
                Description = "Description for Product 5",
                Price = 50.99m,
                ImageUrl = "https://example.com/product5.jpg",
                Stock = 800,
                IsActive = true
            }



            );
        }
    }
}
