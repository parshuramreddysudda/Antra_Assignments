using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class ProductCategoryRepository:BaseRepository<ProductCategory>,IProductCategoryRepository
{
    public ProductCategoryRepository(ECommerenceDbContext _context) : base(_context)
    {
        
    }
    
}