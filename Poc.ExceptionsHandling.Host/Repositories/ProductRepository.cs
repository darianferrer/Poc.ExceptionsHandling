using System.Collections.Concurrent;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private ConcurrentDictionary<int, Product> _products =  new ConcurrentDictionary<int, Product>();


        public async Task<Product> CreateProductAsync(Product product)
        {
            var maxId = 0;
            if (_products.Any())
                maxId = _products.Max(x => x.Key);
            
            
            product.Id = maxId + 1;
            _products.TryAdd((int)product.Id , product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return _products.Values;
        }
    }
}
