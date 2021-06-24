using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Database.Context;

namespace TaskTracker.Database.Config
{
    /// <summary>
    /// DB configuration
    /// </summary>
    public static class DbConfigurations
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskTrackerContext>(
                options => options.UseSqlServer(configuration["ConnectionStrings:TaskTrackerContext"]));
        }
    }
}
