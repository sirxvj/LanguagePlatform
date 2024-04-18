using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category?>?> GetAll();
    Task<Category> GetExact(Guid id);
    Task<Category?> GetExact(string name);

}