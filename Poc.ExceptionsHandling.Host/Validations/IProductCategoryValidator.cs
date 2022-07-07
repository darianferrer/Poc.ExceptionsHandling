using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Validations;

public interface IProductCategoryValidator
{
    Task<TryResult> Validate(Product product);
}
