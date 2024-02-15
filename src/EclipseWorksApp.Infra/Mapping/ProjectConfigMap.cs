using EclipseWorksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksApp.Infra.Mapping;

internal class ProjectConfigMap : EntityBaseConfigMap<Project>
{
    public ProjectConfigMap() : base("Projects", "Id"){ }

    public override void Configure(EntityTypeBuilder<Project> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name);
        builder.Property(e => e.Description);

        builder
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.IdProject)
            .HasPrincipalKey(p => p.Id);
    }
}
