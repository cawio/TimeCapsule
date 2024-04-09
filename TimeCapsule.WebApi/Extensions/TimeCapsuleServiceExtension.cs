using TimeCapsule.WebApi.Repositories;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Extensions;

public static class TimeCapsuleServiceExtension
{
    public static IServiceCollection AddTimeCapsuleServices(this IServiceCollection services)
    {
        services.AddScoped<TimeCapsuleRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<TimeCapsuleService>();
        services.AddScoped<PasswordService>();
        services.AddScoped<JwtService>();
        services.AddScoped<AuthService>();

        return services;
    }
}
