using LanguageExt.Common;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Validations
{
    public interface IProductCategoryValidator
    {
        Task<bool> Validate(Product product);
    }
}
