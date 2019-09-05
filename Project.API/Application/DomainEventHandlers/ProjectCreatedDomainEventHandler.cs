﻿using DotNetCore.CAP;
using MediatR;
using Project.API.Application.IntergrationEvents;
using Project.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.API.Application.DomainEventHandlers
{
    public class ProjectCreatedDomainEventHandler : INotificationHandler<ProjectCreatedEvent>
    {
        private ICapPublisher _capPublisher;
        public ProjectCreatedDomainEventHandler(ICapPublisher capPublisher) => _capPublisher = capPublisher;

        public Task Handle(ProjectCreatedEvent notification, CancellationToken cancellationToken)
        {
            var @event = new ProjectCreatedIntergrationEvent
            {
                CreateTime = DateTime.Now,
                Company = notification.Project.Company,
                FinStage = notification.Project.FinStage,
                Introduction = notification.Project.Introduction,
                ProjectAvatar = notification.Project.Avatar,
                Tags = notification.Project.Tags,
                ProjectId = notification.Project.Id,
                UserId = notification.Project.UserId
            };
            _capPublisher.Publish("projectapi.projectcreated", @event);
            return Task.CompletedTask;
        }
    }
}
