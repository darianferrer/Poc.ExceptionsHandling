using Poc.ExceptionsHandling.Host.Domain;
using Poc.ExceptionsHandling.Host.Repositories;
using Poc.ExceptionsHandling.Host.Validations;

namespace Poc.ExceptionsHandling.Host.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductValidator  _productValidator;
        private readonly IProductRepository _repository;

        public ProductService(IProductValidator productValidator, IProductRepository repository)
        {
            _productValidator = productValidator;
            _repository = repository;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _productValidator.Validate(product);

            return await _repository.CreateProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProducts();
        }
    }
}
