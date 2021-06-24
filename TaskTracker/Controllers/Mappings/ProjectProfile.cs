using AutoMapper;
using TaskTracker.Model.DTO;
using TaskTracker.Model.Requests;
using TaskTracker.Model.Responses;

namespace TaskTracker.Controllers.Mappings
{
    /// <summary>
    /// Project entity's mapping class for controller
    /// </summary>
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectRequest, ProjectDto>();
            CreateMap<UpdateProjectRequest, ProjectDto>();
            CreateMap<ProjectDto, ProjectResponse>();
        }
    }
}
