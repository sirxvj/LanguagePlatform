
using System.Text;
using Application.Extensions;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Settings;
using Infrastructure.ConstrantDb;
using Infrastructure.Data;
using Infrastructure.Extensions;
using Infrastructure.MockDb;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LangPlatform;

public static class ConfigureServices
{
    
    public static IServiceCollection Configurator(this IServiceCollection services,WebApplicationBuilder? builder=null)
    {
        services.AddControllers();
        services.AddApplicationServices();
        services.AddSwaggerGen();
        services.AddEntityRepos();
        services.Configure<CommonSettings>(builder?.Configuration.GetSection("CommonSettings") ?? throw new InvalidOperationException());
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding
                        .UTF8.GetBytes(builder.Configuration["JWT:TokenKey"]!))
                };
            });
        services.MapsterConfig();
        // services.AddSingleton<IRepository<Language>, MockJsonRepository<Language>>();
        return services;
    }
}