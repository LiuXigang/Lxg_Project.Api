using Project.Domain.AggregatesModel;
using Project.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public Domain.AggregatesModel.Project Add(Domain.AggregatesModel.Project project)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.AggregatesModel.Project> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Domain.AggregatesModel.Project Update(Domain.AggregatesModel.Project project)
        {
            throw new NotImplementedException();
        }
    }
}
