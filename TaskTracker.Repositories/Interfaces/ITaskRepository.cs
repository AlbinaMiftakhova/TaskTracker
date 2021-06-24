using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Model.DTO;
using TaskTracker.Repositories.Interfaces.CRUD;

namespace TaskTracker.Repositories.Interfaces
{
    /// <summary>
    /// Task repository interface
    /// </summary>
    public interface ITaskRepository: ICrudRepository<TaskDto, Database.Task>
    {
        Task<List<TaskDto>> GetTasksByProject(long id);
    }
}
