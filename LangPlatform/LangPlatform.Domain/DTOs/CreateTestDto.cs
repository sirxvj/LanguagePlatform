namespace Domain.DTOs;

public record CreateTestDto(
    string Description,
    CreateLessonDto Lesson,
    List<CreateQuestionDto> Questions
    );