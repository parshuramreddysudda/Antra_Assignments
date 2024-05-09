using ApplicationCore.Entities.Customer;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using AutoMapper;

namespace Infrastructure.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        Console.WriteLine("Mapping Done From Application Mapper");
        CreateMap<CustomerRequestModel, Customer>().ReverseMap();
        CreateMap<CustomerResponseModel,Customer>().ReverseMap(); // Mapping from CustomerEntities.Customer to CustomerResponseModel
        //CreateMap<ProductResponseModel, Product>().ReverseMap();
    }
}