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

    public OrderServiceAsync(IOrderRepositoryAsync orderRepository, ECommerenceDbContext commerenceDbContext)
    {
        _orderRepository = orderRepository;
        _commerenceDbContext = commerenceDbContext;
    }

    
    public async Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync()
    {
        var result = await _commerenceDbContext.Orders
            .Include(o=>o.OrderDetails)
            .AsNoTracking()
            .ToListAsync();
        Console.WriteLine("Result is "+result);
        if (result!=null && result.Any())
        {
            Console.WriteLine("Executed Successfully");
            if (result.Count()<0)
            {
                return (true, null, "No Orders currently found");
            }

            return (true, result, "");
        }
            
        return (false, null, "Something Went Wrong "+result);
    }
    

    public async Task<(bool IsSuccess, IEnumerable<Order> order, string ErrorMessage)> GetOrderByCustomerIDAsync(int id)
    {
        var result = await _commerenceDbContext.Orders
            .Include(o=>o.CustomerId==id)
            .Include(o=>o.OrderDetails)
            .AsNoTracking()
            .ToListAsync();
        Console.WriteLine("Result is "+result);
        if (result!=null && result.Any())
        {
            Console.WriteLine("Executed Successfully");
            if (result.Count()<0)
            {
                return (true, null, "No Orders currently found");
            }

            return (true, result, "");
        }
        return (false, null, "Something Went Wrong "+result);
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