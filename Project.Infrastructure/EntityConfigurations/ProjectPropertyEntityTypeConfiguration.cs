using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Infrastructure.EntityConfigurations
{
    public class ProjectPropertyEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.ProjectProperty>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.ProjectProperty> builder)
        {
            builder.ToTable("ProjectProperties")
            .HasKey(t => new { t.Key, t.ProjectId, t.Value });
        }
    }
}
