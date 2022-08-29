using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Repositories;

public interface IProductRepository
{
    Task<Product> CreateAsync(Product product);

    Task<IEnumerable<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task DeleteAsync(Product product);
}
