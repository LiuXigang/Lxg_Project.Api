using Project.Domain.AggregatesModel;

namespace Project.API.Application.IntergrationEvents
{
    public class ProjectJoinedIntergrationEvent
    {
        public string Company { get; set; }
        public string Introduction { get; set; }
        public ProjectContributor Contributor { get; set; }
    }
}
