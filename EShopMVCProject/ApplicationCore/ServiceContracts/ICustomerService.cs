using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface ICustomerService
{
    IEnumerable<CustomerResponseModel> GetAllCustomers();
    int InsertCustomer(CustomerRequestModel product);
    int UpdateCustomer(CustomerRequestModel product);
    int DeleteCustomer(int id);
    CustomerResponseModel GetCustomerByID(int id);
}