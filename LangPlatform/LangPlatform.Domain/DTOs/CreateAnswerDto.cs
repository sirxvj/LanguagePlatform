namespace Domain.DTOs;

public record CreateAnswerDto(
    string Answer,
    bool Accuracy
    );