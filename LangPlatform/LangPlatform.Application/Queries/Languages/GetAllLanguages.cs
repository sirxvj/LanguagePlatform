using Application.Queries.Categories;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Languages;

public record GetAllLanguagesQuery : IRequest<IEnumerable<Language>>;

public class GetAllLanguagesHandler : IRequestHandler<GetAllLanguagesQuery, IEnumerable<Language>>
{
    private readonly DataContext _dataContext;
    public GetAllLanguagesHandler( DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Language>> Handle(GetAllLanguagesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Languages.ToListAsync(cancellationToken: cancellationToken);
    }
}