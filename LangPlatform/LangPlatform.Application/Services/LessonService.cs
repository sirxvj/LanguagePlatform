using System.Collections;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;

namespace Application.Services;

public class LessonService:ILessonService
{
    private readonly IRepository<Lesson> _repository;
    private readonly IRepository<Review> _reviewRepository;

    public LessonService(IRepository<Lesson> repository, IRepository<Review> reviewRepository)
    {
        _repository = repository;
        _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<LessonDto>> GetByCategory(Category category)
    {
        var lessons = await _repository.GetAllAsync(x => x.Category!.Contains(category));
        return lessons.Adapt<IEnumerable<LessonDto>>();
    }

    public async Task<IEnumerable<LessonDto>> GetByLanguage(Language language)
    {
        var lessons = await _repository.GetAllAsync(x=>x.LanguageId==language.Id);
        return lessons.Adapt<IEnumerable<LessonDto>>();

    }

    public async Task<IEnumerable<LessonDto>> GetUnApproved()
    {
        var lessons = await _repository.GetAllAsync(x => x.Approved == false);
        return lessons.Adapt<IEnumerable<LessonDto>>();
    }

    public async Task Approve(Guid lessonId)
    {
        var lesson = await _repository.GetAsync(lessonId);
        if (lesson is null)
            throw new NullReferenceException();
        lesson.Approved = true;
        await _repository.UpdateAsync(lesson);
    }

    public async Task AddReview(CreateReviewDto review)
    {
        var newReview = new Review
        {
            Title = review.Title,
            Body = review.Body,
            Rate = review.Rate,
            UserId = review.UserId,
            User = null,
            LessonId = review.LessonId,
            Lesson = null
        };

        int reviewAmount = await _reviewRepository.Count(x => x.LessonId == review.LessonId);
        if (reviewAmount < 20 || reviewAmount % 10 != 0)
        {
            var lesson = await _repository.GetAsync(review.LessonId);
            lesson!.AverageRate = (lesson.AverageRate * reviewAmount + review.Rate) / (reviewAmount + 1);
            await _repository.UpdateAsync(lesson);
        }

        await _reviewRepository.CreateAsync(newReview);
    }

    public async Task<IEnumerable<ReviewDto>> ReviewListing(Guid lessonId)
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