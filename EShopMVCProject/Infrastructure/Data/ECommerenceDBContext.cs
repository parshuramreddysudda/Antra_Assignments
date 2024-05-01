using ApplicationCore.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ECommerenceDbContext:DbContext
{
    public ECommerenceDbContext(DbContextOptions<ECommerenceDbContext> options):base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<CustomerEntities.Customer> Customers { get; set; }
    public DbSet<CustomerEntities.UserAddress> UserAddresses { get; set; }
    public DbSet<CustomerEntities.Address> Addresses { get; set; }
    
}