using AutoMapper;
using TaskTracker.Model.DTO;
using TaskTracker.Model.Requests;
using TaskTracker.Model.Responses;

namespace TaskTracker.Controllers.Mappings
{
    public class TaskProfile : Profile
    {
        /// <summary>
        /// Task entity's mapping class for controller
        /// </summary>
        public TaskProfile()
        {
            CreateMap<CreateTaskRequest, TaskDto>();
            CreateMap<UpdateTaskRequest, TaskDto>();
            CreateMap<TaskDto, TaskResponse>();
        }
    }
    
}
