using Microsoft.AspNetCore.Mvc;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;

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
        var products = _productHandler.GetAsync(new Guid());
        return Ok(products);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult Get([FromRoute] Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromQuery] ProductDto product)
    {
        await _productRepository.AddAsync(product);
        return NoContent();
        _logger.LogInformation($"The {product.Name} has been added with the ID:{product.Id}.");
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Put([FromHeader] Guid id, [FromRoute] ProductDto product)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete([FromHeader] Guid id)
    {
        var product = new ProductDto { Id = id };
        await _productHandler.DeleteAsync(product);
        Console.Write("The product with ID: {0} has been deleted.", id);
        return NotFound();
    }
}