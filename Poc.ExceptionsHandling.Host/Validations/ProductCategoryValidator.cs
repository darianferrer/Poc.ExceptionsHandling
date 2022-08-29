using Poc.ExceptionsHandling.Host.Domain;
using Trainline.NetStandard.Exceptions.Contracts;

namespace Poc.ExceptionsHandling.Host.Validations;

public class ProductCategoryValidator : IProductCategoryValidator
{
    public Task<TryResult> Validate(Product product)
    {
        var result = !Consts.ValidCategories.Contains(product.Category)
            ? new Error(Severity.Correctable, Consts.ValidationErrors.InvalidCatoryErrorCode, Consts.ValidationErrors.InvalidCatoryErrorDescription)
            : TryResult.Success();
        return Task.FromResult(result);
    }
}
