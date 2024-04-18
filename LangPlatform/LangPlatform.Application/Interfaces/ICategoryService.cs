using Domain.Entities;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<Category?>?> GetAll();
}