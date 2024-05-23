using Claim.Helper;
using Claim.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimBasedAuthentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClaimController : ControllerBase
    {

        private readonly IUserClaimService _userClaimService;
        
        public UserClaimController(IUserClaimService userClaimService)
        {
            _userClaimService = userClaimService;
        }

        [HttpGet("GetAdminClaims")]
        public async Task<IActionResult> GetAdminClaims()
        {
            var result = await _userClaimService.GetUserClaims(x =>
                x.ClaimType == Constants.ROLE_ADMIN || x.ClaimType == Constants.ROLE_MANAGER);
            return Ok(result);
        }
        

        [HttpGet("GetManagerClaims")]
        public async Task<IActionResult> GetManagerClaims()
        {
            var result = await _userClaimService.GetUserClaims(x =>
                x.ClaimType == Constants.ROLE_MANAGER);
            return Ok(result);
        }

    }
}
