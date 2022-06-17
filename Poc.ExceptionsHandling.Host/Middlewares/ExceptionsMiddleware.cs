namespace Poc.ExceptionsHandling.Host.Middlewares
{
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

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
