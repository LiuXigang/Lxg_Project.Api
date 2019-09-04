using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.API.Application.Commands;
using Project.API.Application.Queries;
using Project.API.Application.Service;
using Project.Domain.AggregatesModel;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private IMediator _mediatR;
        private IRecommendService _recommendService;
        private IProjectQueries _projectQueries;
        private IProjectRepository _projectRepository;
        public ProjectController(
            IMediator mediator, 
            IRecommendService recommendService,
            IProjectQueries projectQueries,
            IProjectRepository projectRepository)
        {
            _mediatR = mediator;
            _recommendService = recommendService;
            _projectQueries = projectQueries;
            _projectRepository = projectRepository;
        }
        [HttpPost]
        [Route("CreateProject")]
        public async Task<IActionResult> CreateProject()
        {
            var project = new Domain.AggregatesModel.Project
            {
                UserId = UserIdentity.UserId
            };
            var command = new CreateProjectCommand { Project = project };
            var result = _mediatR.Send(command, new CancellationToken());
            await result;
            return Ok(result);
        }

        [HttpPut]
        [Route("JoinProject/{projectId}")]
        public async Task<IActionResult> JoinProject([FromBody]ProjectContributor contributor)
        {
            if (!await _recommendService.IsProjectRecommend(contributor.ProjectId, UserIdentity.UserId))
                return BadRequest("没有查看该项目的权限");
            var command = new JoinProjectCommand { Contributor = contributor };
            var result = await _mediatR.Send(command, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        [Route("ViewProject/{projectId}")]
        public async Task<IActionResult> ViewProject(int projectId)
        {
            if (!await _recommendService.IsProjectRecommend(projectId, UserIdentity.UserId))
                return BadRequest("没有查看该项目的权限");
            var identity = this.UserIdentity;
            var command = new ViewProjectCommand
            {
                ProjectId = projectId,
                UserId = identity.UserId,
                UserName = identity.Name,
                Avatar = identity.Avatar
            };
            var result = await _mediatR.Send(command, new CancellationToken());
            return Ok(result);
        }

        [Route("GetProjects")]
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _projectQueries.GetProjectsByUserId(UserIdentity.UserId);
            return Ok(result);
        }
        [Route("GetMyProjectDetail/{projectId}")]
        [HttpGet]
        public async Task<IActionResult> GetMyProjectDetail(int projectId)
        {
            var result = await _projectQueries.GetProjectDetail(projectId, -1);
            return Ok(result);
        }
        [Route("GetRecommendProjectDetail/{projectId}")]
        [HttpGet]
        public async Task<IActionResult> GetRecommendProjectDetail(int projectId)
        {
            if (!await _recommendService.IsProjectRecommend(projectId, UserIdentity.UserId))
                return BadRequest("没有查看该项目的权限");
            var result = await _projectQueries.GetProjectDetail(projectId, -1);
            return Ok(result);
        }
    }
}
