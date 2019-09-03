using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.API.Application.Commands;
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
        //private IRecommendService _recommendService;
        //private IProjectQueries _projectQueries;
        private IProjectRepository _projectRepository;
        public ProjectController(
            IMediator mediator, 
            //IRecommendService recommendService,
            //IProjectQueries projectQueries,
            IProjectRepository projectRepository)
        {
            _mediatR = mediator;
            //_recommendService = recommendService;
            //_projectQueries = projectQueries;
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
            var command = new JoinProjectCommand { Contributor = contributor };
            var result = await _mediatR.Send(command, new CancellationToken());
            return Ok(result);
        }

        [HttpPut]
        [Route("ViewProject/{projectId}")]
        public async Task<IActionResult> ViewProject(int projectId)
        {

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
    }
}
