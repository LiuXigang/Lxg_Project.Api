using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Infrastructure.EntityConfigurations
{
    class ProjectVisibleRulesEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.ProjectVisibleRules>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.ProjectVisibleRules> builder)
        {
            builder.ToTable("ProjectVisibleRules")
            .HasKey(t => t.Id);
        }
    }
}
