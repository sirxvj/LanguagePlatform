using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services;

public class ArticleService:IArticleService
{
    private readonly IRepository<Article> _repository;
    private readonly IRepository<Section> _sectionRepository;
    private readonly IRepository<Lesson> _lessonRepository;
    private readonly IRepository<User> _userRepository;
    public ArticleService(IRepository<Article> repository, IRepository<Section> sectionRepository, IRepository<Lesson> lessonRepository, IRepository<User> userRepository)
    {
        _repository = repository;
        _sectionRepository = sectionRepository;
        _lessonRepository = lessonRepository;
        _userRepository = userRepository;
    }

    public async Task UploadArticle(CreateArticleDto article)
    {
        Article newArticle = article.Adapt<Article>();
        List<Section> sections = article.Sections.Adapt<List<Section>>();
        Lesson lesson = article.Lesson.Adapt<Lesson>();
        User? creator = await _userRepository.GetAsync(article.Lesson.CreatorId??Guid.Empty);
        lesson.CreatedAt =DateTime.Now;
        lesson.Approved = creator?.Role == RoleType.Admin;
        lesson.Article = newArticle;
       newArticle.LessonId =  await _lessonRepository.CreateAsync(lesson);
       newArticle.Lesson = null;
       newArticle.Sections = sections;
       Guid articleId =  await _repository.CreateAsync(newArticle);
       foreach (var section in sections)
       {
           section.ArticleId = articleId;
           await _sectionRepository.CreateAsync(section);   
       }
       
    }

    public async Task<ArticleDto?> DownloadArticle(Guid lessonId)
    {
        var article = await _repository.GetAsync(x => x.LessonId == lessonId);
        if (article is null) return null;
        article.Sections = ((await _sectionRepository.GetAllAsync(x => x.ArticleId == article.Id))!).ToList()!;
        article.Lesson = await _lessonRepository.GetAsync(article.LessonId);
        return article.Adapt<ArticleDto>();
    }
}