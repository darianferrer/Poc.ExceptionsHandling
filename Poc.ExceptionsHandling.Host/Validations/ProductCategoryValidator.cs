using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Validations
{
    public class ProductCategoryValidator:IProductCategoryValidator
    {
        public async Task<bool> Validate(Product product)
        {
            if (!Consts.ValidCategories.Contains(product.Category))
                return false;
            return true;
        }



    }
}
