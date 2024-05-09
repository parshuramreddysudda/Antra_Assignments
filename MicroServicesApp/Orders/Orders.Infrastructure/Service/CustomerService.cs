using ApplicationCore.Entities.Customer;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Service;

public class CustomerServiceAsync:ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsync _customerRepository;
    private readonly IMapper _mapper;

    public CustomerServiceAsync(ICustomerRepositoryAsync _customerRepository,IMapper mapper)
    {
        this._customerRepository = _customerRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerResponseModel>>(customers);
    }
    public async Task<int>  InsertCustomerAsync(CustomerRequestModel customerRequestModel)
    {
        var customer = _mapper.Map<Customer>(customerRequestModel);
        return await _customerRepository.InsertAsync(customer);
    }
    public async Task<int>  UpdateCustomerAsync(CustomerRequestModel customerRequestModel)
    {
        var customer = _mapper.Map<Customer>(customerRequestModel);
        return await _customerRepository.UpdateAsync(customer);
    }

    public  async Task<int> DeleteCustomerAsync(int id)
    {
        return await _customerRepository.DeleteAsync(id);
    }

    public async Task<CustomerResponseModel> GetCustomerByIDAsync(int id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerResponseModel>(customer);
    }
    
    //For Checking Mapping Configuration
    public void CheckAutoMapperConfiguration()
    {
        try
        {
            var customerRequestModel = new CustomerRequestModel
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Phone = "1234567890",
                ProfilePic = "profile.jpg",
                UserId = 123
            };

            var customerEntity = _mapper.Map<Customer>(customerRequestModel);

            // If mapping succeeds without throwing an exception, AutoMapper is configured correctly
            Console.WriteLine("AutoMapper is configured correctly.");
        }
        catch (AutoMapperMappingException ex)
        {
            Console.WriteLine($"AutoMapper configuration error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}