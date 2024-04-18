namespace Domain.DTOs;

public record ArticleDto(
    LessonDto Lesson,
    //Guid LessonId,
    List<SectionDto> Sections
);