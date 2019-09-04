using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Project.Infrastructure.EntityConfigurations
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.Project>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.Project> builder)
        {
            builder.ToTable("Projects")
            .HasKey(t => t.Id);
            builder.Property(up => up.ShowSecurityInfo)
                .HasConversion(new BoolToZeroOneConverter<Int16>());
        }
    }
}
