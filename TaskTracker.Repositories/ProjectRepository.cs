using AutoMapper;
using TaskTracker.Database;
using TaskTracker.Database.Context;
using TaskTracker.Model.DTO;
using TaskTracker.Repositories.Interfaces;

namespace TaskTracker.Repositories
{
    /// <summary>
    /// Repository for Project entity
    /// </summary>
    public class ProjectRepository : BaseRepository<ProjectDto, Project>, IProjectRepository
    {
        public ProjectRepository(TaskTrackerContext context, IMapper mapper) : base (context, mapper) { }
    }
}
