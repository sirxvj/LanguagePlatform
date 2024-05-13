using Domain.DTOs;
using Domain.Enums;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Lessons;

public record GetLessonsFilteredQuery(
    bool? Approved = null,
    LessonType? Type = null,
    string? Category = null,
    string? Language = null
    ):IRequest<IEnumerable<LessonDto>>;

public class GetLessonsFilteredHandler : IRequestHandler<GetLessonsFilteredQuery,IEnumerable<LessonDto>>
{
    private readonly DataContext _dataContext;

    public GetLessonsFilteredHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<LessonDto>> Handle(GetLessonsFilteredQuery request, CancellationToken cancellationToken)
    {
        var lessonQuery = _dataContext.Lessons.AsQueryable();
        if (request.Approved is not null) lessonQuery = lessonQuery.Where(x => x.Approved == request.Approved);
        
        if (request.Type == LessonType.Article) lessonQuery = lessonQuery.Where(x => x.Article != null);
        else if (request.Type == LessonType.Test) lessonQuery = lessonQuery.Where(x => x.Test != null);

        if (request.Category is not null) lessonQuery = lessonQuery.Where(x => x.Category != null && x.Category.Name == request.Category);
        if (request.Language is not null) lessonQuery = lessonQuery.Where(x => x.Language != null && x.Language.Name == request.Language);
        var lessons = await lessonQuery.ToListAsync(cancellationToken: cancellationToken);
        return lessons.Adapt<IEnumerable<LessonDto>>();
    }
}