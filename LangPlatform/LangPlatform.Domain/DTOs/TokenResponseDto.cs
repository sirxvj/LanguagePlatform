namespace Domain.DTOs;

public record TokenResponseDto(
    Guid Id,
    string Username,
    string Token
    );