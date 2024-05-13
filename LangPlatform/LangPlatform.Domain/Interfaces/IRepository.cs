namespace Domain.Interfaces;

public interface IRepository<T> where T : IEntity
{
    Task<Guid> CreateAsync(T entity);
    Task<IEnumerable<T?>?> GetAllAsync();
    Task<IEnumerable<T?>?> GetAllAsync(Func<T, bool> filter);
    Task<T?> GetAsync(Guid id);
    Task<T?> GetAsync(Func<T, bool> filter);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(T entity);

    Task<int> Count(Func<T,bool> filter);
    
}