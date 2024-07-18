using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;

namespace ApplicationCore.Repository;

public class ProductCategoryRepositoryAsync:BaseRepositoryAsync<ProductCategory>,IProductCategoryRepositoryAsync
{
    public ProductCategoryRepositoryAsync(ECommerenceDbContext _context) : base(_context)
    {
        
    }
    
}