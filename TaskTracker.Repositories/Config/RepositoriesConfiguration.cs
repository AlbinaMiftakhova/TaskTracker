using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Repositories.Interfaces;

namespace TaskTracker.Repositories.Config
{
    /// <summary>
    /// Extentions for repository configuration
    /// </summary>
    public static class RepositoriesConfiguration
    {
        public static void ConfigureRepositories (this IServiceCollection services)
        {
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
