using Microsoft.EntityFrameworkCore;
using TaskBooking.Infrastructure;


namespace TaskBooking.API.DependencyExtensions
{
    public static class DependencyExtension
    {
        public static IServiceCollection AddTaskBookings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskBookingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TaskBookingDbContext"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
           ServiceLifetime.Scoped);


            return services;
        }

    }
}
