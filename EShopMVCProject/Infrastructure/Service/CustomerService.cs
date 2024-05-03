using ApplicationCore.Entities.Customer;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using AutoMapper;

namespace Infrastructure.Service;

public class CustomerService:ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository _customerRepository,IMapper mapper)
    {
        this._customerRepository = _customerRepository;
        _mapper = mapper;
    }
    public IEnumerable<CustomerResponseModel> GetAllCustomers()
    {
        var customers = _customerRepository.GetAll();
        return _mapper.Map<IEnumerable<CustomerResponseModel>>(customers);
    }
    public int InsertCustomer(CustomerRequestModel customerRequestModel)
    {
        var customer = _mapper.Map<Customer>(customerRequestModel);
        return _customerRepository.Insert(customer);
    }
    public int UpdateCustomer(CustomerRequestModel customerRequestModel)
    {
        var customer = _mapper.Map<Customer>(customerRequestModel);
        return _customerRepository.Update(customer);
    }

    public int DeleteCustomer(int id)
    {
        return _customerRepository.Delete(id);
    }

    public CustomerResponseModel GetCustomerByID(int id)
    {
        var customer = _customerRepository.GetById(id);
        return _mapper.Map<CustomerResponseModel>(customer);
    }
    
    //For Checking Mapping Configuration
    public void CheckAutoMapperConfiguration()
    {
        try
        {
            var customerRequestModel = new CustomerRequestModel
            {
                CustomerId = 1,
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