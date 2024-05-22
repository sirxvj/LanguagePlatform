using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Users;

public record GetUsersFriendsQuery(
    Guid Id
    ):IRequest<IEnumerable<UserDto>>;

public class GetUsersFriendsHandler : IRequestHandler<GetUsersFriendsQuery, IEnumerable<UserDto>>
{
    private readonly DataContext _dataContext;

    public GetUsersFriendsHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetUsersFriendsQuery request, CancellationToken cancellationToken)
    {
        var friends = await _dataContext.Friends.Where(x => x.UserId == request.Id).Select(x=>x.User2).ToListAsync(cancellationToken: cancellationToken);
        return friends.Adapt<IEnumerable<UserDto>>();
    }
}

