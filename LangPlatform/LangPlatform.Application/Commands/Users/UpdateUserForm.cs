using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UserForm = Domain.Entities.UserForm;

namespace Application.Commands.Users;

public record UpdateUserFormCommand(
    UserFormDto UserForm
    ):IRequest;

public class UpdateUserFormHandler:IRequestHandler<UpdateUserFormCommand>
{
    private readonly DataContext _dataContext;

    public UpdateUserFormHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(UpdateUserFormCommand request, CancellationToken cancellationToken)
    {
        var existed = await _dataContext.UserForms.FirstOrDefaultAsync(x => x.UserId == request.UserForm.UserId, cancellationToken: cancellationToken);

        if (existed is not null)
        {
            existed.Greeting = request.UserForm.Greeting;
            existed.Visible = request.UserForm.Visible;
            existed.CategoryId = request.UserForm.CategoryId;
            existed.LanguageId = request.UserForm.LanguageId;
        }
        else
        {
            await _dataContext.UserForms.AddAsync(request.UserForm.Adapt<UserForm>(), cancellationToken);
        }

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}