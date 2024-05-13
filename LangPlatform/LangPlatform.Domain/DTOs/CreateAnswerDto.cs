namespace Domain.DTOs;

public record CreateAnswerDto(
    string AnswerBody,
    bool Accuracy
    );