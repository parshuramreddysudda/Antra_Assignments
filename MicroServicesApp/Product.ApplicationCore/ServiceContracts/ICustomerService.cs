using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;

namespace ApplicationCore.ServiceContracts;

public interface ICustomerServiceAsync
{
    Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync();
    Task<int> InsertCustomerAsync(CustomerRequestModel product);
    Task<int> UpdateCustomerAsync(CustomerRequestModel product);
    Task<int> DeleteCustomerAsync(int id);
    Task<CustomerResponseModel> GetCustomerByIDAsync(int id);
}