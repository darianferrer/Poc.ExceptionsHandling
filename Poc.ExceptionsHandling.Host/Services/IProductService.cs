using LanguageExt.Common;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Services
{
    public interface IProductService
    {
        Task<Result<Product>> CreateProductAsync(Product product);

        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
