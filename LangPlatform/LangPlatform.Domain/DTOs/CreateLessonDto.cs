using Domain.Entities;

namespace Domain.DTOs;

public record CreateLessonDto(
    string Title,
    MediaDto? Media,
    Guid? CreatorId,
    Guid? CategoryId,
    Guid? LanguageId
    );