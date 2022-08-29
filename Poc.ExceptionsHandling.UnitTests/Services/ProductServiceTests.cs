using Poc.ExceptionsHandling.Host.Domain;
using Poc.ExceptionsHandling.Host.Repositories;
using Poc.ExceptionsHandling.Host.Services;
using Poc.ExceptionsHandling.Host.Validations;
using Trainline.NetStandard.Exceptions.Contracts;

namespace Poc.ExceptionsHandling.UnitTests.Services;

public class ProductServiceTests
{
    private readonly ProductService _sut;
    private readonly Mock<IProductCategoryValidator> _productValidator = new();
    private readonly Mock<IProductRepository> _repository = new();

    public ProductServiceTests()
    {
        _sut = new(_productValidator.Object, _repository.Object);
    }

    [Fact]
    public async Task CreateAsync_GivenValidProduct_ShouldReturnCreated()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Valid Product",
            Category = "Valid Category"
        };
        _productValidator
            .Setup(x => x.Validate(product))
            .ReturnsAsync(TryResult.Success());
        _repository
            .Setup(x => x.CreateAsync(product))
            .ReturnsAsync(product);

        // Act
        var result = await _sut.CreateAsync(product);

        // Assert 
        Assert.Equal(product, result);
    }

    [Fact]
    public async Task CreateAsync_GivenInvalidProduct_ShouldReturnError()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Name = "Valid Product",
            Category = "Valid Category"
        };
        var expected = new Error(Severity.Correctable, "service.SomeCode", "Error message");
        _productValidator
            .Setup(x => x.Validate(product))
            .ReturnsAsync(expected);

        // Act
        var result = await _sut.CreateAsync(product);

        // Assert 
        Assert.Equal(expected, result);
    }
}
