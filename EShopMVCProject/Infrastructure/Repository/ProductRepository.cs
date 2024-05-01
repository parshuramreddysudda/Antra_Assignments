using ApplicationCore.Entities.Product;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;
public class ProductRepository:BaseRepository<Product>,IProductRepository
{
    public ProductRepository(ECommerenceDbContext _context) : base(_context)
    {
    }
}