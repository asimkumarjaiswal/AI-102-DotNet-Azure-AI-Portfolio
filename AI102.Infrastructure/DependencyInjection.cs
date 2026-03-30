using AI102.Application.Interfaces;
using AI102.Infrastructure.Configurations;
using AI102.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AI102.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureAIOptions>(configuration.GetSection("AzureAI"));

        services.AddScoped<IVisionService, VisionService>();

        return services;
    }
}