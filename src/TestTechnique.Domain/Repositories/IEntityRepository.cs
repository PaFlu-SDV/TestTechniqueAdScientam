namespace TestTechnique.Domain.Repositories;

public interface IEntityRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetAsync(Guid id);
    Task<T> GetAsync(Guid id, bool asTracking);
    Task<Guid> AddAsync(T entity);
    Task<IEnumerable<Guid>> AddAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteAsync(IEnumerable<T> entities);
}