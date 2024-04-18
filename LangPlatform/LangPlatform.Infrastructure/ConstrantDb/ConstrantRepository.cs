using Domain.Interfaces;

namespace Infrastructure.ConstrantDb;

public class ConstrantRepository<T>:IRepository<T> where T : IEntity
{
    private static List<T> _storage = new List<T>();
    public async Task<Guid> CreateAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        _storage.Add(entity);
        return entity.Id;
    }

    public async Task<IEnumerable<T?>?> GetAllAsync()
    {
        return _storage;
    }

    public async Task<IEnumerable<T?>?> GetAllAsync(Func<T, bool> filter)
    {
        return _storage.Where(filter);
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return _storage.FirstOrDefault(x => x.Id == id);
    }

    public async Task<T?> GetAsync(Func<T, bool> filter)
    {
        return _storage.FirstOrDefault(filter);
    }

    public async Task RemoveAsync(Guid id)
    {
        var item = _storage.FirstOrDefault(x => x.Id == id);
        if(item is not null)
            _storage.Remove(item);
    }

    public async Task UpdateAsync(T entity)
    {
        await RemoveAsync(entity.Id);
        _storage.Add(entity);
    }

    public async Task<int> Count(Func<T, bool> filter)
    {
        return _storage.Count(filter);
    }
}