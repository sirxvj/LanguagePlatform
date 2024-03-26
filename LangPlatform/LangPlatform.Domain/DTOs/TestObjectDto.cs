using Domain.Entities;

namespace Domain.DTOs;

public record TestObjectDto(
    Guid Id,
    string Title,
    string Description,
    LessonDto Lesson,
    List<QuestionItemDto> QuestionItems
    );