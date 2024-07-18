using ApplicationCore.Entities.Customer;
using ApplicationCore.RepositoryContracts;

namespace ApplicationCore.Repository;

public class CustomerRespositoryAsync:BaseRepositoryAsync<Customer>,ICustomerRepositoryAsync
{
    public CustomerRespositoryAsync(ECommerenceDbContext _context):base(_context)
    {
        
    }
    
}