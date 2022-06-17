namespace Poc.ExceptionsHandling.Host.Domain
{
    public class ProductValidationException: Exception
    {
        public ProductValidationException(string message) : base(message)
        {
        }


    }
}
