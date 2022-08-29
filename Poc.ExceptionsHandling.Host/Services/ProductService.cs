using Poc.ExceptionsHandling.Host.Domain;
using Poc.ExceptionsHandling.Host.Repositories;
using Poc.ExceptionsHandling.Host.Validations;

namespace Poc.ExceptionsHandling.Host.Services;

public class ProductService : IProductService
{
    private readonly IProductCategoryValidator _productValidator;
    private readonly IProductRepository _repository;

    public ProductService(IProductCategoryValidator productValidator, IProductRepository repository)
    {
        _productValidator = productValidator;
        _repository = repository;
    }

    public async Task<TryResult<Product>> CreateAsync(Product product)
    {
        var validateResult = await _productValidator.Validate(product);
        
        if (!validateResult.IsSuccess) return validateResult.Error;

        return await _repository.CreateAsync(product);
    }

    public async Task<TryResult> DeleteByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is not null) await _repository.DeleteAsync(product);

        return TryResult.Success();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
