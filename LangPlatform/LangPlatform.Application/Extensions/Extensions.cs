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
       
        
        return services;
    }

    public static void MapsterConfig(this IServiceCollection services)
    {
        TypeAdapterConfig<Lesson, LessonDto>
            .NewConfig()
            .Map(dest => dest.Language, src => src.Language != null ? src.Language.Name : " ")
            .Map(dest => dest.Category, src => src.Category != null ? src.Category.Name : " ");
        
        
        TypeAdapterConfig<MediaDto, Media>
            .NewConfig()
            .Map(dest => dest.Bytes, src => Convert.FromBase64String(src.Bytes));

        TypeAdapterConfig<Media, MediaDto>
            .NewConfig()
            .Map(dest => dest.Bytes, src => Convert.ToBase64String(src.Bytes ?? Array.Empty<byte>()));
    }
}
