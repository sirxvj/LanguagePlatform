using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface ILessonService
{
    Task<IEnumerable<LessonDto>> GetByCategory(Category category);
    Task<IEnumerable<LessonDto>> GetByLanguage(Language language);

    Task<IEnumerable<LessonDto>> GetUnApproved();

    Task Approve(Guid lessonId);
    
    Task DeleteLesson(Guid lessonId);
}