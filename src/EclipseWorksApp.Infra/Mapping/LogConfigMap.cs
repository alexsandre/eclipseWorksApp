using EclipseWorksApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorksApp.Infra.Mapping;

internal class LogConfigMap : EntityBaseConfigMap<Log>
{
    public LogConfigMap() : base("Logs", "Id") { }

    public override void Configure(EntityTypeBuilder<Log> builder)
    {
        base.Configure(builder);

        builder.Property(l => l.Field);
        builder.Property(l => l.OldValue);
        builder.Property(l => l.NewValue);
        builder.Property(l => l.NameUser);
    }
}
