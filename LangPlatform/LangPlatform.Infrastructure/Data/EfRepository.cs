using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data;

public class EfRepository<T>:IRepository<T> where T : class, IEntity
{
    private readonly DataContext _dbc;
    private readonly DbSet<T> _dbSet;

    public EfRepository(DataContext dbc)
    {
        _dbc = dbc;
        _dbSet = _dbc.Set<T>();
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        //entity.Id = Guid.NewGuid();
        //Console.WriteLine(entity.Id);
        Console.WriteLine(typeof(T)+" 1 " + entity.Id);
        _dbc.Add(entity);
        Console.WriteLine(typeof(T)+" 2 " + entity.Id);
        await _dbc.SaveChangesAsync();
        Console.WriteLine(typeof(T)+" 3 " + entity.Id);
        return entity.Id;
    }

    public async Task<IEnumerable<T?>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T?>?> GetAllAsync(Func<T, bool> filter)
    {
        return  await Task.Run(()=>_dbc.Set<T>().Where(filter).ToList());
    }

    public async Task<T?> GetAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T?> GetAsync(Func<T, bool> filter)
    {
        return await Task.Run(()=> _dbSet.Where(filter).FirstOrDefault());
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity is not null)
        {
            _dbSet.Remove(entity);
            await _dbc.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity)
    {
        _dbc.Entry(entity).State = EntityState.Modified;
        await _dbc.SaveChangesAsync();
    }

    public async Task<int> Count(Func<T, bool> filter)
    {
        return _dbSet.Count(filter);
    }
}