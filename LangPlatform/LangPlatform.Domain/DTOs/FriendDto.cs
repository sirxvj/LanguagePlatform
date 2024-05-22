namespace Domain.DTOs;

public record FriendDto(
    Guid UserId,
    Guid User2Id
    );