namespace Domain.DTOs;

public record MediaDto(
    byte[] Bytes,
    string FileType,
    string FileName
    );