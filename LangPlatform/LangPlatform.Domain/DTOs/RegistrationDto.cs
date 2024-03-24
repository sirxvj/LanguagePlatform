namespace Domain.DTOs;

public record RegistrationDto(
    string Username,
    string Email,
    string Password
    );