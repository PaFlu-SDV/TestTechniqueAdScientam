using Microsoft.AspNetCore.Mvc;
using TestTechnique.Application.Adapter;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
using TestTechnique.Domain.Exceptions;
using TestTechnique.Domain.Repositories;
using TestTechnique.Persistence.Repositories;

namespace TestTechnique.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductHandler _productHandler;

    public ProductController(ILogger<ProductController> logger, IProductHandler productHandler)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productHandler = productHandler ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _productHandler.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var product = await _productHandler.GetAsync(id);

        if (product == null) return NotFound();
        return Ok(ProductAdapter.ToProductModel(product));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] ProductDto product)
    {
        await _productHandler.AddAsync(product);
        _logger.LogInformation($"The {product.Name} has been added with the ID:{product.Id}.");
        return CreatedAtAction("Get", product);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromHeader] Guid id, [FromRoute] ProductDto product)
    {
        var toDelete = _productHandler.GetAsync(id);
        if (toDelete.Result == null) return NotFound();

        await _productHandler.UpdateAsync(product);
        return new OkObjectResult(ProductAdapter.ToProductModel(product));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromHeader] Guid id)
    {
        var toDelete = _productHandler.GetAsync(id);
        if (toDelete.Result == null) return NotFound();

        await _productHandler.DeleteAsync(id);
        Console.Write("The product with ID: {0} has been deleted.", id);
        return NoContent();
    }
}