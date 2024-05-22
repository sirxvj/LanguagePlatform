using Infrastructure.Data;
using MediatR;

namespace Application.Commands.Lessons;

public record ApproveLessonCommand(
    Guid LessonId
    ):IRequest;

public class ApproveLessonHandler:IRequestHandler<ApproveLessonCommand>
{
    private readonly DataContext _dataContext;

    public ApproveLessonHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(ApproveLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _dataContext.Lessons.FindAsync(request.LessonId);
        if (lesson != null) lesson.Approved = true;
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}