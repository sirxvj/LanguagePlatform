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
    public static IServiceCollection AddMockRepository<T>(this IServiceCollection services)
        where T: class, IEntity
    {
        
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseLazyLoadingProxies().UseNpgsql("Server=localhost;Port=5432;Database=langgang;User Id=postgres;Password=postgres;Include Error Detail=True;");
        });
        services.AddScoped<IRepository<T>, EfRepository<T>>();
        //services.AddSingleton<IRepository<T>, MockJsonRepository<T>>();
      
        //services.AddSingleton<IRepository<T>, ConstrantRepository<T>>();
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
            .AddMockRepository<Media>()
            .AddMockRepository<QuestionItem>()
            .AddMockRepository<Review>()
            .AddMockRepository<Section>()
            .AddMockRepository<Topic>()
            .AddMockRepository<Test>();
        
        
        return services;
    }
    
}