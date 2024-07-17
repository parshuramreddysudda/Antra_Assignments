using ApplicationCore.Entities.Orders;
using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;

namespace ECommerce.Api.Orders.Services;

public class OrderServiceAsync:IOrderServiceAsync
{
    public OrderServiceAsync()
    {
        
    }

    public async Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<(bool IsSuccess, Order order, string ErrorMessage)> GetOrderAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool IsSuccess, int id, string ErrorMessage)> InsertOrderAsync(OrderRequestModel order)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool IsSuccess, int id, string ErrorMessage)> UpdateOrderAsync(OrderRequestModel order)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool IsSuccess, int id, string ErrorMessage)> DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }
}