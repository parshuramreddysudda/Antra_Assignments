using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OData.Query;
using Prometheus;

namespace ECommerce.Api.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServiceAsync _productService;

        // Define Prometheus metrics
        private static readonly Counter GetProductsCounter = Metrics.CreateCounter("products_get_total", "Total number of GetProducts calls");
        private static readonly Counter GetProductCounter = Metrics.CreateCounter("product_get_total", "Total number of GetProduct calls");
        private static readonly Counter InsertProductCounter = Metrics.CreateCounter("product_insert_total", "Total number of InsertProduct calls");
        private static readonly Counter UpdateProductCounter = Metrics.CreateCounter("product_update_total", "Total number of UpdateProduct calls");
        private static readonly Counter DeleteProductCounter = Metrics.CreateCounter("product_delete_total", "Total number of DeleteProduct calls");

        private static readonly Histogram RequestDuration = Metrics.CreateHistogram("request_duration_seconds", "Histogram of request durations", new HistogramConfiguration
        {
            Buckets = Histogram.LinearBuckets(start: 0.01, width: 0.01, count: 100) // Adjust buckets as needed
        });

        public ProductsController(IProductServiceAsync productService)
        {
            _productService = productService;
        }
        
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            var numbers = new List<int>();
            
            return Ok("Protected endpoint accessed successfully");
        }

        //[Authorize(Policy = "Admin")]
        [HttpGet("admin")]
        public IActionResult Admin()
        {
            return Ok("Admin endpoint accessed successfully");
        }

        [HttpGet]
        [EnableQuery()]
        public async Task<IActionResult> GetProducts()
        {
            GetProductsCounter.Inc(); // Increment the counter for GetProducts
            using (RequestDuration.NewTimer())
            {
                var result = await _productService.GetProductsAsync();
                if (result.IsSuccess)
                {
                    return Ok(result.products);
                }
                return NotFound(result.ErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetProductCounter.Inc(); // Increment the counter for GetProduct
            using (RequestDuration.NewTimer())
            {
                var result = await _productService.GetProductAsync(id);
                if (result.IsSuccess)
                {
                    return Ok(result.product);
                }
                return NotFound(result.ErrorMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] ProductRequestModel product)
        {
            InsertProductCounter.Inc(); // Increment the counter for InsertProduct
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (RequestDuration.NewTimer())
            {
                var result = await _productService.InsertProductAsync(product);
                if (result.IsSuccess)
                {
                    return CreatedAtAction(nameof(GetProduct), new { id = result.id }, product);
                }
                RequestDuration.Publish();
                return BadRequest(result.ErrorMessage);
                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductRequestModel product)
        {
            UpdateProductCounter.Inc(); // Increment the counter for UpdateProduct
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (RequestDuration.NewTimer())
            {
                product.ID = id;
                var result = await _productService.UpdateProductAsync(product);
                if (result.IsSuccess)
                {
                    return Ok(result.id);
                }
                return NotFound(result.ErrorMessage);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            DeleteProductCounter.Inc(); // Increment the counter for DeleteProduct
            using (RequestDuration.NewTimer())
            {
                var result = await _productService.DeleteProductAsync(id);
                if (result.IsSuccess)
                {
                    return Ok(result.id);
                }
                return NotFound(result.ErrorMessage);
            }
        }
    }
}
