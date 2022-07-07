using Microsoft.AspNetCore.Mvc;
using Poc.ExceptionsHandling.Host.Domain;
using Poc.ExceptionsHandling.Host.Models;
using Poc.ExceptionsHandling.Host.Services;
using Trainline.NetStandard.Exceptions.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Examples
// https://github.com/trainline-private/k6-examples

namespace Poc.ExceptionsHandling.Host.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/<Products>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
    {

        return Ok((await _productService.GetProductsAsync()).Select(x => new ProductModel(x)));
    }

    // GET api/<Products>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        throw new NotImplementedException();
    }

    // POST api/<Products>
    [HttpPost]
    public async Task<ActionResult<ProductModel>> Post([FromBody] ProductModel product)
    {
        var result = await _productService.CreateProductAsync(product.ToDomain());
        return result.IsSuccess
            ? CreatedAtAction(nameof(Get), new { id = product.Id }, product)
            : CreateErrorResponse(result.Error);
    }

    private ActionResult CreateErrorResponse(Error error)
    {
        return error.Code switch
        {
            Consts.ValidationErrors.InvalidCatoryErrorCode => BadRequest(error),
            _ => StatusCode(StatusCodes.Status500InternalServerError, error),
        };
    }
}
