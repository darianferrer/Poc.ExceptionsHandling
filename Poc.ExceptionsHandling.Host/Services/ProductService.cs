using LanguageExt.Common;
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

        public async Task<Result<Product> > CreateProductAsync(Product product)
        {
            var productValidationResult =  await _productValidator.ValidateAsync(product);
            if (productValidationResult.IsFaulted)
            {
            
            }

            return await _repository.CreateProductAsync(product);
        }

        public async Task<Result<IEnumerable<Product>>> GetProductsAsync()
        {
            return new Result<IEnumerable<Product>>(await _repository.GetProducts());
        }
    }
}
