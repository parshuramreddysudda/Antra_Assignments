using ApplicationCore.Entities.Orders;
using ApplicationCore.Entities.Product;
using ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orders.MessagingService;

namespace Orders.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        QueueService _queueService;
        public OrderController(IConfiguration configuration)
        {
            _queueService = new QueueService(configuration);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://host.docker.internal:43156/");
            HttpResponseMessage message = await client.GetAsync("api/Product/GetAllProducts");
            if (message.IsSuccessStatusCode)
            {
                var result = await message.Content.ReadFromJsonAsync<List<ProductResponseModel>>();
                return Ok(result);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order_Details p)
        {
            await _queueService.SendMessageAsync<Order_Details>(p, "orderqueue");
            return Ok("Message has been send");
        }
    }
}
