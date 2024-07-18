using ApplicationCore.Entities.Orders;
using ApplicationCore.Model.Request;

namespace ApplicationCore.ServiceContracts;

public interface IOrderServiceAsync
{
    Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync();
    Task<(bool IsSuccess, IEnumerable<Order> order, string ErrorMessage)> GetOrderByCustomerIDAsync(int id);
    Task<(bool IsSuccess, int id, string ErrorMessage)> InsertOrderAsync(OrderRequestModel order);
    Task<(bool IsSuccess, int id, string ErrorMessage)> UpdateOrderAsync(OrderRequestModel order);
    Task<(bool IsSuccess, int id, string ErrorMessage)> DeleteOrderAsync(int id);
}
