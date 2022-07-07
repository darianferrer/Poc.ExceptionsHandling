using Poc.ExceptionsHandling.Host.Domain;
using Trainline.NetStandard.Exceptions.Contracts;

namespace Poc.ExceptionsHandling.Host.Validations;

public class ProductCategoryValidator : IProductCategoryValidator
{
    public async Task<TryResult> Validate(Product product)
    {
        return !Consts.ValidCategories.Contains(product.Category)
            ? new Error(Severity.Correctable, Consts.ValidationErrors.InvalidCatoryErrorCode, Consts.ValidationErrors.InvalidCatoryErrorDescription)
            : TryResult.Success();
    }
}
