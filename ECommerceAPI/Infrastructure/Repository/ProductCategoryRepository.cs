using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductCategoryRepositoryAsync:BaseRepositoryAsync<ProductCategory>,IProductCategoryRepositoryAsync
{
    public ProductCategoryRepositoryAsync(ECommerenceDbContext _context) : base(_context)
    {
        
    }
    
}