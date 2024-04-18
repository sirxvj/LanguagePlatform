using Domain.Entities;

namespace Application.Interfaces;

public interface ILanguageService
{
    Task<IEnumerable<Language?>?> GetAll();
    Task<Language?> GetExact(Guid id);
    Task<Language?> GetExact(string name);
}