using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Validations
{
    public class ProductValidatorWithException:IProductValidator
    {
        public async Task Validate(Product product)
        {
            if (!Consts.ValidCategories.Contains(product.Category))
                throw new ProductValidationException($"Unknown Category:{product.Category}");
        }



    }
}
