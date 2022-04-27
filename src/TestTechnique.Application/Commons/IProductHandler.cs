using TestTechnique.Application.Contracts;

namespace TestTechnique.Application.Commons;

public interface IProductHandler
{
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto> GetAsync(Guid id);
    Task<Guid> AddAsync(ProductDto productDto);
    Task<ProductDto> UpdateAsync(ProductDto productDto);
    Task DeleteAsync(Guid id);
}