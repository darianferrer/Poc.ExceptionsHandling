using System.ComponentModel.DataAnnotations;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Middlewares;

public class ExceptionsMiddleware
{
    private readonly RequestDelegate _request;

    public ExceptionsMiddleware(RequestDelegate request)
    {
        _request=request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request.Invoke(context);
        }
        catch (ProductValidationException e)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new {message = e.Message});
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new { message = e.Message });
        }
    }
}
