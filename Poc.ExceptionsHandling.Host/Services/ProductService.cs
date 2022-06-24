using LanguageExt.Common;
using Poc.ExceptionsHandling.Host.Domain;
using Poc.ExceptionsHandling.Host.Repositories;
using Poc.ExceptionsHandling.Host.Validations;

namespace Poc.ExceptionsHandling.Host.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductCategoryValidator  _productValidator;
        private readonly IProductRepository _repository;

        public ProductService(IProductCategoryValidator productValidator, IProductRepository repository)
        {
            _productValidator = productValidator;
            _repository = repository;
        }

        public async Task<Result<Product> > CreateProductAsync(Product product)
        {

            var isValid = await _productValidator.Validate(product);
            if (!isValid)
            {
                return new Result<Product>(new ProductValidationException($"Unknown Category:{product.Category}"));
            }

            return await _repository.CreateProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProducts();
        }
    }
}
