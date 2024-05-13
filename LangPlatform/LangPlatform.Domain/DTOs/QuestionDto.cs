using Domain.Entities;

namespace Domain.DTOs;

public record QuestionDto(
    Guid Id,
    string Title,
    string Description,
    Guid TestId,
    MediaDto? Media,
    List<AnswerDto> Answers
    );