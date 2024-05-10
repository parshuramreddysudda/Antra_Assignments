using ApplicationCore.Entities.Customer;
using ApplicationCore.Entities.Orders;
using ApplicationCore.Entities.Product;
using ApplicationCore.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ECommerenceDbContext:DbContext
{
    public ECommerenceDbContext(DbContextOptions<ECommerenceDbContext> options):base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerEntities.UserAddress> UserAddresses { get; set; }
    public DbSet<CustomerEntities.Address> Addresses { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order_Details> OrderDetails { get; set; }
    public DbSet<CustomerReview> CustomerReviews { get; set; }
}