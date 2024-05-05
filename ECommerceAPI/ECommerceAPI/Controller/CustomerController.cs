using System.Security.Claims;
using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using ECommerceAPI.Helper;
using ECommerceAPI.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync CustomerServiceAsync;
        
        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            CustomerServiceAsync = customerServiceAsync;
        }
        
        //[AllowAnonymous]
        [Authorize (Policy = IdentityData.AdminUserPolicyName)]
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
        [Authorize (Policy = IdentityData.AdminUserPolicyName)]
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
