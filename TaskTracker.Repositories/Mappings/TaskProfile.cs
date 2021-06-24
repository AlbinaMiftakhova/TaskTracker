using AutoMapper;
using TaskTracker.Database;
using TaskTracker.Model.DTO;

namespace TaskTracker.Repositories.Mappings
{
    /// <summary>
    /// Mapping class for Task entity (for repository)
    /// </summary>
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDto>().ReverseMap();
        }
    }
}
