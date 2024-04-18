namespace Domain.DTOs;

public record CreateArticleDto(
    string Title,
    CreateLessonDto Lesson,
    List<SectionDto> Sections
    );