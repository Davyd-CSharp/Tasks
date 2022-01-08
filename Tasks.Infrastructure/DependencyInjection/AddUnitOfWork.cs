using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Application.Interfaces.DataAccess;
using Tasks.Infrastructure.DataAccess;

namespace Tasks.Infrastructure.DependencyInjection
{
    public static class DIContainer
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, string databaseName) 
        {
            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });
            services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<TaskDbContext>());

            return services;
        }
    }
}
