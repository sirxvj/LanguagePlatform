namespace Domain.DTOs;

public record CreateTestDto(
    string Title,
    string Description,
    CreateLessonDto Lesson,
    List<CreateQuestionDto> Questions
    );