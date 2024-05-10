using ApplicationCore.Entities.ApplicationUser;
using ApplicationCore.Entities.Product;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ECommerenceDbContext:IdentityDbContext<ApplicationUser>
{
    public ECommerenceDbContext(DbContextOptions<ECommerenceDbContext> options):base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}