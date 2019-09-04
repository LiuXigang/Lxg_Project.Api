using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Infrastructure.EntityConfigurations
{
    class ProjectViewerEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.ProjectViewer>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.ProjectViewer> builder)
        {
            builder.ToTable("ProjectViewers")
            .HasKey(t => t.Id);
        }
    }
}