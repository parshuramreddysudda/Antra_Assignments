using ApplicationCore.Entities.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Products.DB;

public class ProductsDbContext:DbContext
{
    public ProductsDbContext(DbContextOptions options):base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}