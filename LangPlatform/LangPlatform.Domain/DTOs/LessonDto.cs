namespace Domain.DTOs;

public record LessonDto(
    Guid Id,
    string Title,
    bool Approved,
    DateTime CreatedAt,
    double Avg,
    MediaDto Media,
    CreatorDto Creator,
    string Category,
    string Language
    );