namespace Domain.DTOs;

public record ArticleDto(
    string Title,
    LessonDto Lesson,
    //Guid LessonId,
    List<SectionDto> Sections
);