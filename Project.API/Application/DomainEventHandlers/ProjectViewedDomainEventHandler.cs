using DotNetCore.CAP;
using MediatR;
using Project.API.Application.IntergrationEvents;
using Project.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.Application.DomainEventHandlers
{
    public class ProjectViewedDomainEventHandler : INotificationHandler<ProjectViewedEvent>
    {
        private ICapPublisher _capPublisher;
        public ProjectViewedDomainEventHandler(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }
        public Task Handle(ProjectViewedEvent notification, CancellationToken cancellationToken)
        {
            var @event = new ProjectViewedIntergrationEvent
            {
                Company = notification.Company,
                Introduction = notification.Introduction,
                Avatar = notification.Avatar,
                Viewer = notification.Viewer
            };
            _capPublisher.Publish("projectapi.projectviewed", @event);
            return Task.CompletedTask;
        }
    }
}
