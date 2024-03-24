namespace Domain.DTOs;

public record MediaDto(
    Guid Id,
    byte[] Bytes,
    string FileType,
    string FileName
    );