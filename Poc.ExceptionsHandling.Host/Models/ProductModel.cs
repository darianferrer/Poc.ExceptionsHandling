using Poc.ExceptionsHandling.Host.Domain;

namespace Poc.ExceptionsHandling.Host.Models;

public class ProductModel
{
    public ProductModel()
    {
    }

    public ProductModel(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Category = product.Category;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Category { get; set; }

    public Product ToDomain()
    {
        return new Product() { Id = Id, Name = Name, Category = Category };
    }

}
