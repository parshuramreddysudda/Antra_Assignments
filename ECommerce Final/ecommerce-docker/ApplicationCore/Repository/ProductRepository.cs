using ApplicationCore.Entities.Product;
using ApplicationCore.Repository;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class ProductRepositoryAsync:BaseRepositoryAsync<Product>,IProductRepositoryAsync
{
    public ProductRepositoryAsync(ECommerenceDbContext _context) : base(_context)
    {
    }
} 