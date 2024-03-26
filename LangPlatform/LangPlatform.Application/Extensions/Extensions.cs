using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class Extensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<IAccountService, AccountService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddSingleton<ITestService, TestService>();
        return services;
    }
}