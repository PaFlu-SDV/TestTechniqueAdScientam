using Microsoft.AspNetCore.Mvc;
using TestTechnique.Application.Adapter;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
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
        try
        {
            var product = await _productHandler.GetAsync(id);
            return Ok(ProductAdapter.ToProductModel(product));
        }
        catch (Exception ex)
        {
            return NotFound();
        }

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] ProductDto product)
    {   
        try
        {
            await _productHandler.AddAsync(product);
            _logger.LogInformation($"The {product.Name} has been added with the ID:{product.Id}.");
            return CreatedAtAction("Get", product);
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put([FromHeader] Guid id, [FromRoute] ProductDto product)
    {
        try
        {
            await _productHandler.UpdateAsync(product);
            return new OkObjectResult(ProductAdapter.ToProductModel(product));
        }
        catch (Exception ex)
        {
            return NotFound();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromHeader] Guid id)
    {
        try
        {
            var toDeleted = _productHandler.GetAsync(id);
            await _productHandler.DeleteAsync(id);
            Console.Write("The product with ID: {0} has been deleted.", id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound();  
        }

    }
}