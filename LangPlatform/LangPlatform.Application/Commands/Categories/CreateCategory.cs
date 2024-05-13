using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Categories;

public record CreateCategoryCommand(string Name):IRequest;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly DataContext _dataContext;
    public CreateCategoryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _dataContext.AddAsync(new Category{Name = request.Name}, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
    }
}
