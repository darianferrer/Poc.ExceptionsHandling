using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Services;

public interface IProductService
{
    Task<TryResult<Product>> CreateAsync(Product product);

    Task<TryResult> DeleteByIdAsync(int id);

    Task<IEnumerable<Product>> GetAllAsync();
}
