namespace Domain.DTOs;

public record UserFormUserDto(
    string Greeting,
    bool Visible,
    Guid UserId,
    string Username,
    Guid LanguageId,
    Guid CategoryId
    );