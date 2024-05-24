using Claim.Helper;
using Claim.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimBasedAuthentication
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserClaimController : ControllerBase
    {

        private readonly IUserClaimService _userClaimService;
        
        public UserClaimController(IUserClaimService userClaimService)
        {
            _userClaimService = userClaimService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAdminClaims()
        {
            Console.WriteLine("Control is at GetAdminClaisms");
            var result = await _userClaimService.GetUserClaims(x =>
                x.ClaimType == Constants.ROLE_ADMIN || x.ClaimType == Constants.ROLE_MANAGER);
            return Ok(result);
        }
        

        [HttpGet]
        public async Task<IActionResult> GetManagerClaims()
        {
            var result = await _userClaimService.GetUserClaims(x =>
                x.ClaimType == Constants.ROLE_MANAGER);
            return Ok(result);
        }

    }
}
