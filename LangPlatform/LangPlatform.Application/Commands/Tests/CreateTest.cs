using Domain.DTOs;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data;
using Mapster;
using MediatR;

namespace Application.Commands.Tests;

public record CreateTestCommand(
    CreateTestDto Test
    ):IRequest;

public class CreateTestHandler : IRequestHandler<CreateTestCommand>
{
    private readonly DataContext _dataContext;

    public CreateTestHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(CreateTestCommand request, CancellationToken cancellationToken)
    {
        Test newTest = request.Test.Adapt<Test>();
        //User? creator = await _userRepository.GetAsync(test.Lesson.CreatorId??Guid.Empty);
        var creator = await _dataContext.Users.FindAsync(request.Test.Lesson.CreatorId);
        if (creator is null) throw new ValidationException("Creator not found");
        
        if (newTest.Lesson != null) newTest.Lesson.Approved = creator.Role == RoleType.Admin;
        //if (creator != null) await _userRepository.UpdateAsync(creator);

        //newLesson.Test = newTest;
        
        
        await _dataContext.Tests.AddAsync(newTest, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}