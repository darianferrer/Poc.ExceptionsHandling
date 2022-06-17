using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Validations
{
    public interface IProductValidator
    {
        Task ValidateWithException(Product product);
    }
}
