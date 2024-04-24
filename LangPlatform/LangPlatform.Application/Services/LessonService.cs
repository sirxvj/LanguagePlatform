using System.ComponentModel.DataAnnotations;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Settings;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Application.Services;

public class LessonService:ILessonService
{
    private readonly IRepository<Lesson> _repository;
    private readonly IRepository<Review> _reviewRepository;
    private readonly IRepository<User> _userRepository;

    private readonly IRepository<Language> _languageRepository;
    private readonly IRepository<Category> _categoryRepository;

    private readonly IRepository<Test> _testRepository;
    private readonly IRepository<Article> _articleRepository;
    
    private readonly CommonSettings _commonSettings;

    public LessonService(IRepository<Lesson> repository, IRepository<Review> reviewRepository, IRepository<User> userRepository, IOptions<CommonSettings> commonSettings, IRepository<Language> languageRepository, IRepository<Category> categoryRepository, IRepository<Test> testRepository, IRepository<Article> articlerepository)
    {
        _repository = repository;
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _languageRepository = languageRepository;
        _categoryRepository = categoryRepository;
        _testRepository = testRepository;
        _articleRepository = articlerepository;
        _commonSettings = commonSettings.Value;
    }
    public async Task<IEnumerable<LessonDto>> GetFiltered(string? language = null,string? category=null, bool? aprooved=null,
        string? type=null)
    {
        var lang = await _languageRepository.GetAsync(x => x.Name == language);
        var cat = await _categoryRepository.GetAsync(x => x.Name == category);
        var lessons = await _repository.GetAllAsync(x =>
        {
            if ((language is null || x.LanguageId == lang?.Id) &&
                (category is null || x.CategoryId == cat?.Id))
            {
                return (aprooved == x.Approved) || (aprooved is null);
            }

            return false;
        });
        List<LessonDto> result = new List<LessonDto>();

        if (lessons != null)
            foreach (var item in lessons)
            {
                if (item != null)
                {
                    item.Creator = await _userRepository.GetAsync(item.CreatorId);
                    if (type?.ToLower() == "test" && await _testRepository.Count(x => x.LessonId == item?.Id) > 0)
                    {
                        result.Add(item.Adapt<LessonDto>());
                    }
                    else if (type?.ToLower() == "article" &&
                             await _articleRepository.Count(x => x.LessonId == item?.Id) > 0)
                    {
                        result.Add(item.Adapt<LessonDto>());
                    }
                    else if (type is null)
                    {
                        result = lessons.Adapt<List<LessonDto>>();
                        break;
                    }
                }
            }

        return result;
    }


    public async Task<IEnumerable<ReviewDto>> GetReviewsFull(Guid lessonId)
    {
        var reviews = await _reviewRepository.GetAllAsync(x => x.LessonId == lessonId);
       
        return reviews.Adapt<IEnumerable<ReviewDto>>().OrderByDescending(r=>r.CreatedAt);
    }

    public async Task Approve(Guid lessonId)
    {
        var lesson = await _repository.GetAsync(lessonId);
        if (lesson is null)
            throw new NullReferenceException();
        lesson.Approved = true;
        var user = await _userRepository.GetAsync(lesson.CreatorId);
        if (user != null && user.Role!= RoleType.Admin && await _repository.Count(x => x.CreatorId == lesson.CreatorId) >= _commonSettings.PublicationsAmountForRoleChanging)
        {
            user.Role = RoleType.Admin;
        }
        await _repository.UpdateAsync(lesson);
    }

    public async Task AddReview(CreateReviewDto review)
    {

        var newReview = review.Adapt<Review>();
        if (await _reviewRepository.Count(r => r.UserId == review.UserId && r.LessonId == review.LessonId) > 0)
        {
            throw new ValidationException("One user, one comment",null,StatusCodes.Status400BadRequest);
        }
        newReview.CreatedAt=DateTime.Now.ToUniversalTime();
        int reviewAmount = await _reviewRepository.Count(x => x.LessonId == review.LessonId);
        if (reviewAmount < 20 || reviewAmount % 10 != 0)
        {
            var lesson = await _repository.GetAsync(review.LessonId);
            lesson!.Avg = (lesson.Avg * reviewAmount + review.Rate) / (reviewAmount + 1);
            await _repository.UpdateAsync(lesson);
        }

        await _reviewRepository.CreateAsync(newReview);
    }

    public async Task<IEnumerable<ReviewDto>> GetReviews(Guid lessonId)
    {
        var reviews = await _reviewRepository.GetAllAsync(x => x.LessonId == lessonId);
        return reviews.Adapt<IEnumerable<ReviewDto>>();
    }
    
    public async Task DeleteLesson(Guid lessonId)
    {
        await _repository.RemoveAsync(lessonId);
        var reviews = await _reviewRepository.GetAllAsync(x => x.LessonId == lessonId);
        if(reviews is null) return;
        foreach (var review in reviews)
        {
            await _reviewRepository.RemoveAsync(review!.Id);
        }
    }
}