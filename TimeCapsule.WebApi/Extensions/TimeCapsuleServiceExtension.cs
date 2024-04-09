using TimeCapsule.WebApi.Repositories;
using TimeCapsule.WebApi.Services;

namespace TimeCapsule.WebApi.Extensions;

public static class TimeCapsuleServiceExtension
{
    public static IServiceCollection AddTimeCapsuleServices(this IServiceCollection services)
    {
        services.AddScoped<TimeCapsuleRepository>();
        services.AddScoped<TimeCapsuleService>();

        return services;
    }
}
