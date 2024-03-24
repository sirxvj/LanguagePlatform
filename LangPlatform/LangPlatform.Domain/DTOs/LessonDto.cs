namespace Domain.DTOs;

public record LessonDto(
    Guid Id,
    bool Approved,
    DateTime CreatedAt,
    double Avg,
    MediaDto Media,
    CreatorDto Creator,
    string Category
    );