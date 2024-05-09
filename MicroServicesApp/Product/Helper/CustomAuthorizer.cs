using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceAPI.Helper;

public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Check if the user is authenticated
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            Console.WriteLine("User is "+context.HttpContext.User.Identity.IsAuthenticated);
            // If not authenticated, return 503 Service Unavailable
            context.Result = new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
            return;
        }

        // If the user is authenticated, proceed with the request
    }
}