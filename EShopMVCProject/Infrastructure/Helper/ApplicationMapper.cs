using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using AutoMapper;

namespace Infrastructure.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<CustomerRequestModel, CustomerEntities.Customer>().ReverseMap();
        CreateMap<CustomerEntities.Customer, CustomerResponseModel>(); // Mapping from CustomerEntities.Customer to CustomerResponseModel
        //CreateMap<ProductResponseModel, Product>().ReverseMap();
    }
}