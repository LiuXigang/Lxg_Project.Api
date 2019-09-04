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
        private readonly ProjectContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public ProjectRepository(ProjectContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public Domain.AggregatesModel.Project Add(Domain.AggregatesModel.Project project)
        {
            if (project.IsTransient())
            {
                _context.Add(project);
            }
            return project;
        }

        public async Task<Domain.AggregatesModel.Project> GetAsync(int id)
        {
            return await _context.FindAsync<Domain.AggregatesModel.Project>(id);
        }

        public Domain.AggregatesModel.Project Update(Domain.AggregatesModel.Project project)
        {
            _context.Update(project);
            return project;
        }
    }
}
