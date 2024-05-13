using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Lessons;

public record GetReviewsQuery(
    Guid LessonId
    ):IRequest<IEnumerable<ReviewDto>>;

public class GetReviewsHandler : IRequestHandler<GetReviewsQuery,IEnumerable<ReviewDto>>
{
    private readonly DataContext _dataContext;

    public GetReviewsHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _dataContext.Reviews.Where(x => x.LessonId == request.LessonId)
            .ToListAsync(cancellationToken: cancellationToken);
        return reviews.Adapt<IEnumerable<ReviewDto>>();
    }
}