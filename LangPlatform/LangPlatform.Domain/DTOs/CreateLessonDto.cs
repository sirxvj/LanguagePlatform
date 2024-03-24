using Domain.Entities;

namespace Domain.DTOs;

public record CreateLessonDto(
    MediaDto? Media,
    Guid CreatorId,
    Guid? CategoryId,
    Guid? LanguageId
    );