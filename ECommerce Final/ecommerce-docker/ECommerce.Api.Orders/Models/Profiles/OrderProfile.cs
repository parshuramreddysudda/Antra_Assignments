using ApplicationCore.Entities.Orders;
using ApplicationCore.Model.Request;

namespace ECommerce.Api.Orders.Models.Profiles;

public class OrderProfile:AutoMapper.Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderRequestModel>().ReverseMap();
    }
  
}