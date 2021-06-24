using AutoMapper;
using TaskTracker.Database;
using TaskTracker.Model.DTO;

namespace TaskTracker.Repositories.Mappings
{
    /// <summary>
    /// Mapping class for Project entity (for repository)
    /// </summary>
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
