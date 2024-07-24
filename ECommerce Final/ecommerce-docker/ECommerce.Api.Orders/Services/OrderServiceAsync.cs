using ApplicationCore.Entities.Orders;
using ApplicationCore.Model.Request;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Services;

public class OrderServiceAsync : IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepository;
    private readonly ECommerenceDbContext _commerenceDbContext;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepository, ECommerenceDbContext commerenceDbContext,IMapper mapper)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _commerenceDbContext = commerenceDbContext;
    }

    
    public async Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync()
    {
        try
        {
            var orders = await _commerenceDbContext.Orders
                .Include(o => o.OrderDetails)
                .AsNoTracking()
                .ToListAsync();

            
            // Console.WriteLine($"Number of orders retrieved: {orders.Count}");

            if (orders != null && orders.Any())
            {
                orders.ForEach((order) =>
                {
                    if (!order.OrderDetails.Any())
                        order.OrderDetails = null;
                    
                });
                // Console.WriteLine("Orders retrieved successfully.");
                return (true, orders, null);
            }
            else
            {
                // Console.WriteLine("No orders found.");
                return (true, Enumerable.Empty<Order>(), "No orders currently found.");
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error occurred while retrieving orders: {ex.Message}");
            return (false, null, $"Error: {ex.Message}");
        }
    }

    

    public async Task<(bool IsSuccess, List<OrderResponseModel> order, string ErrorMessage)> GetOrderByCustomerIDAsync(int id)
    {
        try
        {
            var orders = await _commerenceDbContext.Orders
                .Where(o => o.CustomerId == id)
                .Include(o => o.OrderDetails)
                .ThenInclude(od=>od.Product)
                .AsNoTracking()
                .ToListAsync();
 
            var ordersResponse = _mapper.Map<List<OrderResponseModel>>(orders);
            Console.WriteLine(ordersResponse); 
            
            if (orders.Any())
            {
                // Console.WriteLine("Orders found successfully.");
                return (true, ordersResponse, null);
            }
            else
            {
                // Console.WriteLine("No orders found for customer ID: " + id);
                return (false, null, "No orders found for the given customer ID.");
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error occurred while retrieving orders: {ex.Message}");
            return (false, null, $"Error: {ex.Message}");
        }
    }

    public async Task<(bool IsSuccess, int id, string ErrorMessage)> InsertOrdersAsync(OrderRequestModel order)
    {
        try
        {
            //order.OrderDate = new DateOnly("2024-07-17");
            var newOrder = _mapper.Map<Order>(order);

            var orders = await _orderRepository.InsertAsync(newOrder);
            // Console.WriteLine(ordersResponse);
            
            if (orders>1)
            {
                // Console.WriteLine("Orders found successfully.");
                return (true, 1, null);
            }
            else
            {
                // Console.WriteLine("No orders found for customer ID: " + id);
                return (false, 0, orders.ToString());
            }
        }
        catch (Exception ex)
        {
            // Console.WriteLine($"Error occurred while retrieving orders: {ex.Message}");
            return (false, 0, $"Error: {ex.Message}");
        }
        // throw new NotImplementedException();
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