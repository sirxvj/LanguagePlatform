using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class LanguageService:ILanguageService
{
    private readonly IRepository<Language> _repository;

    public LanguageService(IRepository<Language> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Language?>?> GetAll()
    {
        return await _repository.GetAllAsync();
    }
}