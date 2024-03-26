namespace Domain.DTOs;

public record CreatorDto(
    Guid Id,
    string Username,
    string Email
    );