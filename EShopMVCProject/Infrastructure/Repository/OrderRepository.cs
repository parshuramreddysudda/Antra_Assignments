using ApplicationCore.Entities.Orders;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderRepository:BaseRepository<Order>,IOrderRepository
{
    public OrderRepository(ECommerenceDbContext dbContext):base(dbContext)
    {
        
    }
    
}