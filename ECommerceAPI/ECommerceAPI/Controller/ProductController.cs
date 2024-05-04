using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync _productServiceAsync;

        public ProductController(IProductServiceAsync productServiceAsync)
        {
            _productServiceAsync = productServiceAsync;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productServiceAsync.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductRequestModel productRequestModel)
        {
            return Ok(await _productServiceAsync.InsertProductAsync(productRequestModel));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productServiceAsync.GetProductByIDAsync(id) != null)
            {
                return Ok(await _productServiceAsync.DeleteProductAsync(id));
            }

            return NotFound("Id Not Found");
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestModel productRequestModel, int id)
        {
            return Ok(await _productServiceAsync.UpdateProductAsync(productRequestModel));
        }
    }
}