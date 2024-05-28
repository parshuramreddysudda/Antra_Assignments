namespace ECommerce.Api.Orders.Models.Profiles;

public class OrderProfile:AutoMapper.Profile
{
    public OrderProfile()
    {
        CreateMap<DB.Orders, OrderModel>().ReverseMap();
    }
}