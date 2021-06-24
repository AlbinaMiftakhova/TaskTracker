using TaskTracker.Database;
using TaskTracker.Model.DTO;
using TaskTracker.Repositories.Interfaces.CRUD;

namespace TaskTracker.Repositories.Interfaces
{
    /// <summary>
    /// Project repository interface
    /// </summary>
    public interface IProjectRepository : ICrudRepository<ProjectDto, Project> { }
}
