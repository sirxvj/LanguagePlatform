
using Application.Extensions;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Extensions;
using Infrastructure.MockDb;

namespace LangPlatform;

public static class ConfigureServices
{
    public static void Configure(IServiceCollection services)
    {
        services.AddControllers();
        services.AddApplicationServices();
        services.AddSwaggerGen();
        services.AddEntityRepos();
        
        services.AddSingleton<IRepository<Language>, MockJsonRepository<Language>>();
        
    }
}