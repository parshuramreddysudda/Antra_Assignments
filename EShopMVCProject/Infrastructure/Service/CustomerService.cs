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
        var customer = _mapper.Map<CustomerEntities.Customer>(customerRequestModel);
        return _customerRepository.Insert(customer);
    }

    public int UpdateCustomer(CustomerRequestModel customerRequestModel)
    {
        var customer = _mapper.Map<CustomerEntities.Customer>(customerRequestModel);
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
}