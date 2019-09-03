using MediatR;
using Project.Domain.AggregatesModel;
using Project.Domain.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.Application.Commands
{
    public class JoinProjectCommandHandler : IRequestHandler<JoinProjectCommand, bool>
    {
        private IProjectRepository _projectRepository;
        public JoinProjectCommandHandler(IProjectRepository projectRepository) => _projectRepository = projectRepository;
        public async Task<bool> Handle(JoinProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAsync(request.Contributor.ProjectId);
            if (project == null)
            {
                throw new ProjectDomainException($"Project not found :{request.Contributor.ProjectId}");
            }
            if (project.UserId == request.Contributor.UserId)
            {
                throw new ProjectDomainException("cannot join the project which created by youself| 不能参与自己创建的项目");
            }

            project.AddContributor(request.Contributor);
            await _projectRepository.UnitOfWork.SaveEntitiesAsync();
            return true;
        }
    }
}
