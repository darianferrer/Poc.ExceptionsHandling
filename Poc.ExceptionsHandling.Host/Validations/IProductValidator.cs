using LanguageExt.Common;
using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Validations
{
    public interface IProductValidator
    {
        Task<Result<string>> ValidateAsync(Product product);
    }
}
