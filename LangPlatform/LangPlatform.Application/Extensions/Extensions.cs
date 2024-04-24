using Application.Interfaces;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class Extensions
{
    
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IArticleService, ArticleService>();
        
        return services;
    }

    public static void MapsterConfig(this IServiceCollection services)
    {
        TypeAdapterConfig<Lesson, LessonDto>
            .NewConfig()
            .Map(dest => dest.Language, src => src.Language != null ? src.Language.Name : " ")
            .Map(dest => dest.Category, src => src.Category != null ? src.Category.Name : " ");
        
        var categoryService = services.BuildServiceProvider().GetService<ICategoryService>();
        var langService = services.BuildServiceProvider().GetService<ILanguageService>();
        TypeAdapterConfig<CreateLessonDto, Lesson>
            .NewConfig()
            .Map(dest => dest.LanguageId, src => langService!.GetExact(src.LanguageId ?? string.Empty).Result!.Id)
            .Map(dest => dest.CategoryId, src => categoryService!.GetExact(src.CategoryId ?? string.Empty).Result!.Id);

        TypeAdapterConfig<MediaDto, Media>
            .NewConfig()
            .Map(dest => dest.Bytes, src => Convert.FromBase64String(src.Bytes));

        TypeAdapterConfig<Media, MediaDto>
            .NewConfig()
            .Map(dest => dest.Bytes, src => Convert.ToBase64String(src.Bytes ?? Array.Empty<byte>()));
    }
}

public class ArtivleDto
{
}