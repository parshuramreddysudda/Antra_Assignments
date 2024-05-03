using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerServiceAsync CustomerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            CustomerServiceAsync = customerServiceAsync;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await CustomerServiceAsync.GetAllCustomersAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CustomerRequestModel customerRequestModel)
        {
            return Ok(await CustomerServiceAsync.InsertCustomerAsync(customerRequestModel));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await CustomerServiceAsync.GetCustomerByIDAsync(id) != null)
            {
                return Ok(await CustomerServiceAsync.DeleteCustomerAsync(id));   
            }

            return NotFound("Id Not Found");
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerRequestModel customerRequestModel,int id)
        {
            return Ok(await CustomerServiceAsync.UpdateCustomerAsync(customerRequestModel));
        }
        
    }
}
