using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Categories;

public record GetAllCategoriesQuery : IRequest<IEnumerable<Category>>;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly DataContext _dataContext;
    public GetAllCategoriesHandler( DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Categories.ToListAsync(cancellationToken: cancellationToken);
    }
}