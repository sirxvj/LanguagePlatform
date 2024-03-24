namespace Domain.DTOs;

public record CreateReviewDto(
    string Title,
    string Body,
    int Rate,
    Guid UserId,
    Guid LessonId
    );