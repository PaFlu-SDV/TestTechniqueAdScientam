using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
using TestTechnique.Domain.Repositories;

namespace TestTechnique.Application.Handlers;

public class ProductHandler : IProductHandler
{
    private readonly IProductRepository _productRepository;

    public ProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> AddAsync(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> UpdateAsync(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}