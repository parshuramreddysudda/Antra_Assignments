using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider _ordersProvider;

        public OrdersController(IOrdersProvider ordersProvider)
        {
            _ordersProvider = ordersProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await _ordersProvider.GetOrdersAsync();

            if (result.IsSuccess)
            {
                return Ok(result.orders);
            }

            return NotFound(result.ErrorMessage);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderAsync(int id)
        {
            var result = await _ordersProvider.GetOrderAsync(id);

            if (result.IsSuccess)
            {
                return Ok(result.order);
            }

            return NotFound(result.ErrorMessage);
        }
    }
}
