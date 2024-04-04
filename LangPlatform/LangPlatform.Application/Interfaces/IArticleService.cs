using Domain.DTOs;

namespace Application.Interfaces;

public interface IArticleService
{
    Task UploadArticle(CreateArticleDto article);
    Task<ArticleDto?> DownloadArticle(Guid lessonId);
    
}