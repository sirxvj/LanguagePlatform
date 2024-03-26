using Domain.Entities;

namespace Domain.DTOs;

public record QuestionItemDto(
    Guid Id,
    string Title,
    string Description,
    Guid TestId,
    MediaDto? Media,
    Test? Test,
    List<AnswerDto> Answers
    );