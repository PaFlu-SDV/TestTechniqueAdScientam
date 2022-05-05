using TestTechnique.Application.Adapter;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
using TestTechnique.Domain.Exceptions;
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
        var products = new List<ProductDto>();
        foreach (var prod in _productRepository.GetAllAsync().Result)
        {
            products.Add(ProductAdapter.ToProductDTO(prod));
        }
        return Task.FromResult(products.AsEnumerable());
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        return ProductAdapter.ToProductDTO(_productRepository.GetAsync(id).Result);
    }

    public Task<Guid> AddAsync(ProductDto productDto)
    {
        return _productRepository.AddAsync(ProductAdapter.ToProductModel(productDto));
    }

    public async Task<ProductDto> UpdateAsync(ProductDto productDto)
    {
        await _productRepository.UpdateAsync(ProductAdapter.ToProductModel(productDto));
        return ProductAdapter.ToProductDTO(_productRepository.GetAsync(productDto.Id).Result);
    }

    public Task DeleteAsync(Guid id)
    {
        var product = _productRepository.GetAsync(id).Result;
        return _productRepository.DeleteAsync(product);
    }
}