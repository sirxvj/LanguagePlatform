using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Test;

public record GetTestQuery(Guid LessonId):IRequest<TestObjectDto?>;

public class GetTestHandler : IRequestHandler<GetTestQuery,TestObjectDto?>
{
    private readonly DataContext _dataContext;

    public GetTestHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TestObjectDto?> Handle(GetTestQuery request, CancellationToken cancellationToken)
    {
        var test = await _dataContext.Tests.Where(x => x.LessonId == request.LessonId).FirstOrDefaultAsync();
        var rerar = test.Adapt<TestObjectDto>();
        return test.Adapt<TestObjectDto>();
    }
}