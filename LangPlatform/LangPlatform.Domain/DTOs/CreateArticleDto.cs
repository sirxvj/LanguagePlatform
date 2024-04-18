namespace Domain.DTOs;

public record CreateArticleDto(
    CreateLessonDto Lesson,
    List<SectionDto> Sections
    );