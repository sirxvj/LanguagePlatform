using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Test;

public record GetAnswerAccuracyQuery(
    Guid id
    ):IRequest<bool>;

public class GetAnswerAccuracyHandler : IRequestHandler<GetAnswerAccuracyQuery,bool>
{
    private readonly DataContext _dataContext;

    public GetAnswerAccuracyHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> Handle(GetAnswerAccuracyQuery request, CancellationToken cancellationToken)
    {
         return await _dataContext.Answers.Where(x=>x.Id==request.id).Select(x=>x.Accuracy).FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}