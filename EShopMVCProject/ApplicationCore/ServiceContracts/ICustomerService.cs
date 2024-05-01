using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface ICustomerService
{
    IEnumerable<CustomerResponseModel> GetAllCustomers();
    int InsertCustomer(CustomerResponseModel product);
    int UpdateCustomer(CustomerResponseModel product);
    int DeleteCustomer(CustomerResponseModel product);
    CustomerResponseModel GetCustomerByID(int id);
}