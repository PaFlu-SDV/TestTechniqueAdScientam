using TestTechnique.Domain.Models;
using TestTechnique.Domain.Repositories;

namespace TestTechnique.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly TestTechniqueDbContext _dbContext;

    public ProductRepository(TestTechniqueDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetAsync(Guid id, bool asTracking)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Guid>> AddAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}