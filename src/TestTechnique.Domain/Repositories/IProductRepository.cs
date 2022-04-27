using TestTechnique.Domain.Models;

namespace TestTechnique.Domain.Repositories;

public interface IProductRepository : IEntityRepository<Product>
{
    public Task<Product> GetByNameAsync(string name);
}