using Domain.Interfaces;
using Newtonsoft.Json.Linq;

namespace Infrastructure.MockDb;

public class MockJsonRepository<T>: IRepository<T> where T:IEntity
{
    private readonly string _filename;
    private JObject _file;
    
    public MockJsonRepository()
    {
        _filename = "test.json";
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        entity.Id = Guid.NewGuid();
        await ParseRoot();
        if (_file["root"]?[typeof(T).ToString()] != null)
        {
            JArray item = (JArray)_file["root"]?[typeof(T).ToString()]!;
            item.Add(JObject.FromObject(entity));
        }
        else
        {
            _file["root"]![typeof(T).ToString()] = JArray.FromObject(new List<T>{entity});
        }
        await File.WriteAllTextAsync(_filename,_file.ToString());
        return entity.Id;
    }

    public async Task<IEnumerable<T?>?> GetAllAsync()
    {
        await ParseRoot();
        if (_file["root"]?[typeof(T).ToString()] != null)
        {
            return _file["root"]?[typeof(T).ToString()]?.ToObject<IEnumerable<T>>();
        }

        return null;
    }

    public async Task<IEnumerable<T?>?> GetAllAsync(Func<T, bool> filter)
    {
        await ParseRoot();
        if (_file["root"]?[typeof(T).ToString()] != null)
        {
            return _file["root"]?[typeof(T).ToString()]?.ToObject<IEnumerable<T>>()!.Where(filter);
        }

        return null;

    }

    public async Task<T?> GetAsync(Guid id)
    {
        await ParseRoot();
        return _file["root"]![typeof(T).ToString()]!.ToObject<IEnumerable<T>>()!.FirstOrDefault(x => x.Id==id);
    }

    public async Task<T?> GetAsync(Func<T, bool> filter)
    {
        await ParseRoot();
        return _file["root"]![typeof(T).ToString()]!.ToObject<IEnumerable<T>>()!.FirstOrDefault(filter);
    }

    public async Task RemoveAsync(Guid id)
    {
        await ParseRoot();
       _file["root"]![typeof(T).ToString()]!.FirstOrDefault(x=>x.ToObject<T>()!.Id == id)!.Remove();
       await File.WriteAllTextAsync(_filename, _file.ToString());
    }

    public async Task UpdateAsync(T entity)
    {
        await ParseRoot();
        var contents = _file["root"]![typeof(T).ToString()]!;
        contents.FirstOrDefault(x=>x.ToObject<T>()!.Id == entity.Id)!.Remove();
        ((JArray)contents).Add(JObject.FromObject(entity));
        await File.WriteAllTextAsync(_filename, _file.ToString());
    }

    public async Task<int> Count(Func<T, bool> filter)
    {
        await ParseRoot();
        var count = _file["root"]?[typeof(T).ToString()]!.Values<T>()!.Where(filter).Count();
        return count??0;
    }

    private async Task ParseRoot()
    {
        var json = await File.ReadAllTextAsync(_filename);
        _file = JObject.Parse(json);
    }
    
}