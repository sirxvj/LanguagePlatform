namespace Domain.DTOs;

public record AnswerDto(
    Guid Id,
    string Answer,
    bool Accuracy
    );