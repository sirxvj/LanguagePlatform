using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.ConstrantDb;
using Infrastructure.Data;
using Infrastructure.MockDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class Extensions
{
    public static IServiceCollection AddRepository<T>(this IServiceCollection services)
        where T: class, IEntity
    {
        
        services.AddScoped<IRepository<T>, EfRepository<T>>();
        
        return services;
    }
    public static IServiceCollection AddEntityRepos(this IServiceCollection services,string? connectionStr=null)
    {
        
        services.AddRepository<User>()
            .AddRepository<AnswerItem>()
            .AddRepository<Article>()
            .AddRepository<Category>()
            .AddRepository<Language>()
            .AddRepository<Lesson>()
            .AddRepository<Media>()
            .AddRepository<QuestionItem>()
            .AddRepository<Review>()
            .AddRepository<Section>()
            .AddRepository<Topic>()
            .AddRepository<Test>();
        
        
        return services;
    }

   
    
}