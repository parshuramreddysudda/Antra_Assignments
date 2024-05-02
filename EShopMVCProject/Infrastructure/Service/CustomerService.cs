using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;

namespace Infrastructure.Service;

public class CustomerService:ICustomerService
{
    private readonly ICustomerRepository _customerRepository;


    public CustomerService(ICustomerRepository vCustomerRepository)
    {
        _customerRepository = vCustomerRepository;
    }
    public IEnumerable<CustomerResponseModel> GetAllCustomers()
    {
        return null;
    }

    public int InsertCustomer(CustomerRequestModel product)
    {
        throw new NotImplementedException();
    }

    public int UpdateCustomer(CustomerRequestModel product)
    {
        throw new NotImplementedException();
    }

    public int DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public CustomerResponseModel GetCustomerByID(int id)
    {
        throw new NotImplementedException();
    }
}