using Domain.Entities;
using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Users;

public record MakeFriendCommand(
    Guid User,
    Guid User2
    ):IRequest;

public class MakeFriendHandler : IRequestHandler<MakeFriendCommand>
{
    private readonly DataContext _dataContext;

    public MakeFriendHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(MakeFriendCommand request, CancellationToken cancellationToken)
    {
        await _dataContext.Friends.AddAsync(new Friends { UserId = request.User, User2Id = request.User2 }, cancellationToken);
        await _dataContext.Friends.AddAsync(new Friends { UserId = request.User2, User2Id = request.User }, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}