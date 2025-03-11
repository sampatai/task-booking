using Microsoft.Extensions.DependencyInjection;
using TaskBooking.Infrastructure.Repository;

namespace TaskBooking.Infrastructure.DependencyExtensions;

public static class DepedencyExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IReadOnlyBlogRepository, ReadOnlyTaskBookingRepository>();
        services.AddScoped<IEventLogRepository, EventLogRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IReadonlyCategoryRepository, ReadonlyCategoryRepository>();
        return services;
    }
}

