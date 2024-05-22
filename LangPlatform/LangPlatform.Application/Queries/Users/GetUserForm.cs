using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Users;

public record GetUserFormQuery(
    Guid UserId
    ):IRequest<UserFormDto?>;

public class GetUserFormHandler : IRequestHandler<GetUserFormQuery,UserFormDto?>
{
    private readonly DataContext _dataContext;

    public GetUserFormHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserFormDto?> Handle(GetUserFormQuery request, CancellationToken cancellationToken)
    {
        var form = await _dataContext.UserForms.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken: cancellationToken);
        return form.Adapt<UserFormDto>();
    }
}