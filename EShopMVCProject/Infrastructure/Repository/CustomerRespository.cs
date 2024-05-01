using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CustomerRespository:BaseRepository<CustomerEntities.Customer>,ICustomerRepository
{
    public CustomerRespository(ECommerenceDbContext _context):base(_context)
    {
        
    }
    
}