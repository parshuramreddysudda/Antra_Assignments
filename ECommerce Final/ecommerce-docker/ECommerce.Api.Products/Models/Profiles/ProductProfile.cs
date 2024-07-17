using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;
using ApplicationCore.Model.Response;

namespace ECommerce.Api.Products.Models.Profiles;

public class ProductProfile:AutoMapper.Profile
{
    public ProductProfile()
    {
        CreateMap<Product,ProductResponseModel>().ReverseMap();
        CreateMap<Product,ProductRequestModel>().ReverseMap();
        CreateMap<ProductRequestModel, ProductResponseModel>().ReverseMap();
    }
    
}