using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Categories;

public record GetAllCategoriesQuery : IRequest<IEnumerable<Category>>;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
{
    private readonly IRepository<Category> _repository;

    public GetAllCategoriesHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}