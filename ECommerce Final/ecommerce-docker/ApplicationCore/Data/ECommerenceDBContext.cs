using ApplicationCore.Entities.ApplicationUser;
using ApplicationCore.Entities.Customer;
using ApplicationCore.Entities.Orders;
using ApplicationCore.Entities.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ECommerenceDbContext:IdentityDbContext<ApplicationUser>
{
    public ECommerenceDbContext(DbContextOptions<ECommerenceDbContext> options):base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerEntities.UserAddress> UserAddresses { get; set; }
    public DbSet<CustomerEntities.Address> Addresses { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<OrderDetails>()
    //         .HasKey(od => new { od.Id, od.ProductId });
    // }
    
}