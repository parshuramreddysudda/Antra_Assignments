using ApplicationCore.Entities.Orders;
using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Request;

namespace ECommerce.Api.Orders.Models.Profiles;

public class OrderProfile:AutoMapper.Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponseModel>()
            .ForMember(dest=>dest.OrderDate,
                opt=>opt.MapFrom(src=>src.OrderDate))
            .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FirstName : src.CustomerName))
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => src.OrderDetails)).ReverseMap();

        CreateMap<OrderDetails, OrderDetailsResponse>()
            .ForMember(dest => dest.Product,
                opt => opt.MapFrom(src => src.Product)).ReverseMap();

        CreateMap<Product, ProductResponse>().ReverseMap();
        
        
        
        
        CreateMap<Order, OrderRequestModel>()
            .ForMember(dest => dest.OrderDate,
                opt => opt.MapFrom(src => DateOnly.Parse("2024-07-22"))) // Hardcoded date value
            .ForMember(dest => dest.CustomerName,
                opt => opt.MapFrom(src => src.Customer != null ? src.Customer.FirstName : src.CustomerName))
            .ForMember(dest => dest.OrderDetails,
                opt => opt.MapFrom(src => src.OrderDetails)).ReverseMap();

        CreateMap<OrderDetails, OrderDetailsRequest>().ReverseMap();
        
    }
  
}