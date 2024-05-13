using System.ComponentModel.DataAnnotations;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Mapster;
using MediatR;

namespace Application.Commands.Articles;

public record UploadArticleCommand(
    CreateArticleDto Article
    ):IRequest;

public class UploadArticleHandler:IRequestHandler<UploadArticleCommand>
{
    private readonly DataContext _dataContext;

    public UploadArticleHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public async Task Handle(UploadArticleCommand request, CancellationToken cancellationToken)
    {
        Article article = request.Article.Adapt<Article>();
        var creator = await _dataContext.Users.FindAsync(request.Article.Lesson.CreatorId);
        if (creator is null) throw new ValidationException("Creator not found");
        
        if (article.Lesson != null) article.Lesson.Approved = creator.Role == RoleType.Admin;
        await _dataContext.Articles.AddAsync(article, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}