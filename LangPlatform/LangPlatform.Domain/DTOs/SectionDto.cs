namespace Domain.DTOs;

public record SectionDto(
    int Order,
    string? Title,
    string? RawText,
    MediaDto? Media
    );