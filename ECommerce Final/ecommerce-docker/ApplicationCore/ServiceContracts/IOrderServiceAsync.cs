using ApplicationCore.Entities.Orders;
using ApplicationCore.Model.Request;

namespace ApplicationCore.ServiceContracts;

public interface IOrderServiceAsync
{
    Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync();
    Task<(bool IsSuccess, List<OrderResponseModel> order, string ErrorMessage)> GetOrderByCustomerIDAsync(int id);
    Task<(bool IsSuccess, int id, string ErrorMessage)> InsertOrdersAsync(OrderRequestModel order);
    Task<(bool IsSuccess, int id, string ErrorMessage)> UpdateOrderAsync(OrderRequestModel order);
    Task<(bool IsSuccess, int id, string ErrorMessage)> DeleteOrderAsync(int id);
}
