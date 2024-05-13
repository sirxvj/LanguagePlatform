using System.Buffers.Text;

namespace Domain.DTOs;

public record MediaDto(
    string Bytes,
    string FileType,
    string FileName
    );