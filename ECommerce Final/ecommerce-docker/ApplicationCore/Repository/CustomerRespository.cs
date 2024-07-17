using ApplicationCore.Entities.Customer;
using ApplicationCore.Repository;
using ApplicationCore.RepositoryContracts;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class CustomerRespositoryAsync:BaseRepositoryAsync<Customer>,ICustomerRepositoryAsync
{
    public CustomerRespositoryAsync(ECommerenceDbContext _context):base(_context)
    {
        
    }
    
}