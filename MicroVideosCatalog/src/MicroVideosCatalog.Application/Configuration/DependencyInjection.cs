
using MicroVideosCatalog.Application.Categories.Handlers;
using MicroVideosCatalog.Infrastructure.Data.Repositories;

namespace MicroVideosCatalog.Application.Configuration;
public static class DependencyInjection
{
    public static IServiceCollection AddAppDependencies(this IServiceCollection services)
    {
        services.AddScoped<CategoryCommandHandler>();
        services.AddScoped<CategoryQueryHandler>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        return services;
    }
}