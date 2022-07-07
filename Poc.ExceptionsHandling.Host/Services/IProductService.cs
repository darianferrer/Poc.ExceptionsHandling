using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Services;

public interface IProductService
{
    Task<TryResult<Product>> CreateProductAsync(Product product);

    Task<IEnumerable<Product>> GetProductsAsync();
}
