using TestTechnique.Domain.Exceptions;
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
        return Task.Run(() => _dbContext.Products.ToList().AsEnumerable()); ;
    }

    public async Task<Product> GetAsync(Guid id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if(product == null)
        {
            throw new EntityNotFoundException(id.ToString());
        }
        else
        {
            return product; 
        }
    }

    public Task<Product> GetAsync(Guid id, bool asTracking)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddAsync(Product entity)
    {
        await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;   
    }

    public Task<IEnumerable<Guid>> AddAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);
        return _dbContext.SaveChangesAsync();
        
    }

    public Task UpdateAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Product entity)
    {
        _dbContext.Remove(entity);
        return _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(IEnumerable<Product> entities)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetByNameAsync(string name)
    {
        var product = await _dbContext.Products.FindAsync(name);
        if (product == null)
        {
            throw new ArgumentNullException(name);
        }
        else
        {
            return product;
        }
    }
}