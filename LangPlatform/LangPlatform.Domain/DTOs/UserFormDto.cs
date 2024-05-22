namespace Domain.DTOs;

public record UserFormDto(
    string Greeting,
    bool Visible,
    Guid UserId,
    Guid LanguageId,
    Guid CategoryId
    );