using MediatR;
using Project.Domain.AggregatesModel;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.Application.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Domain.AggregatesModel.Project>
    {
        private IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository) => _projectRepository = projectRepository;
        public async Task<Domain.AggregatesModel.Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _projectRepository.Add(request.Project);
            await _projectRepository.UnitOfWork.SaveEntitiesAsync();

            return request.Project;
        }
    }
}
