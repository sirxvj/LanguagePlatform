using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface ILessonService
{
    Task<IEnumerable<LessonDto>> GetFiltered(string? lang=null,string? category=null,bool? approved=null,string? type=null);

    Task AddReview(CreateReviewDto review);
    Task<IEnumerable<ReviewDto>> GetReviews(Guid lessonId);
    Task<IEnumerable<ReviewDto>> GetReviewsFull(Guid lessonId);
    
    Task Approve(Guid lessonId);
    
    Task DeleteLesson(Guid lessonId);
}