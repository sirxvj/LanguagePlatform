using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.ConstrantDb;
using Infrastructure.MockDb;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class Extensions
{
    public static IServiceCollection AddMockRepository<T>(this IServiceCollection services)
        where T: IEntity
    {
        //services.AddSingleton<IRepository<T>, MockJsonRepository<T>>();
        services.AddSingleton<IRepository<T>, ConstrantRepository<T>>();
        return services;
    }
    public static IServiceCollection AddEntityRepos(this IServiceCollection services)
    {
        services.AddMockRepository<User>()
            .AddMockRepository<AnswerItem>()
            .AddMockRepository<Article>()
            .AddMockRepository<Category>()
            .AddMockRepository<Language>()
            .AddMockRepository<Lesson>()
            .AddMockRepository<MediaLesson>()
            .AddMockRepository<MediaQuestion>()
            .AddMockRepository<MediaTopic>()
            .AddMockRepository<QuestionItem>()
            .AddMockRepository<Review>()
            .AddMockRepository<Section>()
            .AddMockRepository<Topic>()
            .AddMockRepository<Test>();
        
        
        return services;
    }
    
}