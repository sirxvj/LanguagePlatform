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
    private readonly IRepository<Media> _mediaRepository;
    private readonly IRepository<Language> _languageRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<User> _userRepository;
    public ArticleService(IRepository<Article> repository, IRepository<Section> sectionRepository, IRepository<Lesson> lessonRepository, IRepository<User> userRepository, IRepository<Language> languageRepository, IRepository<Category> categoryRepository, IRepository<Media> mediaRepository)
    {
        _repository = repository;
        _sectionRepository = sectionRepository;
        _lessonRepository = lessonRepository;
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _categoryRepository = categoryRepository;
        _mediaRepository = mediaRepository;
    }

    public async Task UploadArticle(CreateArticleDto article)
    {
        Article newArticle = article.Adapt<Article>();
        User? creator = await _userRepository.GetAsync(article.Lesson.CreatorId??Guid.Empty);
        if (newArticle.Lesson != null)
        {
                newArticle.Lesson.CreatedAt = DateTime.Now.ToUniversalTime();
                newArticle.Lesson.Approved = creator?.Role == RoleType.Admin;
                newArticle.Lesson.Article = newArticle;
                var cat = await _categoryRepository.GetAsync(x => x.Name == article.Lesson.CategoryId);
                if (cat is null)
                {
                    newArticle.Lesson.CategoryId = await _categoryRepository.CreateAsync(new Category { Name = article.Lesson.CategoryId });
                }
                else
                {
                    newArticle.Lesson.CategoryId = cat.Id;
                }
                var lang = await _languageRepository.GetAsync(x => x.Name == article.Lesson.LanguageId);
                if (lang is null)
                {
                    newArticle.Lesson.LanguageId = await _languageRepository.CreateAsync(new Language { Name = article.Lesson.LanguageId });
                }
                else
                {
                    newArticle.Lesson.LanguageId = lang.Id;
                }

                if (newArticle.Sections != null)
                    foreach (var section in newArticle.Sections)
                    {
                        if (section.Media is not null)
                        {
                            section.MediaId = await _mediaRepository.CreateAsync(section.Media);
                        }
                    }
        }

        await _repository.CreateAsync(newArticle);
    }

    public async Task<ArticleDto?> DownloadArticle(Guid lessonId)
    {
        var article = await _repository.GetAsync(x => x.LessonId == lessonId);
        if (article != null)
        {
            article.Sections = (article?.Sections ?? throw new InvalidOperationException()).OrderBy(a => a.Order)
                .ToList();
            foreach (var section in article.Sections)
            {
                section.Media = await _mediaRepository.GetAsync(section.MediaId??Guid.Empty);
            }
        }

        return article.Adapt<ArticleDto>();
    }
}