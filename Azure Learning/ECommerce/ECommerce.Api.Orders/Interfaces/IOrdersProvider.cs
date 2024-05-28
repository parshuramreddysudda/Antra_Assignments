using ECommerce.Api.Orders.Models;
using ECommerce.Api.Orders.Models.Profiles;

namespace ECommerce.Api.Orders.Interfaces;

public interface IOrdersProvider
{
    Task<(bool IsSuccess, IEnumerable<OrderModel> orders, string ErrorMessage)> GetOrdersAsync();
    Task<(bool IsSuccess, OrderModel order, string ErrorMessage)> GetOrderAsync(int id);
}