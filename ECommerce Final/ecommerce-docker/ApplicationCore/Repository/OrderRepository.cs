using ApplicationCore.Entities.Orders;
using ApplicationCore.RepositoryContracts;
 

namespace ApplicationCore.Repository;

public class OrderRepository:BaseRepositoryAsync<Order>,IOrderRepositoryAsync
{
    public OrderRepository(ECommerenceDbContext _context):base(_context)
    {
        
    }
    
}