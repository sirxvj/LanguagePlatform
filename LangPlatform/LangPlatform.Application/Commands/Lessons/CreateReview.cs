using Domain.DTOs;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Lessons;

public record CreateReviewCommand(
    CreateReviewDto Review
    ):IRequest;

public class CreateReviewHandler : IRequestHandler<CreateReviewCommand>
{
    private readonly DataContext _dataContext;

    public CreateReviewHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var newReview = request.Review.Adapt<Review>();
        if (await _dataContext.Reviews.CountAsync(r => r.UserId == request.Review.UserId && r.LessonId == request.Review.LessonId) > 0)
        {
            throw new ValidationException("One user, one comment");
        }
        newReview.CreatedAt=DateTime.Now.ToUniversalTime();
        int reviewAmount = await _dataContext.Reviews.CountAsync(x => x.LessonId == request.Review.LessonId, cancellationToken: cancellationToken);
        if (reviewAmount < 20 || reviewAmount % 10 != 0)
        {
            var lesson = await _dataContext.Lessons.FindAsync(request.Review.LessonId);
            lesson!.Avg = (lesson.Avg * reviewAmount + request.Review.Rate) / (reviewAmount + 1);
            //await _dataContext.Lessons.(lesson);
        }

        await _dataContext.Reviews.AddAsync(newReview, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}