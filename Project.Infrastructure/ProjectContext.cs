using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Domain.SeedWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    public class ProjectContext : DbContext, IUnitOfWork
    {

        private readonly IMediator _mediator;

        public DbSet<Domain.AggregatesModel.Project> Projects { get; set; }

        private ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public ProjectContext(DbContextOptions<ProjectContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("ProjectContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Domain.AggregatesModel.Project>(b => 
            //        b.ToTable("Projects")
            //        .HasKey(t => t.Id)
            //    );
            //改用ApplyConfiguration 方法配置
            //modelBuilder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ProjectContributorEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ProjectPropertyEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ProjectViewerEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ProjectVisibleRulesEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ClientRequestEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new PaymentMethodEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new CardTypeEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderStatusEntityTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new BuyerEntityTypeConfiguration()); 
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);//在 MediatorExtension 扩展 _mediator 来实现
            await base.SaveChangesAsync();
            return true;
        }
    }
}
