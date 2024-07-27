using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderService;

        public OrdersController(IOrderServiceAsync orderServiceAsync)
        {
            _orderService = orderServiceAsync;
        }
         [HttpGet]
         public async Task<IActionResult> GetOrdersAsync()
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
            var result = await _orderService.GetOrderByCustomerIDAsync(customerId);

            if (result.IsSuccess)
            {
                return Ok(result.order);
            }

            return NotFound(result.ErrorMessage);
        }
        
        [HttpPost]
        public async Task<IActionResult> InsertOrderAsync(OrderRequestModel orderRequestModel)
        {
            var result = await _orderService.InsertOrdersAsync(orderRequestModel);

            if (result.IsSuccess)
            {
                return Ok(result.id);
            }

            return NotFound(result.ErrorMessage);
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteOrderAsync(int orderID)
        {
            var result = await _orderService.DeleteOrderAsync(orderID);

            if (result.IsSuccess)
            {
                return Ok(result.id);
            }

            return NotFound(result.ErrorMessage);
        }
    }
}
