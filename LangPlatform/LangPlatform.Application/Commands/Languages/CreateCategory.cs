using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Languages;

public record CreateLanguageCommand(string Name):IRequest;

public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand>
{
    private readonly DataContext _dataContext;
    public CreateLanguageHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
    {
        await _dataContext.AddAsync(new Category{Name = request.Name}, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
    }
}
