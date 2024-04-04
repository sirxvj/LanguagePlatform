
using Application.Extensions;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Settings;
using Infrastructure.ConstrantDb;
using Infrastructure.Extensions;
using Infrastructure.MockDb;

namespace LangPlatform;

public static class ConfigureServices
{
    
    public static void Configure(IServiceCollection services,WebApplicationBuilder? builder=null)
    {
        services.AddControllers();
        services.AddApplicationServices();
        services.AddSwaggerGen();
        services.AddEntityRepos();
        services.Configure<CommonSettings>(builder.Configuration.GetSection("CommonSettings"));
        
       // services.AddSingleton<IRepository<Language>, MockJsonRepository<Language>>();
        
    }
}