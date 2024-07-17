using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderService;

        public OrdersController(IOrderServiceAsync orderServiceAsync)
        {
            orderServiceAsync = _orderService;
        }
         [HttpGet]
         public async Task<IActionResult> GetOrdersAsync(int id)
         {
             var result = await _orderService.GetOrdersAsync();
        
             if (result.IsSuccess)
             {
                 return Ok(result.orders);
             }
        
             return NotFound(result.ErrorMessage);
         }
        
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrderAsync(int customerId)
        {
            var result = await _orderService.GetOrdersAsync();

            if (result.IsSuccess)
            {
                return Ok(result.orders);
            }

            return NotFound(result.ErrorMessage);
        }
    }
}
