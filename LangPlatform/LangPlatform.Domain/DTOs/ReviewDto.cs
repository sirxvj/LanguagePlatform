namespace Domain.DTOs;

public record ReviewDto(
    string Title,
    string Body,
    double Rate,
   UserDto User
);