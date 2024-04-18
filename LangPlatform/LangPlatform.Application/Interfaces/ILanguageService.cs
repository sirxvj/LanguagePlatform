using Domain.Entities;

namespace Application.Interfaces;

public interface ILanguageService
{
    Task<IEnumerable<Language?>?> GetAll();
}