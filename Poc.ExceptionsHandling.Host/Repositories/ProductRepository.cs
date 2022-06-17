using System.Collections.Concurrent;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private ConcurrentDictionary<int, Product> _products =  new ConcurrentDictionary<int, Product>();


        public async Task<Product> CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
