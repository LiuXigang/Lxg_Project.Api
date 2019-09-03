using MediatR;
using Project.Domain.AggregatesModel;

namespace Project.API.Application.Commands
{
    public class JoinProjectCommand : IRequest<bool>
    {
        public ProjectContributor Contributor { get; set; }
    }
}
