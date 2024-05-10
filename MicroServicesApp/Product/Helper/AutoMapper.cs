using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;
using AutoMapper;

namespace Infrastructure.Helper;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        Console.WriteLine("Mapping Done From Application Mapper"); 
        //CreateMap<ProductResponseModel, Product>().ReverseMap();
    }
}