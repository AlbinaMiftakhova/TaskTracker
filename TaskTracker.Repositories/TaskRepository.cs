using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Database.Context;
using TaskTracker.Model.DTO;
using TaskTracker.Repositories.Interfaces;

namespace TaskTracker.Repositories
{
    /// <summary>
    /// Repository for Task entity
    /// </summary>
    public class TaskRepository : BaseRepository<TaskDto, Database.Task>, ITaskRepository
    {
        public TaskRepository(TaskTrackerContext context, IMapper mapper) : base (context, mapper)
        {
        }

        public async Task<List<TaskDto>> GetTasksByProject(long id)
        {
            var entities = await DefaultIncludeProperties(DbSet)
                             .AsNoTracking()
                             .Where(x => x.ProjectId == id).ToListAsync();
            var dtos = _mapper.Map<List<TaskDto>>(entities);
            return dtos;
        }

    }
}
