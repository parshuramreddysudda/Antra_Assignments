using ApplicationCore.Constants;
using ApplicationCore.Entities.Orders;
using ApplicationCore.Model.Request;
using ApplicationCore.RepositoryContracts;
using ApplicationCore.ServiceContracts;
using AutoMapper;
using ECommerce.Api.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECommerce.Api.Orders.Services;

public class OrderServiceAsync : IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepository;
    private readonly ECommerenceDbContext _commerenceDbContext;
    private readonly IMapper _mapper;
    private readonly IRabbitMQProducer _rabbitMqProducer;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepository, ECommerenceDbContext commerenceDbContext,IMapper mapper,IRabbitMQProducer rabbitMqProducer)
    {
        _rabbitMqProducer = new RabbitMqProducer( Constants.ORDER_QUEUE_HOST_NAME,Constants.ORDER_QUEUE_USER_NAME,Constants.ORDER_QUEUE_PASSWORD,Constants.ORDER_QUEUE_NAME);
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

            if (orders.Any())
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
    public async Task<(bool IsSuccess, IEnumerable<OrderResponseModel> order, string ErrorMessage)> GetOrdersByOrderIdAsync(int id)
    {
        try
        {
            var orders = await _commerenceDbContext.Orders
                .Where(o => o.Id == id)
                .Include(o => o.OrderDetails)
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
                return (true, [], "No orders found for the given Order ID.");
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
                return (true, [], "No orders found for the given customer ID.");
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
            order.OrderDate = DateTime.Now;
            var newOrder = _mapper.Map<Order>(order);
            var orders = await _orderRepository.InsertAsync(newOrder);
            // var orderMessage = JsonConvert.SerializeObject(newOrder);
            // Hangfire.
            _rabbitMqProducer.SendMessage(newOrder.Id.ToString());
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
        try
        {
            order.OrderDate = DateTime.Now;
            var newOrder = _mapper.Map<Order>(order);
            var orders = await _orderRepository.UpdateAsync(newOrder);
            // Console.WriteLine(ordersResponse);
            if (orders>=1)
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
    }

    public async Task<(bool IsSuccess, int id, string ErrorMessage)> DeleteOrderAsync(int id)
    {
        try
        {
            var order = await _commerenceDbContext.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                _commerenceDbContext.Orders.Remove(order);
                await _commerenceDbContext.SaveChangesAsync();
                return (true, id, null);
            }
            else
            {
                return (false, 0, "Order not found.");
            }
        }
        catch (Exception ex)
        {
            return (false, 0, $"Error: {ex.Message}");
        }
    }

}