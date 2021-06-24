using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Swagger;
using TaskTracker.Repositories;
using TaskTracker.Model.DTO;
using TaskTracker.Model.Responses;
using TaskTracker.Model.Requests;

namespace TaskTracker.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = DocumentPartsConst.Tasks)]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;

        public TaskController(IUnitOfWork repo, ILogger<TaskController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tasks/Get was requested.");
            var response = await _repo.TaskRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<TaskResponse>>(response));
        }

        /// <summary>
        /// Get task by ID
        /// </summary>
        /// <param name="id">Task's ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tasks/Get by id was requested.");
            var response = await _repo.TaskRepository.GetAsync(id);
            return Ok(_mapper.Map<TaskResponse>(response));
        }

        /// <summary>
        /// Get all tasks of the project
        /// </summary>
        /// <param name="id">Project's ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        public async Task<IActionResult> GetTasksByProject(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tasks/Get by project was requested.");
            var response = await _repo.TaskRepository.GetTasksByProject(id);
            return Ok(_mapper.Map<IEnumerable<TaskResponse>>(response));
        }

        /// <summary>
        /// Add a new Task
        /// </summary>
        /// <param name="request">Task information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        public async Task<IActionResult> PostAsync(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tasks/Post was requested.");
            var response = await _repo.TaskRepository.CreateAsync(_mapper.Map<TaskDto>(request));
            return Ok(_mapper.Map<TaskResponse>(response));
        }

        /// <summary>
        /// Delete task(s)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="ids">ID's array</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{ids:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {

            _logger.LogInformation("Tasks/Delete was requested.");
            await _repo.TaskRepository.DeleteAsync(ids);
            return Ok();
        }

        /// <summary>
        /// Update task
        /// </summary>
        /// <param name="request">Updated task's information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskDto>))]
        public async Task<IActionResult> PutAsync(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tasks/Put was requested.");
            var response = await _repo.TaskRepository.UpdateAsync(_mapper.Map<TaskDto>(request));
            return Ok(_mapper.Map<TaskResponse>(response));
        }
    }
}