namespace Domain.DTOs;

public record CreateQuestionDto(
    string Title,
    string Description,
    MediaDto? Media,
    List<CreateAnswerDto> Answers
    );