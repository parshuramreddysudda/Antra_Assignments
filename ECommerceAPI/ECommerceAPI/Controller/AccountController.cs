using ApplicationCore.Model.Request;
using ApplicationCore.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await _accountService.SignUpAsync(model);
            Console.WriteLine("API SignUp() Logs "+result);
            if (result.Succeeded)
                return Ok(result.Succeeded);
            else
            {
                return BadRequest("Error in creating the Result"+result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _accountService.LoginAsync(model);

            return Ok(result);
        }
    }
}
