using System.Collections.Concurrent;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProductAsync(Product product);

        Task<IEnumerable<Product>> GetProducts();
    }
}
