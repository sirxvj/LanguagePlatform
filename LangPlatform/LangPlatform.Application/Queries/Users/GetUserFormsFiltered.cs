using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Users;

public record GetUserFormsFilteredQuery(
    Guid? CategoryId = null,
    Guid? LanguageId = null
    ):IRequest<IEnumerable<UserFormUserDto>>;

public class GetUserFormsfilteredHandler : IRequestHandler<GetUserFormsFilteredQuery, IEnumerable<UserFormUserDto>>
{
    private readonly DataContext _dataContext;

    public GetUserFormsfilteredHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<UserFormUserDto>> Handle(GetUserFormsFilteredQuery request, CancellationToken cancellationToken)
    {
        var formsQuery = _dataContext.UserForms.AsQueryable();
        formsQuery = formsQuery.Where(x => x.Visible);
        if (request.CategoryId is not null) formsQuery = formsQuery.Where(x => x.CategoryId == request.CategoryId);
        if (request.LanguageId is not null) formsQuery = formsQuery.Where(x => x.LanguageId == request.LanguageId);

        var result = await formsQuery.ToListAsync(cancellationToken: cancellationToken);

        return result.Adapt<IEnumerable<UserFormUserDto>>();
    }
}