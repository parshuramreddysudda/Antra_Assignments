using ApplicationCore.Entities.Orders;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace ApplicationCore.Repository;

public class OrderRepository(ECommerenceDbContext _context) :BaseRepositoryAsync<Order>(_context),IOrderRepositoryAsync
{
    
}