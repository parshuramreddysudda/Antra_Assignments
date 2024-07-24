using Microsoft.AspNetCore.Http;

namespace ApplicationCore.Middlewares;

public class ServiceHealthMiddleware
{
    private readonly RequestDelegate _next;

    public ServiceHealthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        return _next(httpContext);
    }
    
}