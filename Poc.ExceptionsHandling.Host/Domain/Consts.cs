namespace Poc.ExceptionsHandling.Host.Domain;

public static class Consts
{
    public static string[] ValidCategories = new[] { "Clothes", "Shoes", "Bags" };

    public static class ValidationErrors
    {
        public const string InvalidCatoryErrorCode = "InvalidCategory";
        public const string InvalidCatoryErrorDescription = "Category selected is not valid";
    }
}
