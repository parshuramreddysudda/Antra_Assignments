using AutoMapper;
using ECommerce.Api.Orders.DB;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Providers;

public class OrdersProvider:IOrdersProvider
{
    private readonly OrdersDbContext _dbContext;
    private readonly ILogger<DB.Orders> _logger;
    private readonly IMapper _mapper;

    public OrdersProvider(OrdersDbContext dbContext,ILogger<DB.Orders> logger,IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _dbContext = dbContext;
        SeedData();
    }

    public void SeedData()
    {
        if (!_dbContext.Orders.Any())
        {
            _dbContext.Orders.Add(new DB.Orders() { Id = 1, DateOnly = new DateOnly(2024, 5, 27), CustomerId = 1, CustomerName = "John Doe", PaymentMethod = "Credit Card", ShippingAddress = "123 Main St, Anytown, USA", BillAmount = 100.50m });
_dbContext.Orders.Add(new DB.Orders() { Id = 2, DateOnly = new DateOnly(2024, 5, 28), CustomerId = 2, CustomerName = "Jane Smith", PaymentMethod = "PayPal", ShippingAddress = "456 Oak St, Othertown, USA", BillAmount = 75.25m });
_dbContext.Orders.Add(new DB.Orders() { Id = 3, DateOnly = new DateOnly(2024, 5, 29), CustomerId = 3, CustomerName = "Alice Johnson", PaymentMethod = "Cash on Delivery", ShippingAddress = "789 Elm St, Anycity, USA", BillAmount = 200.75m });
_dbContext.Orders.Add(new DB.Orders() { Id = 4, DateOnly = new DateOnly(2024, 5, 30), CustomerId = 4, CustomerName = "Bob Brown", PaymentMethod = "Credit Card", ShippingAddress = "101 Pine St, Othertown, USA", BillAmount = 150.00m });
_dbContext.Orders.Add(new DB.Orders() { Id = 5, DateOnly = new DateOnly(2024, 6, 1), CustomerId = 5, CustomerName = "Eva Green", PaymentMethod = "Credit Card", ShippingAddress = "222 Maple St, Anycity, USA", BillAmount = 90.99m });
_dbContext.Orders.Add(new DB.Orders() { Id = 6, DateOnly = new DateOnly(2024, 6, 2), CustomerId = 6, CustomerName = "Mike Wilson", PaymentMethod = "PayPal", ShippingAddress = "333 Cedar St, Anytown, USA", BillAmount = 120.50m });
_dbContext.Orders.Add(new DB.Orders() { Id = 7, DateOnly = new DateOnly(2024, 6, 3), CustomerId = 7, CustomerName = "Sarah Lee", PaymentMethod = "Credit Card", ShippingAddress = "444 Oak St, Othertown, USA", BillAmount = 180.25m });
_dbContext.Orders.Add(new DB.Orders() { Id = 8, DateOnly = new DateOnly(2024, 6, 4), CustomerId = 8, CustomerName = "Tom Brown", PaymentMethod = "Cash on Delivery", ShippingAddress = "555 Elm St, Anycity, USA", BillAmount = 95.75m });
_dbContext.Orders.Add(new DB.Orders() { Id = 9, DateOnly = new DateOnly(2024, 6, 5), CustomerId = 9, CustomerName = "Linda Davis", PaymentMethod = "Credit Card", ShippingAddress = "666 Pine St, Othertown, USA", BillAmount = 210.00m });
_dbContext.Orders.Add(new DB.Orders() { Id = 10, DateOnly = new DateOnly(2024, 6, 6), CustomerId = 10, CustomerName = "Chris Johnson", PaymentMethod = "PayPal", ShippingAddress = "777 Maple St, Anycity, USA", BillAmount = 150.99m });
_dbContext.SaveChanges();
        }
    }
    public async Task<(bool IsSuccess, IEnumerable<OrderModel> orders, string ErrorMessage)> GetOrdersAsync()
    {
        try
        {
            var orders = await _dbContext.Orders.ToListAsync();
            if (orders != null && orders.Any())
            {
                var results=_mapper.Map<IEnumerable<DB.Orders>, IEnumerable<OrderModel>>(orders);
                return (true, results, null);
            }

            return (false, null, "Not Found");
        }
        catch (Exception e)
        {
            _logger?.LogError(e.ToString());
            return (false, null, e.Message);
        }
        
    }

    public async Task<(bool IsSuccess, OrderModel order, string ErrorMessage)> GetOrderAsync(int id)
    {
        
        try
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(p=>p.Id==id);
            if (order != null)
            {
                var result=_mapper.Map<DB.Orders, OrderModel>(order);
                return (true, result, null);
            }

            return (false, null, "Not Found");
        }
        catch (Exception e)
        {
            _logger?.LogError(e.ToString());
            return (false, null, e.Message);
        }
    }
}