namespace Domain.DTOs;

public record ReviewDto(
    string Title,
    string Body,
    double Rate,
    LessonDto Lesson,
   UserDto User
);