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
    [ApiExplorerSettings(GroupName = DocumentPartsConst.Projects)]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;

        public ProjectController(IUnitOfWork repo, ILogger<ProjectController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProjectDto>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Projects/Get was requested.");
            var response = await _repo.ProjectRepository.GetAsync(cancellationToken);
            return Ok(_mapper.Map<IEnumerable<ProjectResponse>>(response));
        }

        /// <summary>
        /// Get project by ID
        /// </summary>
        /// <param name="id">Project's ID</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProjectDto>))]
        public async Task<IActionResult> GetByIdAsync(long id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Projects/Get by id was requested.");
            var response = await _repo.ProjectRepository.GetAsync(id);
            return Ok(_mapper.Map<ProjectResponse>(response));
        }


        /// <summary>
        /// Add a new project
        /// </summary>
        /// <param name="request">Project information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProjectDto>))]
        public async Task<IActionResult> PostAsync(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Projects/Post was requested.");
            var response = await _repo.ProjectRepository.CreateAsync(_mapper.Map<ProjectDto>(request));
            return Ok(_mapper.Map<ProjectResponse>(response));
        }

        /// <summary>
        /// Delete project(s)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="ids">ID's array</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{ids:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(CancellationToken cancellationToken, params long[] ids)
        {

            _logger.LogInformation("Projects/Delete was requested.");
            await _repo.ProjectRepository.DeleteAsync(ids);
            return Ok();
        }

        /// <summary>
        /// Update project
        /// </summary>
        /// <param name="request">Project's updated information</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProjectDto>))]
        public async Task<IActionResult> PutAsync(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Projects/Put was requested.");
            var response = await _repo.ProjectRepository.UpdateAsync(_mapper.Map<ProjectDto>(request));
            return Ok(_mapper.Map<ProjectResponse>(response));
        }
    }
}