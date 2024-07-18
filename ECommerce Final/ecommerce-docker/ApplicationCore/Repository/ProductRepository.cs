using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;

namespace ApplicationCore.Repository;

public class ProductRepositoryAsync:BaseRepositoryAsync<Product>,IProductRepositoryAsync
{
    public ProductRepositoryAsync(ECommerenceDbContext _context) : base(_context)
    {
    }
    
    
}