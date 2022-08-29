using System.Collections.Concurrent;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ConcurrentDictionary<int, Product> _products = new();

    public Task<Product> CreateAsync(Product product)
    {
        var maxId = 0;
        if (_products.Any())
            maxId = _products.Max(x => x.Key);


        product.Id = maxId + 1;
        _products.TryAdd((int)product.Id, product);
        return Task.FromResult(product);
    }

    public Task DeleteAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        _products.Remove(product.Id, out var _);

        return Task.CompletedTask;
    }

    public Task<IEnumerable<Product>> GetAllAsync() => Task.FromResult(_products.Values.AsEnumerable());

    public Task<Product?> GetByIdAsync(int id) => Task.FromResult(_products.ContainsKey(id)
        ? _products[id]
        : null);
}
