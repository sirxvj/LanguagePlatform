using Domain.DTOs;
using Infrastructure.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Articles;

public record DownloadArticleQuery(
    Guid LessonId
    ):IRequest<ArticleDto>;

public class DownloadArticleHandler : IRequestHandler<DownloadArticleQuery, ArticleDto?>
{
    private readonly DataContext _dataContext;

    public DownloadArticleHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ArticleDto?> Handle(DownloadArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await _dataContext.Articles.Where(x => x.LessonId == request.LessonId).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return article.Adapt<ArticleDto>();
    }
}