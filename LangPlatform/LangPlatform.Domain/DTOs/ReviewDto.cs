namespace Domain.DTOs;

public record ReviewDto(
    DateTime CreatedAt,
    string Title,
    string Body,
    double Rate,
    LessonDto Lesson,
   UserDto User
);